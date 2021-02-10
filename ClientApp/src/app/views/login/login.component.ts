import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  invalidLogin: boolean;

  constructor(private basicService : LoginService, private router : Router) { }

  login(form: NgForm){
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }
    
    this.basicService.create(credentials).then(response => {
      try {
        const token = response.data.access_token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/folders"])
      } catch (error) {
        this.invalidLogin = true;
      }
    
    }, err => {
      this.invalidLogin = true;
    }
    )
  }
}
