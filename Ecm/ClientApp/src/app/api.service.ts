import { Injectable } from '@angular/core';
import { throwError, Observable } from 'rxjs';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { RequestOptions } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {}
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  private formatErrors(error: any) {
    if (error.status === 401) {
      return throwError('Authorization failed');
    }
    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, { params: params } )
      .pipe(catchError(this.formatErrors));
  }
  geta(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http
      .get(`${environment.account_api}${path}`, { params: params } )
      .pipe(catchError(this.formatErrors));
  }
  getByRoute(path: string, params?: any[]): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}/${params.join('/')}`)
      .pipe(catchError(this.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http
      .put(
        `${environment.api_url}${path}`,
        JSON.stringify(body),
        this.httpOptions
      )
      .pipe(catchError(this.formatErrors));
  }

  patch(path: string, body: Object = {}): Observable<any> {
    return this.http
      .patch(
        `${environment.api_url}${path}`,
        JSON.stringify(body),
        this.httpOptions
      )
      .pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http
      .post(
        `${environment.api_url}${path}`,
        JSON.stringify(body),
        this.httpOptions
      )
      .pipe(catchError(this.formatErrors));
  }

  delete(path: any): Observable<any> {
    return this.http
      .delete(`${environment.api_url}${path}`, this.httpOptions)
      .pipe(catchError(this.formatErrors));
  }
}
