import { Inject, Injectable } from '@angular/core';
import { todoFolder } from '../models/todoFolder';

@Injectable({
  providedIn: 'root'
})
export class FolderService {

  baseUrl: string;
  axios;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.axios = require('axios').default;
  }

  public async create(folderDesc: string) {
    try {
      return await this.axios.post( this.baseUrl + 'api/v1/todoFolder', { description: folderDesc})
    } catch (error) {
      console.error(error)
    }
  }

  public async list() {
    try {
      return await this.axios.get(this.baseUrl + 'api/v1/todoFolder')
    } catch (error) {
      console.log(error);
    } 
  }

  public async patch(item: todoFolder) {
    try {
      return await this.axios.patch(this.baseUrl + `api/v1/todoFolder/${item.id}`, item)
      
    } catch (error) {
      console.log(error)
    }
  }

  public async delete(id : number) {
    try {
      return await this.axios.delete(this.baseUrl + `api/v1/todoFolder/${id}`);
    } catch (error) {
      console.log(error)
    }
  }
}
