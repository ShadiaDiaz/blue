import { Component, OnInit } from '@angular/core';
import { persona } from './../models/persona';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

   persona: persona;
   formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }
   private buildForm() {
          this.formGroup = this.formBuilder.group({ });
      }
    
}
