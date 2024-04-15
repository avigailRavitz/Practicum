import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../entities/employee.model';
import { EmployeeService } from '../../../services/employee.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { DeleteEmployeeComponent } from '../delete-employee/delete-employee.component';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import * as XLSX from 'xlsx';
import { addListener } from 'process';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import { RolesComponent } from '../roles/roles.component';


@Component({
  selector: 'app-employee-table',
  standalone: true,
  imports: [CommonModule, RouterOutlet, MatIconModule],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.scss'
})
export class EmployeeTableComponent implements OnInit {

  employees: Employee[] = [];
  

  constructor(private _employeeServiece: EmployeeService, private router: Router, private dialog: MatDialog) { }
  ngOnInit(): void {
    this._employeeServiece.getEmployees().subscribe({

      next: (res) => {
        this.employees = res;
        console.log(res[0].firstName)

        const button = document.getElementById('exportButton');
        button?.classList.add('nav-link');
        button?.classList.add('export-to-excel');
      },
      error(err) {
        console.log(err);
      },
    })

  }
  addNewEmployee(): void {
    const dialogRef = this.dialog.open(AddEmployeeComponent, {
      width: '500px',
    });
    dialogRef.afterClosed().subscribe(e => {

    })

  }

  editEmployee(employee: Employee): void {

    this.router.navigate(['/editEmployee', employee.employeeId]);

  }
  deletEmployee(employee: Employee): void {
    console.log()
    this.dialog.open(DeleteEmployeeComponent, {
      width: '500px',
      data: { employee }
    });
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.toLowerCase().trim();
    if (!filterValue) {
      // אם שדה החיפוש ריק, הצג את כל הנתונים מחדש
      this._employeeServiece.getEmployees().subscribe({
        next: (res) => {
          this.employees = res;
        },
        error(err) {
          console.log(err);
        },
      });
    } else {
      // אם שדה החיפוש לא ריק, סנן את הנתונים לפי הערך החדש של שדה החיפוש
      this.employees = this.employees.filter(employee => {
        const formattedDate = new Date(employee.dateStart).toLocaleDateString('en-US');
        return employee.identity.toLowerCase().includes(filterValue) ||
          employee.firstName.toLowerCase().includes(filterValue) ||
          employee.lastName.toLowerCase().includes(filterValue) ||
          formattedDate.includes(filterValue);
      });
    }
  }


  exportToExcel(): void {

    const fileName = 'employees.xlsx';
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(this.employees);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Employees');
    XLSX.writeFile(wb, fileName);
  }
  printTable() {
    // אם אתה רוצה להדפיס את תוכן הטבלה הנוכחית, אפשר להשתמש בפונקציות של JavaScript כדי לבצע הדפסה
    // לדוגמה, תוכל להשתמש ב window.print()
    window.print();
  }
  addNewRole(){

  }

 openRolesDialog(): void {
    this.dialog.open(RolesComponent, {
      width: '600px' // ניתן להתאים את הרוחב כרצונך
    });

}
}
