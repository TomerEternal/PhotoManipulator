
import { Component, ElementRef, ViewChild } from '@angular/core';
import { ImageFormModel } from '../shared/models/imageformmodel';

@Component({
  selector: 'manipulation-form-component',
  templateUrl: `./manipulation-form.html`,
})
export class ManipulationFormComponent {
  @ViewChild('fileInput') fileInput: ElementRef;

  effects : string[] = ['Reverse'];

  model : ImageFormModel = new ImageFormModel(null,null);

  submitted : boolean = false;

  onSubmit() {
    this.submitted = true;
  } 

  submitForm(){
    this.model.image=this.fileInput.nativeElement.files[0];
    this.upload(this.model);
  
  }
  upload(imageFormModel: ImageFormModel) {
    var formData: FormData = new FormData();
    formData.append('image', imageFormModel.image, imageFormModel.image.name);
    formData.append('effect', imageFormModel.effect);

    var xhr = new XMLHttpRequest();
    xhr.upload.addEventListener('progress', (ev: ProgressEvent) => {
      //You can handle progress events here if you want to track upload progress (I used an observable<number> to fire back updates to whomever called this upload)
    });
    xhr.open('POST', 'http://localhost:51302/api/home', true);
    xhr.setRequestHeader('enctype', 'multipart/form-data');
    xhr.send(formData);
  }
}
