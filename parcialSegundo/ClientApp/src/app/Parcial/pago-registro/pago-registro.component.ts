import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Persona } from '../models/persona';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from 'src/app/@base/modal/modal.component';
import { PersonaService } from 'src/app/services/persona.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-registro',
  templateUrl: './pago-registro.component.html',
  styleUrls: ['./pago-registro.component.css']
})
export class PagoRegistroComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private personaService: PersonaService,
    private modalService: NgbModal) { }
    formGroup: FormGroup;
    persona: Persona;
    pago :Pago;
  ngOnInit() {
  }
  private buildForm(...args: []) {
    this.pago = new Pago();
    this.persona = new Persona();
    this.persona.identificacion = '';
    this.pago.cod= '';
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
    if(this.persona == null){
      const messageBox = this.modalService.open(ModalComponent)
      messageBox.componentInstance.title = "Resultado Operacion";
      messageBox.componentInstance.cuerpo = 'Error: No ha agregado una persona a la solicitud';
    }
    this.agregar();
  }
}
