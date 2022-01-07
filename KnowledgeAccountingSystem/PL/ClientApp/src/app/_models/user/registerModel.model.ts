export class RegisterModel {
    constructor(
        public email?: string,
        public password?: string,
        public passwordConfirm?: string,
        public firstName?: string,
        public lastName?: string,
        public placeOfWork?: string,
        public education?: string) { } 
}