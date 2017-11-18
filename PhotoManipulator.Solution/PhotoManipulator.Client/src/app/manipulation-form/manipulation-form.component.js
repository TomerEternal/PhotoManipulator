"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var imageformmodel_1 = require("../shared/models/imageformmodel");
var ManipulationFormComponent = (function () {
    function ManipulationFormComponent() {
        this.effectKeyValueArray = [
            ["Reverse", "Reverse"],
            ["Black and white", "BlackAndWhite"]
        ];
        this.effects = new Map(this.effectKeyValueArray);
        this.test = this.effectKeyValueArray[0];
        this.model = new imageformmodel_1.ImageFormModel(null, null);
    }
    ManipulationFormComponent.prototype.submitForm = function () {
        this.model.image = this.fileInput.nativeElement.files[0];
        this.upload(this.model);
    };
    ManipulationFormComponent.prototype.upload = function (imageFormModel) {
        var _this = this;
        var formData = new FormData();
        formData.append('image', imageFormModel.image, imageFormModel.image.name);
        formData.append('effect', this.effects.get(imageFormModel.effect));
        var good = this.effects.get(imageFormModel.effect);
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                var parsedResponse = JSON.parse(xhr.response);
                _this.display.nativeElement.src = "data:" + parsedResponse.Image.Content + ";base64," + parsedResponse.Image.Content;
            }
        };
        xhr.open('POST', 'http://localhost:51302/api/home', true);
        xhr.setRequestHeader('enctype', 'multipart/form-data');
        xhr.send(formData);
    };
    return ManipulationFormComponent;
}());
__decorate([
    core_1.ViewChild('fileInput'),
    __metadata("design:type", core_1.ElementRef)
], ManipulationFormComponent.prototype, "fileInput", void 0);
__decorate([
    core_1.ViewChild('display'),
    __metadata("design:type", core_1.ElementRef)
], ManipulationFormComponent.prototype, "display", void 0);
ManipulationFormComponent = __decorate([
    core_1.Component({
        selector: 'manipulation-form-component',
        templateUrl: "./manipulation-form.html",
    })
], ManipulationFormComponent);
exports.ManipulationFormComponent = ManipulationFormComponent;
//# sourceMappingURL=manipulation-form.component.js.map