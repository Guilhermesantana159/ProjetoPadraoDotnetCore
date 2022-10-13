import { Component, Input, OnInit } from '@angular/core';
import { BaseService } from 'src/factorys/base.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { GridOptions } from 'src/objects/Grid/GridOptions';
import { ResponseData } from 'src/objects/Grid/GridResponse';
import { MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'data-grid',
  templateUrl: './data-grid.component.html',
  styleUrls: ['./data-grid.component.css']
})

export class DataGridComponent implements OnInit{

  @Input() gridOptions!: GridOptions;

  //variaveis grid
  displayedColumns: string[] = [];
  data: any = [];
  displayedColumnsFilter: string[] = [];

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

  constructor(private response: BaseService,private toastr: ToastrService,
    private router: Router,private paginator: MatPaginatorIntl) {
      paginator.itemsPerPageLabel = 'Itens por página'
    }

  ngOnInit(): void {
    //Setar colunas e configurações da grid
    this.gridOptions.Colunas.forEach(element => {
      this.displayedColumns.push(element.Field);
      this.displayedColumnsFilter.push(element.Field + 'Filter');
    });  

    if(this.gridOptions.Parametros.PaginatorSizeOptions != undefined)
      this.pageSizeOptions = this.gridOptions.Parametros.PaginatorSizeOptions;

    if(this.gridOptions.Parametros.PageSize != undefined)
      this.pageEvent.pageSize = this.gridOptions.Parametros.PageSize;

    this.ConsultarGrid(this.pageEvent);
  }

  ConsultarGrid(event?:PageEvent,sortEvent?: Sort){
    if(event != undefined)    
      this.pageEvent = event;

    if(sortEvent != undefined)    
      this.sort = sortEvent;

    this.response.Post(this.gridOptions.Parametros.Controller,this.gridOptions.Parametros.Metodo,{
      Take: this.pageEvent.pageSize,
      Page: this.pageEvent.pageIndex,
      Order: {
        active: this.sort.active,
        direction: this.sort.direction
      }
    })
    .subscribe(
      (response: ResponseData) =>{        
        if(response.sucesso){
          this.data = response.data.itens;
          this.pageEvent.length = response.data.totalItens;
        }else{
          this.toastr.error(response.mensagem, 'Mensagem');
        }
      }
    );
  }
}
