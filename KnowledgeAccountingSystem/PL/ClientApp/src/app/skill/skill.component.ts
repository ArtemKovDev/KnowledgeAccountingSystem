import { Component, OnInit } from '@angular/core';
import { SkillCategoryService } from '../shared/services/skill-category.service';
import { SkillService } from '../shared/services/skill.service';
import { SkillCategoryModel } from '../_models/skill/skillCategoryModel';
import { SkillModel } from '../_models/skill/skillModel';
 
@Component({
    selector: 'skill',
    templateUrl: './skill.component.html',
    providers: [SkillService,SkillCategoryService]
})
export class SkillComponent implements OnInit {
 
    public errorMessage: string = '';
    public showError: boolean;

    skill: SkillModel = new SkillModel();   // изменяемый товар
    skills: SkillModel[];                // массив товаров
    skillCategories: SkillCategoryModel[];    
    tableMode: boolean = true;          // табличный режим
 

    constructor(private skillService: SkillService, private skillCategoryService: SkillCategoryService) { }
 
    ngOnInit() {
        this.loadSkills();    // загрузка данных при старте компонента  
        this.loadSkillCategories();
    }
    // получаем данные через сервис
    loadSkills() {
        this.skillService.getSkills()
            .subscribe((data: SkillModel[]) => this.skills = data);
    }
    loadSkillCategories() {
        this.skillCategoryService.getSkillCategories()
            .subscribe((data: SkillCategoryModel[]) => this.skillCategories = data);
    }
    // сохранение данных
    save() {
        if (this.skill.id == null) {
            this.skillService.createSkill(this.skill)
                .subscribe(data => this.loadSkills(),
        error => {
            this.errorMessage = error;
            this.showError = true;
        });
        } else {
            this.skillService.updateSkill(this.skill)
                .subscribe(data => this.loadSkills(),
            error => {
                this.errorMessage = error;
                this.showError = true;
            });
        }
        this.cancel();
    }
    editSkill(s: SkillModel) {
        this.showError = false;
        this.skill = s;
    }
    cancel() {
        this.skill = new SkillModel();
        this.tableMode = true;
    }
    delete(s: SkillModel) {
        this.showError = false;
        this.skillService.deleteSkill(s.id)
            .subscribe(data => this.loadSkills());
    }
    add() {
        this.showError = false;
        this.cancel();
        this.tableMode = false;
    }
}