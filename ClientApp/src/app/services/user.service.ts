import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: string;
  axios;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.axios = require('axios').default;
  }


  public async login(credentials) {
    try {
      return await this.axios.post( this.baseUrl + 'api/v1/auth/login', credentials)
    } catch (error) {
    }
  }

  
  public async register(credentials) {
    try {
      await this.axios.post( this.baseUrl + 'api/v1/auth/register', credentials);
      return true;
    } catch (error) {
      return false;
    }
  }
  
}
