import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';


@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor() { }

  intercept(req : HttpRequest<any>,next:HttpHandler) : Observable<HttpEvent<any>>{
    let token = localStorage.getItem('token');
    console.log(token);
    
    let jwtToken = req.clone({
      setHeaders:{
        Authorization:'bearer ' + token
      }
    });
    return next.handle(jwtToken);
  }

}
