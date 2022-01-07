import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { KnowledgeLevelModel } from 'src/app/_interfaces/skill/knowledgeLevelModel';
 
@Injectable()
export class KnowledgeLevelService {
 
    private url = "/api/knowledgelevels";
 
    constructor(private http: HttpClient) {
    }
 
    getKnowledgeLevels() {
        return this.http.get(this.url);
    }
     
    getKnowledgeLevel(id: number) {
        return this.http.get(this.url + '/' + id);
    }
     
    createKnowledgeLevel(product: KnowledgeLevelModel) {
        return this.http.post(this.url, product);
    }
    updateKnowledgeLevel(product: KnowledgeLevelModel) {
  
        return this.http.put(this.url, product);
    }
    deleteKnowledgeLevel(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}