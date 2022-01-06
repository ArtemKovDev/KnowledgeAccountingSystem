import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { UpdateUserModel } from '../_interfaces/user/updateUserModel';
import { UserModel } from '../_interfaces/user/userModel';
import { UserSkillModel } from '../_interfaces/user/userSkillModel';
import { UserSkillViewModel } from '../_interfaces/user/userSkillViewModel';

@Component({
    selector: 'user',
    templateUrl: './user.component.html',
    providers: [UserService]
})
export class UserComponent implements OnInit {

    userModel: UserModel = new UserModel();
    
    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loadUserModel();
    }

    loadUserModel() {
        this.userService.getUserCredentials()
            .subscribe((data: UserModel) => this.userModel = data);
    }
}