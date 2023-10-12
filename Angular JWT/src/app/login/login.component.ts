import { Component, OnInit } from '@angular/core';
import { UserService } from '../Service/user.service';
import { Route, Router } from '@angular/router';
import { combineLatest } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  resdata: any;

  constructor(private service: UserService, private route: Router) {}
  ngOnInit(): void {
 
  }

  RedirectRegister() {
    this.route.navigate(['register']);
  }
  loginForm = new FormGroup({
    Email: new FormControl('',Validators.compose([Validators.required, Validators.email])),
    Password: new FormControl('',Validators.required)
  });

  proceedLogin() {
    debugger;
    this.service.ProceedLogin(this.loginForm.value).subscribe({
      next:(item) => {
        this.resdata = item;
        console.log(this.resdata);
       if(this.resdata!=null){
         localStorage.setItem('token',this.resdata.jwT_Token);
         this.route.navigate(['userdetails'])
       }
      },
      error:(err)=>{
        console.log(err);
      },
      complete:()=>{
        console.log("api completed");
      }
    });
  }
}
