import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  
  userName = "";

  constructor(private router: Router, private jwtHelper: JwtHelperService ) { }

  ngOnInit(){
    try {
      this.userName = localStorage.getItem("username")
    } catch (error) {
      
    }
      
    
  }
  isUserAuthenticated(){
    const token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)){
      
      return true;
    }
    else {
      return false;
    }
  }

  logOut(){
    localStorage.removeItem("jwt")
  }

}
