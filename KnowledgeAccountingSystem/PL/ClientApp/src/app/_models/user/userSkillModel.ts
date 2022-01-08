import { KnowledgeLevelModel } from "../skill/knowledgeLevelModel";
import { SkillModel } from "../skill/skillModel";

export class UserSkillModel{
    constructor(
        public id?: number,
        public skillId?: number,
        public skill?: SkillModel,
        public knowledgeLevelId?: number,
        public knowledgeLevel?: KnowledgeLevelModel) { }  
}


