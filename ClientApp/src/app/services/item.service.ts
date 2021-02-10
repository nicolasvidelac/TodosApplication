import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { todoItem } from "../models/todoItem";


@Injectable({
  providedIn: 'root'
})
export class ItemService {

  baseUrl: string;
  axios;

  constructor(@Inject('BASE_URL') baseUrl: string, private router : Router) {
    this.baseUrl = baseUrl;
    this.axios = require('axios').default;
  }

  public async create(itemDesc: string, folderId: number) {
    try {
      return await this.axios.post( this.baseUrl + 'api/v1/todoitem', { description: itemDesc, folder: {id : folderId}},{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    })
    } catch (error) {
      this.handleError(error)
    }
  }

  public async list(id : number) {
    try {
      return await this.axios.get(this.baseUrl + `api/v1/todoitem/${id}`,{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    });
    } catch (error) {
      this.handleError(error)
    } 
  }

  public async patch(item: todoItem) {
    try {
      return await this.axios.patch(this.baseUrl + `api/v1/todoitem/item/${item.id}`, item,{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    })
    } catch (error) {
      this.handleError(error)
    }
  }

  public async delete(id : number) {
    try {
      return await this.axios.delete(this.baseUrl + `api/v1/todoitem/item/${id}`,{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    });
    } catch (error) {
      this.handleError(error)
    }
  }

  handleError(status){
    if (status == 401){
      localStorage.removeItem("jwt");
      this.router.navigate["login"];
    } else {
      console.log("CRUD failed")
      console.log(status)
    }
  }
}
