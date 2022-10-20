import { Component, ElementRef } from '@angular/core';
import { TypeFilter } from 'src/enums/TypeFilter';
import { GridOptions } from 'src/objects/Grid/GridOptions';

@Component({
  selector: 'usuario-root',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})

export class UsuarioComponent{
  gridOptions: GridOptions;
  
  constructor(){  
    this.gridOptions = {
        Parametros: {
          Controller: 'Usuario',
          Metodo: 'ConsultarGridUsuario',
          PaginatorSizeOptions: [5,10,15],
          PageSize: 5,
        },
        Colunas: [{
            Field: 'Action',
            DisplayName: 'Action',
            CellTemplate: '<h1>teste</h1>',
            Type: TypeFilter.none,
            Filter: false,
            ServerField: '',
            ActionButton: [
              {
                TypeActionButton: 1,
                TypeButton: 0,
                ParametrosAction: {
                  Metodo: 'EditarUsuario',
                  Controller: 'Usuario',
                  PropriedadeEnviadaServer: ['idUsuario'],
                  Conteudo: '<i class="bi bi-pencil-square"></i>',
                  ClassProperty: 'btn btn-info',
                  Disabled: false,
                  Hidden: false,
                  Target: undefined,
                  Href: undefined,
                  Tooltip: 'Editar'
                }
              }
            ]  
        },
        {
          Field: 'idUsuario',
          DisplayName: 'Cód',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.Number,
          Filter: true,
          ServerField: 'IdUsuario'
        },
        {
          Field: 'nome',
          DisplayName: 'Nome',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.String,
          Filter: true,
          ServerField: 'Nome'  
        },
        {
          Field: 'email',
          DisplayName: 'Email',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.String,
          ServerField: 'Email',
          Filter: true  
        },
        {
          Field: 'cpf',
          DisplayName: 'CPF',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.String,
          ServerField: 'CPF',
          Filter: true  
        },
        {
          Field: 'cpf1',
          DisplayName: 'CPF',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.String,
          ServerField: 'cpf1',
          Filter: true  
        },
        {
          Field: 'cpf2',
          DisplayName: 'CPF',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.String,
          ServerField: 'cpf2',
          Filter: true  
        },
        {
          Field: 'cpf3',
          DisplayName: 'CPF',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.String,
          ServerField: 'cpf3',
          Filter: true  
        },
        {
          Field: 'cpf4',
          DisplayName: 'CPF',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.String,
          ServerField: 'cpf4',
          Filter: true  
        },
        {
          Field: 'cpf5',
          DisplayName: 'CPF',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.String,
          ServerField: 'cpf5',
          Filter: true  
        }
      ]
    }
  }
}

