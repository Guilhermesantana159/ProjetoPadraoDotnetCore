import { Component } from '@angular/core';
import { GridOptions } from 'src/objects/Grid/GridOptions';

@Component({
  selector: 'usuario-root',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})

export class UsuarioComponent {
  gridOptions: GridOptions;
  
  constructor(){
    this.gridOptions = {
        Parametros: {
          Controller: 'Usuario',
          Metodo: 'ConsultarGridUsuario',
          PaginatorSizeOptions: [5,10,15],
          PageSize: 5
        },
        Colunas: [{
          Field: 'idUsuario',
          DisplayName: 'Cód'
        },
        {
          Field: 'nome',
          DisplayName: 'Nome'
        },
        {
          Field: 'email',
          DisplayName: 'Email'
        },
        {
          Field: 'cpf',
          DisplayName: 'CPF'
        },
        {
          Field: 'telefone',
          DisplayName: 'Telefone'
        }
      ]
    }
  }
}


