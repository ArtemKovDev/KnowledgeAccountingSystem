import { Component, OnInit } from '@angular/core';
import { SkillService } from '../shared/services/skill.service';
import { SkillModel } from '../_models/skill/skillModel';
 
@Component({
    selector: 'skill',
    templateUrl: './skill.component.html',
    providers: [SkillService]
})
export class SkillComponent implements OnInit {
 
    skill: SkillModel = new SkillModel();   // изменяемый товар
    skills: SkillModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
 

    constructor(private skillService: SkillService) { }
 
    ngOnInit() {
        this.loadSkills();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadSkills() {
        this.skillService.getSkills()
            .subscribe((data: SkillModel[]) => this.skills = data);
    }
    // сохранение данных
    save() {
        if (this.skill.id == null) {
            this.skillService.createSkill(this.skill)
                .subscribe((data: SkillModel) => this.skills.push(data));
        } else {
            this.skillService.updateSkill(this.skill)
                .subscribe(data => this.loadSkills());
        }
        this.cancel();
    }
    editSkill(s: SkillModel) {
        this.skill = s;
    }
    cancel() {
        this.skill = new SkillModel();
        this.tableMode = true;
    }
    delete(s: SkillModel) {
        this.skillService.deleteSkill(s.id)
            .subscribe(data => this.loadSkills());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}