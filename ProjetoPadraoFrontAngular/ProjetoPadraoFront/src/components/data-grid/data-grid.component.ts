import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { BaseService } from 'src/factorys/base.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Action, GridOptions } from 'src/objects/Grid/GridOptions';
import { ResponseData } from 'src/objects/Grid/GridResponse';
import { MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { DomSanitizer } from '@angular/platform-browser';
import { Filter } from 'src/objects/Grid/Filter';

@Component({
  selector: 'data-grid',
  templateUrl: './data-grid.component.html',
  styleUrls: ['./data-grid.component.scss']
})

export class DataGridComponent implements OnInit{

  @Input() gridOptions!: GridOptions;

  //variaveis grid
  displayedColumnsHeader: string[] = [];
  displayedColumnsFilter: string[] = [];
  displayedColumns: string[] = [];
  data: any = [];

  //variaveis paginação
  pageEvent: PageEvent = {
    pageIndex: 0,
    pageSize: 10,
    length: 0,
  }
  pageSizeOptions: number[] = [5, 10, 25, 100];
  
  //Variaveis Ordenação
  sort: Sort = {
    active: '',
    direction: ''
  }

  //Variaveis Filters
  QueryFilters: Filter[] = [];

  constructor(private response: BaseService,private toastr: ToastrService,
    private router: Router,private paginator: MatPaginatorIntl,private elementRef: ElementRef,
    private sanitizer: DomSanitizer) {
      paginator.itemsPerPageLabel = 'Itens por página'
    }

  ngOnInit(): void {
    //Setar colunas e configurações da grid
    this.gridOptions.Colunas.forEach(element => {
      this.displayedColumns.push(element.Field);
      this.displayedColumnsFilter.push(element.ServerField + 'Field');
    });  

    if(this.gridOptions.Parametros.PaginatorSizeOptions != undefined)
      this.pageSizeOptions = this.gridOptions.Parametros.PaginatorSizeOptions;

    if(this.gridOptions.Parametros.PageSize != undefined)
      this.pageEvent.pageSize = this.gridOptions.Parametros.PageSize;

    this.ConsultarGrid(this.pageEvent);
  }

  ConsultarGrid(event?:PageEvent,sortEvent?: Sort,filter?: Filter){
    if(event != undefined)    
      this.pageEvent = event;

    if(sortEvent != undefined)    
      this.sort = sortEvent;

    if(filter != undefined){

      for (let index = 0; index < this.QueryFilters.length; index++) {
        if(this.QueryFilters[index].Field == filter.Field)
          this.QueryFilters.splice(index, 1); 
      }
      
      if(filter.Value != ""){
        this.QueryFilters.push(filter);
      }
    }    

    this.response.Post(this.gridOptions.Parametros.Controller,this.gridOptions.Parametros.Metodo,{
      Take: this.pageEvent.pageSize,
      Page: this.pageEvent.pageIndex,
      OrderFilters: {
        Campo: this.sort.active,
        Operador: this.sort.direction == 'asc' ? 0 : 1
      },
      QueryFilters: this.QueryFilters
    })
    .subscribe(
      (response: ResponseData) =>{        
        if(response.sucesso){
          this.data = response.data.itens;
          this.pageEvent.length = response.data.totalItens;

          //Atribuição de html a coluna
          this.gridOptions.Colunas.forEach(element =>{
            if(element.ActionButton != undefined){
              response.data.itens.forEach(cell =>
                cell[element.Field] = element.CellTemplate);
            }  
          });

          //Atribuição de action button a coluna
          this.gridOptions.Colunas.forEach(element =>{
            if(element.CellTemplate != undefined){
              response.data.itens.forEach(cell =>
                cell[element.Field] = element.CellTemplate);
            }  
          });
        }
        else{
          this.toastr.error(response.mensagem, 'Mensagem');
        }
      }
    );
  }

  //Grid Services
  ActionButton(action: Action,data: any){
    debugger
    if(action.ParametrosAction.Href != undefined)
      return;

    
  }
}
