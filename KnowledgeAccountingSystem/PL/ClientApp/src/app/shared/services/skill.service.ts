import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { SkillModel } from 'src/app/_interfaces/skill/skillModel';
 
@Injectable()
export class SkillService {
 
    private url = "/api/skills";
 
    constructor(private http: HttpClient) {
    }
 
    getSkills() {
        return this.http.get(this.url);
    }
     
    getSkill(id: number) {
        return this.http.get(this.url + '/' + id);
    }
     
    createSkill(product: SkillModel) {
        return this.http.post(this.url, product);
    }
    updateSkill(product: SkillModel) {
  
        return this.http.put(this.url, product);
    }
    deleteSkill(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}