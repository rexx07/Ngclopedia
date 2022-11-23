import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {catchError, Observable, throwError} from "rxjs";
import {environment} from "../../../environments/environment";
import { ApiResult } from "../models/api-result.model";

@Injectable()
export class ApiService{
  constructor(private http: HttpClient) {}

  private formatErrors(error: any){
    return throwError(error.error)
  }

  private getUrl(path: string): string{
    return `${environment.api_url}${path}`
  }

  getData(
    path: string,
    pageIndex: number,
    pageSize: number,
    sortOrder: string,
    filterQuery: string | null,
    params: HttpParams = new HttpParams()): Observable<ApiResult<any>>{
      params
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortOrder", sortOrder);

      if(filterQuery)
        params.set("filterQuery", filterQuery)

      return this.http.get<ApiResult<any>>(path, {params})
    }

  get(path: string): Observable<any>{
    return this.http.get(this.getUrl(path))
      .pipe(catchError(this.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any>{
    return this.http.put(this.getUrl(path), JSON.stringify(body))
      .pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any>{
    return this.http.post(this.getUrl(path), JSON.stringify(body))
      .pipe(catchError(this.formatErrors));
  }

  delete(path: string): Observable<any>{
    return this.http.delete(this.getUrl(path))
      .pipe(catchError(this.formatErrors));
  }
}
