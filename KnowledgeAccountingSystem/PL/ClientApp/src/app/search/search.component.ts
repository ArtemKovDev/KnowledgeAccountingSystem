import { Component, OnInit } from '@angular/core';
import * as internal from 'assert';
import { RoleService } from '../shared/services/role.service';
import { SearchService } from '../shared/services/search.service';
import { SkillService } from '../shared/services/skill.service';
import { RoleModel } from '../_models/role/RoleModel';
import { SkillModel } from '../_models/skill/skillModel';
import { UserModel } from '../_models/user/userModel';

@Component({
    selector: 'search',
    templateUrl: './search.component.html',
    providers: [SearchService, SkillService, RoleService]
})
export class SearchComponent implements OnInit {

    public errorMessage: string = '';
    public showError: boolean;
    
    searchTerm1: string;
    searchTerm2: string;
    searchTerm3: string;
    searchTerm4: string;
    searchTerm5: string;
    skills: SkillModel[]; 
    skillId: number;
    roles: RoleModel[];
    role: RoleModel = new RoleModel();
    users: UserModel[];
    allUsers: UserModel[];   
    
    constructor(private searchService: SearchService, private skillService: SkillService,
                    private roleService: RoleService) { }

    ngOnInit() {
        this.loadAllUsers();
        this.loadSkills();
        this.loadRoles();
    }

    loadAllUsers() {
        this.showError = false;
        this.searchService.getUsers()
            .subscribe((data: UserModel[]) => {
                this.users = data;
                this.allUsers = this.users;
            });
    }

    loadSkills() {
        this.skillService.getSkills()
            .subscribe((data: SkillModel[]) => this.skills = data);
    }

    loadRoles() {
        this.roleService.getRoles()
            .subscribe((data: RoleModel[]) => this.roles = data);
    }

    loadUsersBySkill(){
        this.showError = false;
        if(this.skillId == null){
            return;
        }
        this.searchService.getUsersBySkill(this.skillId)
        .subscribe((data: UserModel[]) => {
            this.users = data;
            this.allUsers = this.users;
        });
    }

    loadUsersInRole(){
        this.showError = false;
        this.searchService.getUsersInRole(this.role)
        .subscribe((data: UserModel[]) => {
            this.users = data;
            this.allUsers = this.users;
        },
        error => {
            this.errorMessage = error;
            this.showError = true;
        });
    }

    searchByEmail(value: string): void {
        this.users = this.allUsers.filter((val) => val.email.toLowerCase().includes(value));
    }
    searchByFirstName(value: string): void {
        this.users = this.allUsers.filter((val) => val.firstName.toLowerCase().includes(value));
    }
    searchByLastName(value: string): void {
        this.users = this.allUsers.filter((val) => val.lastName.toLowerCase().includes(value));
    }
    searchByPlaceOfWork(value: string): void {
        this.users = this.allUsers.filter((val) => val.placeOfWork.toLowerCase().includes(value));
    }
    searchByEducation(value: string): void {
        this.users = this.allUsers.filter((val) => val.education.toLowerCase().includes(value));
    }
}