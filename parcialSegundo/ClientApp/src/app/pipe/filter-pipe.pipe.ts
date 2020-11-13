import { Pipe, PipeTransform } from '@angular/core';

import { Pago } from '../Parcial/models/pago';

@Pipe({
  name: 'filtroPago'
})
export class FiltroPagoPipe implements PipeTransform {

  transform(pagos: Pago[], searchType: string): unknown {
    if(searchType == null) return pagos;
    return pagos.filter(d => d.tipoPago.toLowerCase().indexOf(searchType.toLowerCase())!==-1);
  }

}
