import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../shared/services/profile.service';
import { UserModel } from '../_models/user/userModel';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    providers: [ProfileService]
})
export class ProfileComponent implements OnInit {

    currentUser: UserModel;
    
    constructor(private profileService: ProfileService) { }

    ngOnInit() {
        this.loadUserModel();
    }

    loadUserModel() {
        this.profileService.getUserCredentials()
            .subscribe((data: UserModel) => this.currentUser = data);
    }
}