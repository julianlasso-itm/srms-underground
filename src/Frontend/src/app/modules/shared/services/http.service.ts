import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor(private readonly httpClient: HttpClient) {}

  public get<TResponse>(
    url: string,
    params?: HttpParams,
    headers?: HttpHeaders
  ): Observable<TResponse> {
    return this.httpClient.get<TResponse>(url, { headers, params });
  }

  public post<TRequest, TResponse>(
    url: string,
    body: TRequest,
    params?: HttpParams,
    headers?: HttpHeaders
  ): Observable<TResponse> {
    return this.httpClient.post<TResponse>(url, body, { headers, params });
  }

  public put<TRequest, TResponse>(
    url: string,
    body: TRequest,
    params?: HttpParams,
    headers?: HttpHeaders
  ): Observable<TResponse> {
    return this.httpClient.put<TResponse>(url, body, { headers, params });
  }

  public delete<TResponse>(
    url: string,
    params?: HttpParams,
    headers?: HttpHeaders
  ): Observable<TResponse> {
    return this.httpClient.delete<TResponse>(url, { headers, params });
  }
}
