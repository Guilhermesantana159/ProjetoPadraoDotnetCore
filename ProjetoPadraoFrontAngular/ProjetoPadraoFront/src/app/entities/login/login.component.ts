import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BaseService } from 'src/factorys/base.service';
import { Usuario } from 'src/objects/Usuario';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'login-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginFormGroup: FormGroup;
  UserRegisterFormGroup: FormGroup;
  loading: boolean;
  submit: boolean;

  constructor(private formBuilder: FormBuilder,private response: BaseService,private toastr: ToastrService) {
    this.loading = false;
    this.submit = false;
    this.loginFormGroup = this.formBuilder.group({
        emailLogin: ['', Validators.required],
        senhaLogin: ['', Validators.required]
    });

    this.UserRegisterFormGroup = this.formBuilder.group({
      email: ['', Validators.required],
      nome: ['', Validators.required],
      CPF: ['', Validators.required],
      telefone: ['', Validators.required],
      senha: ['', Validators.required],
      senhaRepeat: ['', Validators.required]
  });
  }

  RegisterUsuario = (form:any) =>{
    if(this.UserRegisterFormGroup.invalid){
      this.submit = true;
      return;
    }

    this.loading = true;
    this.response.Post("Usuario","CadastroInicial",form.value).subscribe(
      (response: Usuario) =>{        
        if(response.sucesso){
          this.toastr.success(response.mensagem, 'Toastr fun!');
        }else{
          alert("Deu Ruim")
        }
        this.loading = false;
      }
    );
  }
    
  Login = (form:any) =>{
    if(this.loginFormGroup.invalid){
      this.submit = true;
      return;
    }

    this.loading = true;
    this.response.Post("Auth","Login",form.value).subscribe(
      (response: Usuario) =>{        
        if(response.sucesso){
          this.toastr.success(response.mensagem, 'Mensagem:');
        }else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }
}
