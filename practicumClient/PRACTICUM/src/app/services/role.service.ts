import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { employeeRoles } from '../entities/employeeRoles.model';
import { role } from '../entities/role.model';
import { Employee } from '../entities/employee.model';
import { toArray } from 'rxjs/operators';
import { mergeMap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class RoleService {


  public baseUrl = 'https://localhost:7043/api'
  constructor(private http: HttpClient) { }

  getPositionOfEmployeeById(employeeId: number): Observable<employeeRoles> {
  console.log("getPositionOfEmployeeById")
    return this.http.get<employeeRoles>(`${this.baseUrl}/EmployeeInRole/${employeeId}`);
  }

  getAllRoles(): Observable<role[]> {
    return this.http.get<role[]>(`${this.baseUrl}/Role`)
  }
  addNewRoleToEmployee(employeeId: number, employeeRoles: employeeRoles): Observable<employeeRoles> {
    console.log("addNewRoleToEmployee", employeeRoles)
    return this.http.post<employeeRoles>(`${this.baseUrl}/EmployeeInRole/${employeeId}`, employeeRoles);
  }
  updateRoleOfEmployee(employeeId: number, roleId: number, employee: employeeRoles): Observable<Employee> {
    console.log("updateRoleOfEmployee","employeeId",employeeId,"roleId",roleId,"employee",employee)
    return this.http.put<Employee>(`${this.baseUrl}/EmployeeInRole/${employeeId}/role/${roleId}`, employee);}

    deletePositionOfEmployee(employeeId: number,roleId:number): Observable<Employee> {
      console.log("roleId",roleId)
      return this.http.delete<Employee>(`${this.baseUrl}/EmployeeInRole/${employeeId}/role/${roleId}`); 
    }



 



    // getEmployeePositionsNotAssigned(employeeId: number): Observable<role[]> {
    //   return this.getPositionOfEmployeeById(employeeId).pipe(
    //     mergeMap(employeePositions => {
    //       return this.getAllRoles().pipe(
    //         map(allRoles => {
    //           const assignedRoleIds = employeePositions.map(position => position.roleId);
    //           return allRoles.filter(role => !assignedRoleIds.includes(role.roleId));
    //         })
    //       );
    //     })
    //   );
    // }
    
    
    

  /*
    getAllPositions(): Observable<role[]> {
    return this.http.get<role[]>(this.baseUrl);
  }

addPosition(position:Position): Observable<Position> {
    return this.http.post<Position>(this.baseUrl,position);
  }
  getEmployeePositionsNotAssigned(employeeId: number): Observable<Position[]> {
    return this.employeeService.getEmployeePositions(employeeId).pipe(
      switchMap(employeePositions => {
        return this.getAllPositions().pipe(
          map(allPositions => {
            return allPositions.filter(position => !employeePositions.some(empPos => empPos.positionId === position.positionId));
          })
        );
      })
    );
  }
}
   */
}
