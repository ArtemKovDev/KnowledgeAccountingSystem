import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { SkillCategoryModel } from 'src/app/_interfaces/skill/skillCategoryModel';
 
@Injectable()
export class SkillCategoryService {
 
    private url = "/api/skillcategories";
 
    constructor(private http: HttpClient) {
    }
 
    getSkillCategories() {
        return this.http.get(this.url);
    }
     
    getSkillCategory(id: number) {
        return this.http.get(this.url + '/' + id);
    }
     
    createSkillCategory(product: SkillCategoryModel) {
        return this.http.post(this.url, product);
    }
    updateSkillCategory(product: SkillCategoryModel) {
  
        return this.http.put(this.url, product);
    }
    deleteSkillCategory(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}