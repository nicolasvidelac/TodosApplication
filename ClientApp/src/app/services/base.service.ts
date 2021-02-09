import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  protected headers: HttpHeaders = new HttpHeaders();
  protected APIEndpoint = environment.production;
  constructor(protected httpClient: HttpClient) { }
}
