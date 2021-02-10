import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl: string;
  axios;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.axios = require('axios').default;
  }


  public async create(credentials) {
    try {
      return await this.axios.post( this.baseUrl + 'api/v1/auth/login', credentials)
    } catch (error) {
    }
  }
  
}
