# Skills Ranking and Monitoring System - SRMS

## What is the project about

Management and assessment of technical competencies in software development teams by team leaders, based on expert judgment, to track the technical skills and experience level of software developers, through the implementation of an open-source web application.

## Short description of the project

The "Skills Ranking and Monitoring System (SRMS)" is an advanced solution aimed at the evaluation and management of technical competencies in software development teams. As an open-source web platform, SRMS enables team leaders to conduct precise assessments of the technical knowledge and experience of each developer, using an approach based on expert judgment. This tool allows for the efficient administration of developer profiles and client accounts, including the ability to register, update, and maintain a complete history of technical evaluations, which is essential for talent management within the organization.

## How the project was initialized

The project was initialized using the following commands in the terminal. The commands are:

### First: Create the solution

```bash
dotnet new sln -n SRMS -o SRMS
cd SRMS
```

### Second: Create the global.json file to specify the SDK version

```bash
dotnet new globaljson --sdk-version 8.0.101
```

### Third: Create the .gitignore file

```bash
dotnet new gitignore
```

### Fourth: Initialize the git repository and change the default branch to main

```bash
git init
git branch -M main
```

### Fifth: Create the frontend project with Angular

```bash
npm install -g @angular/cli
ng new SRMS --directory src/Frontend --strict true --prefix srms --style scss --routing true
```

### Sixth: Create the backend project with .NET Core and its Tests project

```bash
dotnet new webapi -o src/Backend/ApiGateway/Infrastructure -n ApiGateway.Infrastructure
dotnet new mstest -o src/Backend/ApiGateway/Infrastructure.Tests -n ApiGateway.Infrastructure.Tests
```

### Seventh: Add the ApiGateway.Infrastructure project reference to the ApiGateway.Infrastructure.Tests project

```bash
dotnet add src/Backend/ApiGateway/Infrastructure.Tests/ApiGateway.Infrastructure.Tests.csproj reference src/Backend/ApiGateway/Infrastructure/ApiGateway.Infrastructure.csproj
```

### Eighth: Add the ApiGateway.Infrastructure project and ApiGateway.Infrastructure.Test project to the solution

```bash
dotnet sln add src/Backend/ApiGateway/Infrastructure/ApiGateway.Infrastructure.csproj
dotnet sln add src/Backend/ApiGateway/Infrastructure.Tests/ApiGateway.Infrastructure.Tests.csproj
```

## How to install the project

## How to setup the project

## How to run the backend project

## How to run the frontend project
