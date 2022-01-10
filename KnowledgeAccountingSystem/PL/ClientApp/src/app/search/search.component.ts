import { Component, OnInit } from '@angular/core';
import { SearchService } from '../shared/services/search.service';
import { UserModel } from '../_models/user/userModel';

@Component({
    selector: 'search',
    templateUrl: './search.component.html',
    providers: [SearchService]
})
export class SearchComponent implements OnInit {

    searchTerm1: string;
    searchTerm2: string;
    searchTerm3: string;
    searchTerm4: string;
    searchTerm5: string;
    users: UserModel[];
    allUsers: UserModel[];   
    
    constructor(private searchService: SearchService) { }

    ngOnInit() {
        this.loadAllUsers();
    }

    loadAllUsers() {
        this.searchService.getUsers()
            .subscribe((data: UserModel[]) => {
                this.users = data;
                this.allUsers = this.users;
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