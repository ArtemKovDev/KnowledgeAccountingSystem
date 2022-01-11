import { Component, OnInit } from '@angular/core';
import { KnowledgeLevelModel } from '../_models/skill/knowledgeLevelModel';
import { KnowledgeLevelService } from '../shared/services/knowledge-level.service';
 
@Component({
    selector: 'knowledgeLevel',
    templateUrl: './knowledgeLevel.component.html',
    providers: [KnowledgeLevelService]
})
export class KnowledgeLevelComponent implements OnInit {
 
    knowledgeLevel: KnowledgeLevelModel = new KnowledgeLevelModel();   // изменяемый товар
    knowledgeLevels: KnowledgeLevelModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
 

    constructor(private knowledgeLevelService: KnowledgeLevelService) { }
 
    ngOnInit() {
        this.loadKnowledgeLevels();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadKnowledgeLevels() {
        this.knowledgeLevelService.getKnowledgeLevels()
            .subscribe((data: KnowledgeLevelModel[]) => this.knowledgeLevels = data);
    }
    // сохранение данных
    save() {
        if (this.knowledgeLevel.id == null) {
            this.knowledgeLevelService.createKnowledgeLevel(this.knowledgeLevel)
                .subscribe(data => this.loadKnowledgeLevels());
        } else {
            this.knowledgeLevelService.updateKnowledgeLevel(this.knowledgeLevel)
                .subscribe(data => this.loadKnowledgeLevels());
        }
        this.cancel();
    }
    editKnowledgeLevel(s: KnowledgeLevelModel) {
        this.knowledgeLevel = s;
    }
    cancel() {
        this.knowledgeLevel = new KnowledgeLevelModel();
        this.tableMode = true;
    }
    delete(s: KnowledgeLevelModel) {
        this.knowledgeLevelService.deleteKnowledgeLevel(s.id)
            .subscribe(data => this.loadKnowledgeLevels());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}