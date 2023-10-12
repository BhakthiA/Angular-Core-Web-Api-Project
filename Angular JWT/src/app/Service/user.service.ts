import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  GetDepartment() {
    return this.http.get('http://localhost:5115/api/List/GetDepartment');
  }

  GetCountry() {
    return this.http.get('http://localhost:5115/api/List/GetCountry');
  }

  GetState(id: any) {
    return this.http.get(`http://localhost:5115/api/List/GetState?id=${id}`);
  }

  GetCity(id: any) {
    return this.http.get(`http://localhost:5115/api/List/GetCity?id=${id}`);
  }

  GetUsers() {
    return this.http.get('http://localhost:5115/api/Student/GetAllStudent');
  }

  SignUpUser(data: any) {
    debugger;
    return this.http.post('http://localhost:5115/api/SignIn/Register', data);
  }

  GetToken() {
    return localStorage.getItem('token') != null
      ? localStorage.getItem('token')
      : '';
  }

  GetOneStudent(id: any) {
    return this.http.get(
      `http://localhost:5115/api/Student/GetOneStudent?id=${id}`
    );
  }

  ProceedLogin(inputdata: any) {
    debugger;
    // let param = {
    //   Email:inputdata.UserEmail,
    //   Password:inputdata.UserEmailPassword
    // }
    return this.http.post('http://localhost:23474/api/SignIn/Login', inputdata);
  }

  IsLoggedIn() {
    return localStorage.getItem('token') != null;
  }
}
