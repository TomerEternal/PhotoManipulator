
import { Component, ElementRef, ViewChild } from '@angular/core';
import { ImageFormModel } from '../shared/models/imageformmodel';

@Component({
  selector: 'manipulation-form-component',
  templateUrl: `./manipulation-form.html`,
})
export class ManipulationFormComponent {
  @ViewChild('fileInput') fileInput: ElementRef;
  @ViewChild('display') display: ElementRef;

      effectKeyValueArray : [string,string][] = [
        ["Reverse", "Reverse"],
        ["Black and white","BlackAndWhite"]
      ];

  effects = new Map(this.effectKeyValueArray)
  test = this.effectKeyValueArray[0];

  model : ImageFormModel = new ImageFormModel(null,null);

  submitForm(){
    this.model.image=this.fileInput.nativeElement.files[0];
    this.upload(this.model);
  
  }
    upload(imageFormModel: ImageFormModel) {
    var formData: FormData = new FormData();
    formData.append('image', imageFormModel.image, imageFormModel.image.name);
    formData.append('effect', this.effects.get(imageFormModel.effect));
    var good = this.effects.get(imageFormModel.effect);

    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = ()=>{
      if (xhr.readyState===4){
        var parsedResponse = JSON.parse(xhr.response);
        
        this.display.nativeElement.src = `data:${parsedResponse.Image.Content};base64,${parsedResponse.Image.Content}`
      }
    }
    xhr.open('POST', 'http://localhost:51302/api/home', true);
    xhr.setRequestHeader('enctype', 'multipart/form-data');
    xhr.send(formData);
  }
}
