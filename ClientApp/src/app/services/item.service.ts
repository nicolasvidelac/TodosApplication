import { Inject, Injectable } from '@angular/core';
import { todoItem } from "../models/todoItem";


@Injectable({
  providedIn: 'root'
})
export class ItemService {

  baseUrl: string;
  axios;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.axios = require('axios').default;
  }

  public async create(itemDesc: string, folderId: number) {
    try {
      return await this.axios.post( this.baseUrl + 'api/v1/todoitem', { description: itemDesc, folder: {id : folderId}})
    } catch (error) {
      console.error(error)
    }
  }

  public async list(id : number) {
    try {
      return await this.axios.get(this.baseUrl + `api/v1/todoitem/${id}`);
    } catch (error) {
      console.log(error);
    } 
  }

  public async patch(item: todoItem) {
    try {
      return await this.axios.patch(this.baseUrl + `api/v1/todoitem/item/${item.id}`, item)
      
    } catch (error) {
      console.log(error)
    }
  }

  public async delete(id : number) {
    try {
      return await this.axios.delete(this.baseUrl + `api/v1/todoitem/item/${id}`);
    } catch (error) {
      console.log(error)
    }
  }
}
