import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  formGroup: FormGroup;
  persona: Persona;
  constructor(private formBuilder: FormBuilder, private personaService: PersonaService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.buildForm();
  }
  private buildForm(...args: []) {
    this.persona = new Persona();
    this.persona.tipoDocumento = '';
    this.persona.identificacion = '';
    this.persona.nombres = '';
    this.persona.direccion = '';
    this.persona.pais = '';
    this.persona.departamento = '';
    this.persona.ciudad = '';



    this.formGroup = this.formBuilder.group({
      tipoDocumento: [this.persona.tipoDocumento, [Validators.required, Validators.maxLength(5)]],
      identificacion: [this.persona.identificacion, [Validators.required, Validators.maxLength(25)]],
      nombres: [this.persona.nombres, [Validators.required, Validators.maxLength(50)]],
      //direccion: [this.persona.direccion, [Validators.required, Validators.maxLength(50)]],
      //telefono: [this.persona.telefono, [Validators.required, Validators.maxLength(50)]],
      pais: [this.persona.pais, [Validators.required, Validators.maxLength(50)]],
      departamento: [this.persona.departamento, [Validators.required, Validators.maxLength(50)]],
      ciudad: [this.persona.ciudad, [Validators.required, Validators.maxLength(50)]],
    });
  }
  get control() {
    return this.formGroup.controls;
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.agregar();
  }


  agregar() {
    this.persona = this.formGroup.value;
    this.personaService.post(this.persona).subscribe(p=>{
      if(p != null){
        const messageBox = this.modalService.open(AlertModalComponent)​
        messageBox.componentInstance.title = "Resultado Operación";​
        messageBox.componentInstance.cuerpo = 'persona creada!!! :-)';
        this.persona = p;
      }
    });
  }
}
