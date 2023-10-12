import { Component, OnInit } from '@angular/core';
import { UserService } from '../Service/user.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentModel } from '../Model/UserModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  
})
export class RegisterComponent implements OnInit {
  reactiveForm: any;
  constructor(private service: UserService, private route: Router) {}

  Department: any;
  Country: any;
  State: any;
  City: any;

  ngOnInit(): void {
    this.GetCountries();
    this.GetDepartments();
    debugger
    this.reactiveForm = new FormGroup({
      FirstName: new FormControl('', Validators.required),
      LastName: new FormControl('', Validators.required),
      Email: new FormControl('', Validators.compose([Validators.required, Validators.email])),
      Password: new FormControl('', Validators.required),
      Contact: new FormControl('', Validators.required),
      Address: new FormControl('', Validators.required),
      DateOfBirth: new FormControl('', Validators.required),
      Gender: new FormControl('', Validators.required),
      DepartmentId: new FormControl('', Validators.required),
      CountryId: new FormControl('', Validators.required),
      StateId: new FormControl('', Validators.required),
      CityId: new FormControl('', Validators.required),
      Image: new FormControl('', Validators.required),

    });
    console.log(this.reactiveForm);
  }

  GetDepartments() {
    this.service.GetDepartment().subscribe(item => {
      this.Department = item;
      this.Department = this.Department.data;
    });
  }

  GetCountries() {
    this.service.GetCountry().subscribe(item => {
      this.Country = item;
      this.Country = this.Country.data;
      console.log(item);
    });
  }

  GetStates(event: any) {
    console.log(event);
    this.service.GetState(event).subscribe(item => {
      this.State = item;
      this.State = this.State.data;
    });
  }

  GetCities(event: any) {
    this.service.GetCity(event).subscribe(item => {
      this.City = item;
      this.City = this.City.data;
    });
  }

  img: any;
  ImageType(event: any) {
    this.img = event.target.files[0];
  }

  response: any;
  RegisterUser() {
    // debugger
    if(this.reactiveForm.valid) {
      let formdata = new FormData();
      formdata.append('Image', this.img as File);
      formdata.append('FirstName', this.reactiveForm.value.FirstName as string);
      formdata.append('LastName', this.reactiveForm.value.LastName as string);
      formdata.append('Email', this.reactiveForm.value.Email as string);
      formdata.append('Password', this.reactiveForm.value.Password as string);
      formdata.append('Contact', this.reactiveForm.value.Contact as string);
      formdata.append('Address', this.reactiveForm.value.Address as string);
      formdata.append('DateOfBirth', this.reactiveForm.value.DateOfBirth?.toString().replace(' GMT+0530 (India Standard Time)','') as string);
      formdata.append('Gender', this.reactiveForm.value.Gender as string);
      formdata.append('DepartmentId',this.reactiveForm.value.DepartmentId as string);
      formdata.append('CountryId', this.reactiveForm.value.CountryId as string);
      formdata.append('StateId', this.reactiveForm.value.StateId as string);
      formdata.append('CityId', this.reactiveForm.value.CityId as string);
// debugger
      this.service.SignUpUser(formdata).subscribe(item => {
        this.response = item;
        if(this.response.success) {
          this.route.navigate(['login']);
          alert('Registration Successfully');
        } else {
          alert('Registration Failed!');
        }
      });
    } else {
      alert('Please chick the form Validations');
    }
  } 
}
