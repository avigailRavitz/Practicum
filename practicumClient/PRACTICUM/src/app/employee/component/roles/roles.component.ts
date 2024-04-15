
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { RoleService } from '../../../services/role.service';
import { Observable } from 'rxjs';
import { role } from '../../../entities/role.model';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [MatDialogModule,CommonModule ,MatIconModule],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.scss'
})

export class RolesComponent implements OnInit {
  roles$: Observable<role[]>;

  constructor(private dialogRef: MatDialogRef<RolesComponent>,
              private roleService: RoleService) { }

  ngOnInit(): void {

    this.roles$ = this.roleService.getAllRoles();
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
