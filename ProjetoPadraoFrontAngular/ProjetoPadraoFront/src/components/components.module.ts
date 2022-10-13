import { NgModule } from '@angular/core';
import { DataGridComponent } from './data-grid/data-grid.component';
import { TextErrorMessageComponent } from './text-error-message/text-error-message.component';
import {MatTableModule} from '@angular/material/table';
import { BrowserModule } from '@angular/platform-browser';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';

@NgModule({
    declarations: [ TextErrorMessageComponent,DataGridComponent],
    exports: [ TextErrorMessageComponent,DataGridComponent],
    imports: [MatTableModule,BrowserModule,MatPaginatorModule,MatSortModule]
})

export class ComponentModule { }