import { BaseService } from "./base.service";
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { todoItem } from "../models/todoItem";

@Injectable({
  providedIn: 'root'
})
export class HomeService extends BaseService{

  baseUrl: string;

  constructor(protected httpClient : HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(httpClient);
    this.baseUrl = baseUrl;
  }

  public create(itemDesc: string): Observable<todoItem[]> {
    return this.httpClient.post<todoItem[]>( this.baseUrl + 'api/v1/todoitem', { description: itemDesc})
  }

  public list(): Observable<todoItem[]> {
    return this.httpClient.get<todoItem[]>(this.baseUrl + 'api/v1/todoitem')
  }

  public patch(item : todoItem){
    return this.httpClient.patch<todoItem[]>(this.baseUrl + `api/v1/todoitem/${item.id}`, item)
  }

  public delete(id : number): Observable<todoItem[]>{
    return this.httpClient.delete<todoItem[]>(this.baseUrl + `api/v1/todoitem/${id}`)
  }
}
