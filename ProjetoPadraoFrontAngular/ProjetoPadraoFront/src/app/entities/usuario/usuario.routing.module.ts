 import { NgModule } from '@angular/core';
 import { RouterModule, Routes } from '@angular/router';
 import { UsuarioComponent } from './usuario.component';


 const EntitiesRoutes: Routes = [
   {path: 'usuario',component: UsuarioComponent,outlet: 'content'}
 ];

 @NgModule({
   imports: [RouterModule.forChild(EntitiesRoutes)],
   exports: [RouterModule]
 })
 
 export class UsuarioRoutingModule { }
