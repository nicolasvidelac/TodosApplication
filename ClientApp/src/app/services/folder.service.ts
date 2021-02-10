import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { todoFolder } from '../models/todoFolder';

@Injectable({
  providedIn: 'root'
})
export class FolderService {

  baseUrl: string;
  axios;

  constructor(@Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;
    this.axios = require('axios').default;
  }

  public async create(folderDesc: string) {
    try {
      return await this.axios.post( this.baseUrl + 'api/v1/todoFolder', { description: folderDesc},{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    })
    } catch (error) {
      this.handleError(error.response.status)
    }
  }

  public async list() {
    try {
      return await this.axios.get(this.baseUrl + 'api/v1/todoFolder',{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    })
    } catch (error) {
      this.handleError(error.response.status)
    } 
  }

  public async patch(item: todoFolder) {
    try {
      return await this.axios.patch(this.baseUrl + `api/v1/todoFolder/${item.id}`, item,{
        headers:{
          'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
      })
    } catch (error) {
      this.handleError(error.response.status)
    }
  }

  public async delete(id : number) {
    try {
      return await this.axios.delete(this.baseUrl + `api/v1/todoFolder/${id}`,{
        headers:{
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`
        }
    });
    } catch (error) {
      this.handleError(error.response.status)
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
