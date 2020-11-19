import { PagoConsultaComponent } from './Parcial/pago-consulta/pago-consulta.component';
import { PagoRegistroComponent } from './Parcial/pago-registro/pago-registro.component';
import { PersonaConsultaComponent } from './Parcial/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Parcial/persona-registro/persona-registro.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';



const routes: Routes = [
  {
    path: 'pagoConsulta',
    component: PagoConsultaComponent
  },
  {
    path: 'pagoRegistro',
    component: PagoRegistroComponent
  },
  {
    path: 'personaConsulta',
    component: PersonaConsultaComponent
  },
  {
    path: 'personaRegistro',
    component: PersonaRegistroComponent
  }
];



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
