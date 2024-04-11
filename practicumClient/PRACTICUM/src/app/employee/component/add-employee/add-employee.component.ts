import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { FormsModule, ReactiveFormsModule, } from '@angular/forms';
import { EmployeeService } from '../../../services/employee.service';
import { Employee } from '../../../entities/employee.model';

import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';


// @Component({
//   selector: 'app-add-employee',
//   standalone: true,
//   imports: [ReactiveFormsModule,
//     MatInputModule,
//     MatDatepickerModule,
//     MatNativeDateModule,
//     MatSelectModule
//     ,MatButtonModule,
//     MatFormFieldModule,
//     MatCardModule],
//   templateUrl: './add-employee.component.html',
//   styleUrl: './add-employee.component.scss'
// })
// export class AddEmployeeComponent implements OnInit{
//   employeeForm!: FormGroup;
// constructor(private _employeeService: EmployeeService ,private formBuilder: FormBuilder,) {
// }
// ngOnInit(): void {
//   this.initForm();
// }
// initForm(): void {
//   this.employeeForm = this.formBuilder.group({
//   identity: new FormControl(""),
//   firstName: new FormControl("", [Validators.required]),
//   lastName: new FormControl("", [Validators.required]),
//   dateStart: new FormControl([Validators.required]),
//   birthday:  new FormControl([Validators.required]),
//   gender: new FormControl("", [Validators.required]),
//   });
// }



// addEmployee(): void {
//   console.log("this.employeeForm.valid",this.employeeForm.value)
//   if (this.employeeForm.valid) {
//     const newEmployee: Employee = this.employeeForm.value;
//     console.log("newEmployee",newEmployee);
//     if (!(newEmployee.birthday instanceof Date)) {
//       // If it's not a Date object, parse it into a Date object
//       newEmployee.birthday = new Date(newEmployee.birthday);
//     }
// newEmployee.birthday= (newEmployee.birthday)
// newEmployee.dateStart= (newEmployee.dateStart)
// console.log("this.employeeForm.value.gender",this.employeeForm.value.gender)
//     this._employeeService.addEmployee(newEmployee).subscribe(
//       () => {
//         console.log("okkkkkkkkkk")
//       },
//       (error) => console.log('error'),
//     );
//   }
// }

// }





// import { Component, OnInit } from '@angular/core';
// import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
// import { EmployeeService } from '../../../services/employee.service';
// import { Employee } from '../../../entities/employee.model';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule
    , MatButtonModule,
    MatFormFieldModule,
    MatCardModule, CommonModule],
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent implements OnInit {
  employeeForm!: FormGroup;

  constructor(private _employeeService: EmployeeService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.employeeForm = this.formBuilder.group({
      identity: new FormControl("", [Validators.required, Validators.pattern(/^\d{9}$/)]),
      firstName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      lastName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      dateStart: new FormControl("", [Validators.required]),
      birthday: new FormControl("", [Validators.required]),
      gender: new FormControl("", [Validators.required]),
    });
  }

  addEmployee(): void {
    console.log("this.employeeForm.valid", this.employeeForm.valid)
    if (this.employeeForm.valid) {
      const newEmployee: Employee = this.employeeForm.value;
      console.log("newEmployee", newEmployee);
      if (!(newEmployee.birthday instanceof Date)) {
        // If it's not a Date object, parse it into a Date object
        newEmployee.birthday = new Date(newEmployee.birthday);
      }
      newEmployee.birthday = (newEmployee.birthday)
      newEmployee.dateStart = (newEmployee.dateStart)
      console.log("this.employeeForm.value.gender", this.employeeForm.value.gender)
      this._employeeService.addEmployee(newEmployee).subscribe(
        () => {
          console.log("okkkkkkkkkk")
        },
        (error) => console.log('error'),
      );
    }
  }


  getFormControlError(controlName: string): string {
    const control = this.employeeForm.get(controlName);
    if (control && control.errors) {
      if (control.errors['required']) {
        return 'שדה זה הוא שדה חובה';
      }
      if (control.errors['minlength']) {
        return 'אורך מינימלי הוא 2 תווים';
      }
      if (control.errors['pattern']) {
        if (controlName === 'identity') {
          return 'תבנית לא תקינה (9 ספרות בלבד)';
        }
        return 'תבנית לא תקינה';
      }
    }
    return '';
  }
}

