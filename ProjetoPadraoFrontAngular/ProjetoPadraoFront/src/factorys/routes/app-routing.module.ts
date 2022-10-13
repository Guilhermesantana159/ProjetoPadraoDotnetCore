import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioComponent } from 'src/app/entities/usuario/usuario.component';
import { LoginComponent } from '../../app/entities/login/login.component';
import { MainComponent } from '../../app/entities/main/main.component';

const routes: Routes = [
  {path: 'main',component: MainComponent, 
  children: [ 
      { 
          path: 'usuario', 
          component: UsuarioComponent
      }]},
  {path: 'login',component: LoginComponent},
  {path: '**',component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
