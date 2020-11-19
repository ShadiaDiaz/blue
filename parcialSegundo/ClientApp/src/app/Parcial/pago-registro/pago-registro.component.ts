import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Persona } from '../models/persona';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { PersonaService } from 'src/app/services/persona.service';
import { Pago } from '../models/pago';
import { PagoService } from '../../services/pago.service';

@Component({
  selector: 'app-pago-registro',
  templateUrl: './pago-registro.component.html',
  styleUrls: ['./pago-registro.component.css']
})
export class PagoRegistroComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private personaService: PersonaService,
    private modalService: NgbModal, private PagoService: PagoService) { }
  formGroup: FormGroup;
  persona: Persona;
  pago: Pago;
  personas: Persona[];
  stringPersona: string;
  stringasi: string[];
  ngOnInit() {
  }
  private buildForm(...args: []) {
    this.pago = new Pago();
    this.persona = new Persona();
    this.persona.identificacion = '';
    this.pago.cod = '';
    this.pago.tipoPago = '';
    this.pago.fechaPago = new Date(Date.now()).toDateString();
    this.pago.valorPago = 0;
    this.pago.valorIva = 0;



    this.formGroup = this.formBuilder.group({
      identificacion: [this.persona.identificacion, [Validators.required, Validators.maxLength(13)]],
      cod: [this.pago.cod, [Validators.required, Validators.maxLength(13)]],
      tipoPago: [this.pago.tipoPago, [Validators.required]],
      fechaPago: [this.pago.fechaPago, [Validators.required]],
      valorPago: [this.pago.valorPago, [Validators.required]],
      valorIva: [this.pago.valorIva, [Validators.required]],
    });
  }
  get control() {
    return this.formGroup.controls;
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    if (this.persona == null) {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Resultado Operacion";
      messageBox.componentInstance.cuerpo = 'Error: No ha agregado una persona a la solicitud';
    }
    this.agregar();
  }
  buscarpersona() {
    var id = this.formGroup.value.identificacion;
    this.personaService.get(id).subscribe(result => {
      if (result != null) {
        this.personas = result;
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Se ha añadido a la solicitud a ' + this.persona.nombres;
      }
      else {
        this.persona = undefined;
      }
    })
  }
  agregar() {
    this.PagoService.post(this.pago).subscribe(result => {
      if (result != null) {
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Se ha creado el pago';
        this.pago = result;
      }
    })
  }


}


