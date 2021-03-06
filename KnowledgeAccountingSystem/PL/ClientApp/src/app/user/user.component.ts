import { Component, OnInit } from '@angular/core';
import { KnowledgeLevelService } from '../shared/services/knowledge-level.service';
import { SkillService } from '../shared/services/skill.service';
import { UserService } from '../shared/services/user.service';
import { KnowledgeLevelModel } from '../_models/skill/knowledgeLevelModel';
import { SkillModel } from '../_models/skill/skillModel';
import { UserSkillModel } from '../_models/user/userSkillModel';

@Component({
    selector: 'user',
    templateUrl: './user.component.html',
    providers: [UserService, SkillService, KnowledgeLevelService]
})
export class UserComponent implements OnInit {

    public errorMessage: string = '';
    public showError: boolean;

    tableMode: boolean = true;          // табличный режим
    userSkill: UserSkillModel = new UserSkillModel();   // изменяемый товар
    userSkills: UserSkillModel[];
    skills: SkillModel[]; 
    knowledgeLevels: KnowledgeLevelModel[];  
    
    constructor(private userService: UserService, private skillService: SkillService,
        private knowledgeLevelService: KnowledgeLevelService) { }

    ngOnInit() {
        this.loadUserSkills();
        this.loadSkills();
        this.loadKnowledgeLevels();
    }

    loadUserSkills(){
        this.userService.getSkills()
            .subscribe((data: UserSkillModel[]) => this.userSkills = data);
    }
    loadSkills() {
        this.skillService.getSkills()
            .subscribe((data: SkillModel[]) => this.skills = data);
    }
    loadKnowledgeLevels() {
        this.knowledgeLevelService.getKnowledgeLevels()
            .subscribe((data: KnowledgeLevelModel[]) => this.knowledgeLevels = data);
    }

    // сохранение данных
    save() {
        if (this.userSkill.id == null) {
            this.userService.addSkill(this.userSkill)
                .subscribe(data => this.loadUserSkills(),
            error => {
                this.errorMessage = error;
                this.showError = true;
            });
        } 
        this.cancel();
    }
    cancel() {
        this.showError = false;
        this.userSkill = new UserSkillModel();
        this.tableMode = true;
    }
    delete(u: UserSkillModel) {
        this.userService.deleteSkill(u)
            .subscribe(data => this.loadUserSkills());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}