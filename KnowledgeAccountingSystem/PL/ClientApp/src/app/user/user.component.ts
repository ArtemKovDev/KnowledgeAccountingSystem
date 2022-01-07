import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { UpdateUserModel } from '../_models/user/updateUserModel';
import { UserModel } from '../_models/user/userModel';
import { UserSkillModel } from '../_models/user/userSkillModel';

@Component({
    selector: 'user',
    templateUrl: './user.component.html',
    providers: [UserService]
})
export class UserComponent implements OnInit {

    userModel: UserModel;
    
    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loadUserModel();
    }

    loadUserModel() {
        this.userService.getUserCredentials()
            .subscribe((data: UserModel) => this.userModel = data);
    }
}