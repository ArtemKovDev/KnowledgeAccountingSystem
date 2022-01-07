import { Component, OnInit } from '@angular/core';
import { SkillCategoryService } from '../shared/services/skillCategory.service';
import { SkillCategoryModel } from '../_interfaces/skill/skillCategoryModel';
 
@Component({
    selector: 'skillCategory',
    templateUrl: './skillCategory.component.html',
    providers: [SkillCategoryService]
})
export class SkillCategoryComponent implements OnInit {
 
    skillCategory: SkillCategoryModel = new SkillCategoryModel();   // изменяемый товар
    skillCategories: SkillCategoryModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
 

    constructor(private skillCategoryService: SkillCategoryService) { }
 
    ngOnInit() {
        this.loadSkillCategories();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadSkillCategories() {
        this.skillCategoryService.getSkillCategories()
            .subscribe((data: SkillCategoryModel[]) => this.skillCategories = data);
    }
    // сохранение данных
    save() {
        if (this.skillCategory.id == null) {
            this.skillCategoryService.createSkillCategory(this.skillCategory)
                .subscribe((data: SkillCategoryModel) => this.skillCategories.push(data));
        } else {
            this.skillCategoryService.updateSkillCategory(this.skillCategory)
                .subscribe(data => this.loadSkillCategories());
        }
        this.cancel();
    }
    editSkillCategory(s: SkillCategoryModel) {
        this.skillCategory = s;
    }
    cancel() {
        this.skillCategory = new SkillCategoryModel();
        this.tableMode = true;
    }
    delete(s: SkillCategoryModel) {
        this.skillCategoryService.deleteSkillCategory(s.id)
            .subscribe(data => this.loadSkillCategories());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}