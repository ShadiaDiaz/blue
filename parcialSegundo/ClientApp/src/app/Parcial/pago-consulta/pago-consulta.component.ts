import { Component, OnInit } from '@angular/core';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-consulta',
  templateUrl: './pago-consulta.component.html',
  styleUrls: ['./pago-consulta.component.css']
})
export class PagoConsultaComponent implements OnInit {
  pagos: Pago[];
  constructor(private pagoService: PagoService) { }

  ngOnInit() {
    this.get();
  }
  get()
  {
    this.pagoService.gets().subscribe(result => {
      this.pagos = result;
    })
  }


}
