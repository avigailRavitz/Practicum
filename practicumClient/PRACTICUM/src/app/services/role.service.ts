import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { employeeRoles } from '../entities/employeeRoles.model';
import { role } from '../entities/role.model';
import { Employee } from '../entities/employee.model';
import { map, switchMap, toArray } from 'rxjs/operators';
import { mergeMap } from 'rxjs/operators';
import { log } from 'console';


@Injectable({
  providedIn: 'root'
})
export class RoleService {


  public baseUrl = 'https://localhost:7043/api'
  constructor(private http: HttpClient) { }

  getPositionOfEmployeeById(employeeId: number): Observable<any> {

    return this.http.get<any>(`${this.baseUrl}/EmployeeInRole/${employeeId}`);
  }

  getAllRoles(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Role`)
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

    getEmployeePositionsNotAssigned(employeeId: number): Observable<role[]> {
      return this.getPositionOfEmployeeById(employeeId).pipe(
        switchMap(employeePositions => {
          return this.getAllRoles().pipe(
            map(allPositions => {
              
              // return allPositions.filter(position => !employeePositions.some(x => x?.positionId === position?.roleId));
              return allPositions.filter(position => !employeePositions.some((x: employeeRoles) => x?.roleId === position?.roleId));

            })
          );
        })
      );
    }

    // getRolesNotAssignedToEmployee(employeeId: number): Observable<role[]> {
      
    //   return this.getPositionOfEmployeeById(employeeId).pipe(
    //     switchMap((employeeRoles: employeeRoles) => {
    //       const rolesForEmployee = employeeRoles;
    //       console.log("rolesForEmployee",rolesForEmployee)//הדפיס מערך של אוביקטים
    //       const assignedRoleIds = [employeeRoles.roleId];
    //       console.log("assignedRoleIds",assignedRoleIds)//הדפיס undifinde
    //       return this.getAllRoles().pipe(
    //         map(allRoles => {
    //           console.log("allRoles.filter(role => !assignedRoleIds.includes(role.roleId))",allRoles.filter(role => !assignedRoleIds.includes(role.roleId)))
    //           return allRoles.filter(role => !assignedRoleIds.includes(role.roleId));
    //         })
    //       );
    //     })
    //   );
    // }






    // getRolesNotAssignedToEmployee(employeeId: number): Observable<role[]> {
    //   return this.getPositionOfEmployeeById(employeeId).pipe(
    //     switchMap((employeeRoles: employeeRoles[]) => {
    //       const assignedRoleIds: number[] = [];
    //       for (const rolesForEmployee of employeeRoles) {
    //         assignedRoleIds.push(rolesForEmployee.roleId);
    //       }
    
    //       // הדפסת ה־IDs של התפקידים שהוקצו לעובד
    //       console.log("assignedRoleIds", assignedRoleIds);
    
    //       // קריאה לשרת כדי לקבל את כל התפקידים במערכת
    //       return this.getAllRoles().pipe(
    //         map(allRoles => {
    //           // החזרת התפקידים שאינם מוקצים לעובד (שאינם נמצאים ברשימת ה־IDs שהוקצו לעובד)
    //           return allRoles.filter(role => !assignedRoleIds.includes(role.roleId));
    //         })
    //       );
    //     })
    //   );
    // }
    

    



    
    // getRolesNotAssignedToEmployee(employeeId: number): Observable<role[]> {
    //   return this.getPositionOfEmployeeById(employeeId).pipe(
    //     switchMap((employeeRoles: employeeRoles) => {
    //       // קבלת רשימת התפקידים שהוקצו לעובד
    //       const assignedRoleIds = employeeRoles.map(role => role.roleId);
    
    //       // הדפסת רשימת התפקידים שהוקצו לעובד
    //       console.log("assignedRoleIds", assignedRoleIds);
    
    //       // קריאה לשרת כדי לקבל את כל התפקידים במערכת
    //       return this.getAllRoles().pipe(
    //         map(allRoles => {
    //           // החזרת התפקידים שאינם מוקצים לעובד
    //           return allRoles.filter(role => !assignedRoleIds.includes(role.id));
    //         })
    //       );
    //     })
    //   );
    // }
    
    
  

    // getEmployeePositionsNotAssigned(employeeId: number): Observable<role[]> {
    //   return this.getPositionOfEmployeeById(employeeId).pipe(
    //     switchMap(employeePositions => {
    //       return this.getAllRoles().pipe(
    //         map(allPositions => {
    //           return allPositions.filter(position => !employeePositions.some(empPos => empPos.roleId === position.roleId));
    //         })
    //       );
    //     })
    //   );
    // }
  

 



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
    
    
    


}
