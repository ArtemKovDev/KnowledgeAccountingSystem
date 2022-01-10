import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
 
@Injectable()
export class SearchService {
 
    private url = "/api/search";
 
    constructor(private http: HttpClient) {
    }

    getUsers() {
        return this.http.get(this.url + "/getUsers");
    }
}