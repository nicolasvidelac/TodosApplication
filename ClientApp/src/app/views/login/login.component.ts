import { Component, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  invalidLogin: boolean = false;
  invalidRegister: boolean = false;


  constructor(private basicService : UserService, private router : Router) { }

  login(form: NgForm){
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }
    
    this.basicService.login(credentials).then(response => {
      try {
        const token = response.data.access_token;
        localStorage.setItem("jwt", token);
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
