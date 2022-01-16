import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../shared/services/profile.service';
import { UserModel } from '../_models/user/userModel';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    providers: [ProfileService]
})
export class ProfileComponent implements OnInit {

    public errorMessage: string = '';
    public showError: boolean;

    currentUser: UserModel;
    userRoles: String[];
    tableMode: boolean = true;  
    
    constructor(private profileService: ProfileService) { }

    ngOnInit() {
        this.loadUserModel();
        this.loadUserRoles();
    }
    loadUserModel() {
        this.profileService.getUserCredentials()
            .subscribe((data: UserModel) => this.currentUser = data);
    }
    loadUserRoles() {
        this.profileService.getRoles()
            .subscribe((data: String[]) => this.userRoles = data)
    }
    save() {
        this.profileService.updateUserCredentials(this.currentUser)
            .subscribe(data => this.loadUserModel(),
        error => {
            this.errorMessage = error;
            this.showError = true;
        });
        this.cancel();
    }
    editUser() {
        this.showError = false;
        this.tableMode = false;
    }
    cancel() {
        this.loadUserModel();
        this.tableMode = true;
    }
}