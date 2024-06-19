using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Dto;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace AccessControl.Application.UseCases
{
  public sealed class SignInUseCase<TEntity>(
    IUserRepository<TEntity> userRepository,
    ICacheService cacheService,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      SignInCommand,
      SignInApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository = userRepository;
    private readonly ICacheService _cacheService = cacheService;
    private const int MaxAttempts = 3;
    private const int MaxAttemptsMinutes = 5;
    private const int MaxBlockMinutes = 5;

    public override async Task<Result<SignInApplicationResponse>> Handle(SignInCommand request)
    {
      var check = CheckIfUserIsTemporarilyBlocked(request.Email);
      if (check.IsFailure)
      {
        return Response<SignInApplicationResponse>.Failure(
          check.Message,
          check.Code,
          check.Details
        );
      }

      var command = AclInputMapper.ToSignInInitialsDomainRequest(request);
      var response = AggregateRoot.ValidateEmailAndEncryptPassword(command);
      if (response.IsFailure)
      {
        return Response<SignInApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var user = response.Data;
      var verify = await VerifyUserAndPassword(user.Email, user.Password);
      if (verify.IsFailure)
      {
        return Response<SignInApplicationResponse>.Failure(
          verify.Message,
          verify.Code,
          verify.Details
        );
      }

      var data = verify.Data;
      var signInData = AclInputMapper.ToSignInDomainRequest(
        user,
        data.UserId,
        data.Name,
        data.Photo,
        data.Roles,
        command.PrivateKeyPath,
        command.PublicKeyPath
      );
      var result = AggregateRoot.GenerateTokenForSignIn(signInData);
      if (result.IsFailure)
      {
        return Response<SignInApplicationResponse>.Failure(
          result.Message,
          result.Code,
          result.Details
        );
      }

      return new SuccessResult<SignInApplicationResponse>(
        AclOutputMapper.ToSignInApplicationResponse(result.Data)
      );
    }

    private Result<bool> CheckIfUserIsTemporarilyBlocked(string email)
    {
      if (_cacheService.Get($"{email}_temporarily_blocked") != null)
      {
        return Response<bool>.Failure("User is temporarily blocked", ErrorEnum.FORBIDDEN);
      }
      return Response<bool>.Success();
    }

    private Result<bool> BlockUserTemporarily(string email)
    {
      _cacheService.Set(
        $"{email}_temporarily_blocked",
        email,
        TimeSpan.FromMinutes(MaxBlockMinutes)
      );
      return Response<bool>.Failure("User is temporarily blocked", ErrorEnum.FORBIDDEN);
    }

    private async Task<Result<UserDataForSigInDto>> VerifyUserAndPassword(
      string email,
      string password
    )
    {
      try
      {
        var data = await _userRepository.GetByEmailAndPassword(email, password);
        DeletePreviousAttempts(email);
        return Response<UserDataForSigInDto>.Success(data);
      }
      catch (Exception)
      {
        var verify = VerifyPreviousAttempts(email);
        if (verify.IsFailure)
        {
          return Response<UserDataForSigInDto>.Failure(verify.Message, verify.Code, verify.Details);
        }

        return Response<UserDataForSigInDto>.Failure(
          "User not found or credentials incorrect",
          ErrorEnum.UNAUTHORIZED
        );
      }
    }

    private void DeletePreviousAttempts(string email)
    {
      _cacheService.Remove($"{email}_attempts");
    }

    private Result<bool> VerifyPreviousAttempts(string email)
    {
      var path = $"{email}_attempts";
      var attempts = _cacheService.GetListLength(path);

      if (attempts == 0)
      {
        _cacheService.AddToList(path, "strike", TimeSpan.FromMinutes(MaxAttemptsMinutes));
        return Response<bool>.Success();
      }

      if (attempts < MaxAttempts - 1)
      {
        _cacheService.AddToList(path, "strike");
        return Response<bool>.Success();
      }

      if (attempts == MaxAttempts - 1)
      {
        _cacheService.Remove(path);
        return BlockUserTemporarily(email);
      }

      throw new ApplicationException(
        $"Invalid response into SignInUseCase for AccessControl application. VerifyPreviousAttempts",
        HttpStatusCode.InternalServerError
      );
    }
  }
}

// namespace AccessControl.Application.UseCases
// {
//   public sealed class SignInUseCase<TEntity>(
//     IUserRepository<TEntity> userRepository,
//     ICacheService cacheService,
//     ISecurityAggregateRoot aggregateRoot,
//     IApplicationToDomain applicationToDomain,
//     IDomainToApplication domainToApplication
//   )
//     : BaseUseCase<
//       SignInCommand,
//       ISecurityAggregateRoot,
//       IApplicationToDomain,
//       IDomainToApplication
//     >(aggregateRoot, applicationToDomain, domainToApplication)
//     where TEntity : class
//   {
//     // private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialActivated}";
//     private readonly IUserRepository<TEntity> _userRepository = userRepository;
//     private readonly ICacheService _cacheService = cacheService;
//     private const int MaxAttempts = 3;
//     private const int MaxAttemptsMinutes = 5;
//     private const int MaxBlockMinutes = 5;

//     public override async Task<Result> Handle(SignInCommand request)
//     {
//       var check = CheckIfUserIsTemporarilyBlocked(request.Email);
//       if (check.IsFailure)
//       {
//         return check;
//       }

//       var command = AclInputMapper.ToSignInInitialsDomainRequest(request);
//       var response = AggregateRoot.ValidateEmailAndEncryptPassword(command);
//       if (response.IsFailure)
//       {
//         return response;
//       }

//       if (response is SuccessResult<SignInDataInitialsDomainResponse> successResult)
//       {
//         var user = successResult.Data;
//         var verify = await VerifyUserAndPassword(user.Email, user.Password);
//         if (verify.IsFailure)
//         {
//           return verify;
//         }

//         if (verify is SuccessResult<UserDataForSigInDto> successVerify)
//         {
//           var data = successVerify.Data;
//           var signInData = AclInputMapper.ToSignInDomainRequest(
//             user,
//             data.UserId,
//             data.Name,
//             data.Photo,
//             data.Roles,
//             command.PrivateKeyPath,
//             command.PublicKeyPath
//           );
//           var result = AggregateRoot.GenerateTokenForSignIn(signInData);
//           if (result.IsFailure)
//           {
//             return result;
//           }

//           if (result is SuccessResult<SignInDomainResponse> successSignIn)
//           {
//             return new SuccessResult<SignInApplicationResponse>(
//               AclOutputMapper.ToSignInApplicationResponse(successSignIn.Data)
//             );
//           }

//           throw new ApplicationException(
//             "Invalid response into SignInUseCase for AccessControl application. GenerateTokenForSignIn",
//             HttpStatusCode.InternalServerError
//           );
//         }

//         throw new ApplicationException(
//           "Invalid response into SignInUseCase for AccessControl application. VerifyUserAndPassword",
//           HttpStatusCode.InternalServerError
//         );
//       }

//       throw new ApplicationException(
//         "Invalid response into SignInUseCase for AccessControl application. ValidateEmailAndEncryptPassword",
//         HttpStatusCode.InternalServerError
//       );
//     }

//     private Result CheckIfUserIsTemporarilyBlocked(string email)
//     {
//       if (_cacheService.Get($"{email}_temporarily_blocked") != null)
//       {
//         return new ErrorResult("User is temporarily blocked", ErrorEnum.FORBIDDEN);
//       }
//       return new SuccessResult();
//     }

//     private ErrorResult BlockUserTemporarily(string email)
//     {
//       _cacheService.Set(
//         $"{email}_temporarily_blocked",
//         email,
//         TimeSpan.FromMinutes(MaxBlockMinutes)
//       );
//       return new ErrorResult("User is temporarily blocked", ErrorEnum.FORBIDDEN);
//     }

//     private async Task<Result> VerifyUserAndPassword(string email, string password)
//     {
//       try
//       {
//         var data = await _userRepository.GetByEmailAndPassword(email, password);
//         DeletePreviousAttempts(email);
//         return new SuccessResult<UserDataForSigInDto>(data);
//       }
//       catch (Exception)
//       {
//         var verify = VerifyPreviousAttempts(email);
//         if (verify.IsFailure)
//         {
//           return verify;
//         }
//         return new ErrorResult("User not found or credentials incorrect", ErrorEnum.UNAUTHORIZED);
//       }
//     }

//     private void DeletePreviousAttempts(string email)
//     {
//       _cacheService.Remove($"{email}_attempts");
//     }

//     private Result VerifyPreviousAttempts(string email)
//     {
//       var path = $"{email}_attempts";
//       var attempts = _cacheService.GetListLength(path);

//       if (attempts == 0)
//       {
//         _cacheService.AddToList(path, "strike", TimeSpan.FromMinutes(MaxAttemptsMinutes));
//         return new SuccessResult();
//       }

//       if (attempts < MaxAttempts - 1)
//       {
//         _cacheService.AddToList(path, "strike");
//         return new SuccessResult();
//       }

//       if (attempts == MaxAttempts - 1)
//       {
//         _cacheService.Remove(path);
//         return BlockUserTemporarily(email);
//       }

//       throw new ApplicationException(
//         "Invalid response into SignInUseCase for AccessControl application. VerifyPreviousAttempts",
//         HttpStatusCode.InternalServerError
//       );
//     }
//   }
// }
