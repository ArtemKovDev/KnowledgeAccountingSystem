import { SkillCategoryModel } from "./skillCategoryModel";

export class SkillModel {
    constructor(
        public id?: number,
        public name?: string,
        public description?: string,
        public categoryId?: number) { }
}