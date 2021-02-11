import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean = false;
  invalidRegister: boolean = false;

  isRegistered: boolean = false;

  constructor(private basicService : UserService, private router : Router, private route : ActivatedRoute) {
  }

  ngOnInit(){
    this.route.queryParams.subscribe( param => {
      console.log(param["isRegistered"])
      if (param["isRegistered"] == "true"){
        this.isRegistered = true
      } else {
        this.isRegistered = false
      }
    })
  }

  login(form: NgForm){
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }
    
    this.basicService.login(credentials).then(response => {
      try {
        console.log(response)
        localStorage.setItem("jwt", response.data.access_token);
        localStorage.setItem("username", response.data.username)
        this.invalidLogin = false;
        this.invalidRegister = false;
        this.router.navigate(["/folders"])
      } catch (error) {
        this.invalidLogin = true;
        this.invalidRegister = false;
      }
    
    }, err => {
      this.invalidLogin = true;
    }
    )
  }

  register(form: NgForm){
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }
    
    this.basicService.register(credentials).then(response => {
      if (response == true) {
        this.login(form);
        this.invalidRegister = false;
        this.invalidLogin = false;
      } else{
        this.invalidRegister = true;
        this.invalidLogin = false;
      }
    })
  }
}
