import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { BaseService } from 'src/factorys/base.service';
import { ToastrService } from 'ngx-toastr';
import { EstruturaMenu, Modulo } from 'src/objects/Menus/EstruturaMenu';
import { FormControl } from '@angular/forms';
import { Observable, startWith, map } from 'rxjs';

@Component({
  selector: 'main-root',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']

})

export class MainComponent implements OnInit{
  usuarioNome: string | null;
  estruturaMenu: Array<Modulo> = [];
  loading: boolean;
  fullscreen: boolean = false;
  control = new FormControl('');

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
  };

  Deslogar = () =>{
    window.localStorage.clear();
    this.router.navigateByUrl('/');
  };

  EditarPerfil = () => {
    let id = window.localStorage.getItem('IdUsuario');
    
    this.router.navigateByUrl('/main/usuario/' + id + '/editar');
  };

  streets: string[] = ['Champs-Élysées', 'Lombard Street', 'Abbey Road', 'Fifth Avenue'];
  filteredStreets!: Observable<string[]>;

  ngOnInit() {
    this.filteredStreets = this.control.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }

  private _filter(value: string): string[] {
    const filterValue = this._normalizeValue(value);
    return this.streets.filter(street => this._normalizeValue(street).includes(filterValue));
  }

  private _normalizeValue(value: string): string {
    return value.toLowerCase().replace(/\s/g, '');
  }
}



