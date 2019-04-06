import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-translation',
  templateUrl: './translation.component.html',
  styleUrls: ['./translation.component.scss']
})
export class TranslationComponent implements OnInit {
  public showTextArea: boolean = true;
  fileToUpload: File;

  public lang: string;

  formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private http: HttpClient) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      'toSearch': [''],
      'result': ['']
    });
  }

  public handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
  }

  public changeToText() {
    this.showTextArea = true;
  }

  public changeToOCR() {
    this.showTextArea = false;
  }

  public changeLang(lang) {
    this.lang = lang;
  }
  
  public search() {
    if (this.lang == undefined) {
      return;
    }

    if (this.showTextArea) {
      var text: string = this.formGroup.get('toSearch').value;
      if (text.length > 0) {
        this.http.post('api/Dictionary/SearchText', { text: text, lang: this.lang })
          .subscribe((result) => this.formGroup.patchValue({ 'result': result }));
      }
    }
    else {
      if (this.fileToUpload != undefined) {
        this.http.post('api/Search/SearchImage', { image: this.fileToUpload, lang: this.lang })
          .subscribe((result) => this.formGroup.patchValue({ 'result': result }));
      }
    }
  }
}
