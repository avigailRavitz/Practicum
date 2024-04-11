
import { RoleTableComponent } from '../role-table/role-table.component';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
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

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [RoleTableComponent, ReactiveFormsModule, MatInputModule, MatDatepickerModule, MatNativeDateModule, MatSelectModule, MatButtonModule, MatFormFieldModule, MatCardModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss'
})

export class EditEmployeeComponent implements OnInit {
  employeeForm!: FormGroup;
  employee!: Employee
  employeeId!: number
  constructor(
    private _employeeService: EmployeeService,
    private formBuilder: FormBuilder,
    private router: Router,
    public route: ActivatedRoute,) {
  }
  ngOnInit(): void {
    console.log("999999999999999999")
    this.employeeId = Number(this.route.snapshot.paramMap.get('id'));
    this._employeeService.getEmployeeById(this.employeeId).subscribe({
      next: (res) => {
        this.employee = res;
        console.log("this.employee", this.employee)
        this.employeeForm = this.formBuilder.group({
          firstName: [this.employee.firstName,  [Validators.required, Validators.minLength(2)]],
          lastName: [this.employee.lastName,  [Validators.required, Validators.minLength(2)]],
          identity: [this.employee.identity, [Validators.required, Validators.pattern(/^\d{9}$/)]],
          birthday: [this.employee.birthday, Validators.required],
          gender: [this.employee.gender, Validators.required],
          dateStart: [this.employee.dateStart, Validators.required],
        })
      }
    })
    this.initForm();
  }
  update(): void {
    if (this.employeeForm.valid) {
      const employee: Employee = {
        employeeId: this.employeeId,
        identity: this.employeeForm.get('identity')?.value,
        firstName: this.employeeForm.get('firstName')?.value,
        lastName: this.employeeForm.get('lastName')?.value,
        dateStart: this.employeeForm.get('dateStart')?.value,
        birthday: this.employeeForm.get('birthday')?.value,
        gender: this.employeeForm.get('gender')?.value,
      }
      this._employeeService.updateEmployeeDetails(this.employeeId, employee).subscribe({
        next: (res) => {
          console.log("sssssssssss", res)
        },
        error(res) {
          console.log(res)
        }
      })
      console.log("employeeeee", employee)
    }
  }
  addRole():void{
    
  }
  initForm(): void {
    this.employeeForm = this.formBuilder.group({
      identity: new FormControl(""),
      firstName: new FormControl("", [Validators.required]),
      lastName: new FormControl("", [Validators.required]),
      dateStart: new FormControl("", [Validators.required]),
      birthday: new FormControl("", [Validators.required]),
      gender: new FormControl(0, [Validators.required]),
    });
  }
}


