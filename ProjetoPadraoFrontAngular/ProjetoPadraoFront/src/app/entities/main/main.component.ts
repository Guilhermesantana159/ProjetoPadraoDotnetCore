import { Component} from '@angular/core';
import { Router } from '@angular/router';
import { BaseService } from 'src/factorys/base.service';
import { ToastrService } from 'ngx-toastr';
import { EstruturaMenu, Modulo } from 'src/objects/Menus/EstruturaMenu';

@Component({
  selector: 'main-root',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']

})

export class MainComponent{
  usuarioNome: string | null;
  estruturaMenu: Array<Modulo> = [];
  loading: boolean;

  constructor(private toastr: ToastrService,private response: BaseService,private router: Router){
    this.loading = true;
    this.usuarioNome = window.localStorage.getItem('NomeUsuario');
    this.response.Get("EstruturaMenu","ConsultarEstruturaMenus").subscribe(
      (response: EstruturaMenu) =>{        
        if(response.sucesso){
          for(var i=0;i<response.data.lModulos.length;i++){
            this.estruturaMenu.push(response.data.lModulos[i]);
          }
          this.loading = false;
        }else{
          this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem:');
        }
      }
    ); 
  }

  toggleClass = () =>{
    document.getElementById('sidebar')?.classList.toggle('active');
    document.getElementById('content')?.classList.toggle('active');;
  }

  deslogar = () =>{
    window.localStorage.clear();
    this.router.navigateByUrl('/');
  }
}



