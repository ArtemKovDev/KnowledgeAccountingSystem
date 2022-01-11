import { Component, OnInit } from '@angular/core';
import { RoleService } from '../shared/services/role.service';
import { RoleModel } from '../_models/role/RoleModel';
import { UserRolesModel } from '../_models/role/UserRolesModel';

@Component({
    selector: 'role',
    templateUrl: './role.component.html',
    providers: [RoleService]
})
export class RoleComponent implements OnInit {

    public errorMessage: string = '';
    public showError: boolean;

    currentRole: RoleModel = new RoleModel();
    roles: RoleModel[];
    userRoleModel: UserRolesModel = new UserRolesModel("", []);
    tableMode: boolean = true;  
    userRolementSuccess: boolean;
    
    constructor(private roleService: RoleService) { }

    ngOnInit() {
        this.loadRoles();
    }
    loadRoles() {
        this.roleService.getRoles()
            .subscribe((data: RoleModel[]) => this.roles = data);
    }

    // сохранение данных
    saveRole() {
        this.roleService.createRole(this.currentRole)
            .subscribe(data => this.loadRoles(),
        error => {
            this.errorMessage = error;
            this.showError = true;
        });
        this.cancel();
    }

    saveUserRole() {
        this.roleService.createRole(this.currentRole)
            .subscribe(data => this.loadRoles(),
        error => {
            this.errorMessage = error;
            this.showError = true;
        });
        this.cancel();
    }

    saveUserRoleAssignment(){
       
        this.roleService.assignUserToRole(this.userRoleModel)
            .subscribe(data => {
                this.loadRoles();
                this.userRolementSuccess = true;
            },
        error => {
            this.userRolementSuccess = false;
            this.errorMessage = error;
            this.showError = true;
        });
        this.cancelUserRole();
    }
    saveUserRoleRemoving(){
        
        this.roleService.removeUserToRole(this.userRoleModel)
        .subscribe(data => {
            this.loadRoles();
            this.userRolementSuccess = true;
        },
        error => {
            this.userRolementSuccess = false;
            this.errorMessage = error;
            this.showError = true;
        });
        this.cancelUserRole();
    }

    cancel() {
        this.currentRole = new RoleModel();
        this.tableMode = true;
    }
    cancelUserRole(){
        this.userRoleModel = new UserRolesModel("", []);
    }
    delete(r: RoleModel) {
        this.userRolementSuccess = false;
        this.showError = false;
        this.roleService.deleteRole(r)
            .subscribe(data => this.loadRoles(),
        error => {
            this.errorMessage = error;
            this.showError = true;
        });
    }
    add() {
        this.userRolementSuccess = false;
        this.showError = false;
        this.cancel();
        this.tableMode = false;
    }

    userRolmentMode(r: string){
        this.userRolementSuccess = false;
        this.showError = false;
        this.userRoleModel.roles = [r];
    }
}