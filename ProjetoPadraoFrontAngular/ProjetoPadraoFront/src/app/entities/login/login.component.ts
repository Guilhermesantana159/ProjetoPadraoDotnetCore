import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BaseService } from 'src/factorys/base.service';
import { Usuario } from 'src/objects/Usuario/Usuario';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ValidateSenha } from 'src/factorys/validators/validators-form';

@Component({
  selector: 'login-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginFormGroup: FormGroup;
  UserRegisterFormGroup: FormGroup;
  loading: boolean;
  submitLogin: boolean;
  submitRegister: boolean;

  constructor(private formBuilder: FormBuilder,private response: BaseService,private toastr: ToastrService,
    private router: Router) {
    this.loading = false;
    this.submitLogin = false;
    this.submitRegister = false;

    this.loginFormGroup = this.formBuilder.group({
        emailLogin: ['', Validators.required],
        senhaLogin: ['', Validators.required]
    });

    this.UserRegisterFormGroup = this.formBuilder.group({
      email: ['', [Validators.required,Validators.email]],
      nome: ['', Validators.required],
      CPF: ['', [Validators.required,Validators.minLength(11)]],
      senha: ['', [Validators.required,ValidateSenha]],
    });
  }

  RegisterUsuario = (form:any) =>{
    if(this.UserRegisterFormGroup.invalid){
      this.submitRegister = true;
      return;
    }

    this.loading = true;
    this.response.Post("Usuario","CadastroInicial",form.value).subscribe(
      (response: Usuario) =>{        
        if(response.sucesso){
          this.toastr.success('<small>' + response.mensagem + '</small>', 'Mensagem');
        }else{
          this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem');
        }
        this.loading = false;
      }
    );
  }
    
  Login = (form:any) =>{
    if(this.loginFormGroup.invalid){
      this.submitLogin = true;
      return;
    }

    this.loading = true;
    this.response.Post("Auth","Login",form.value).subscribe(
      (response: Usuario) =>{        
        if(response.sucesso){
          window.localStorage.setItem('NomeUsuario',response.data.nome);
          window.localStorage.setItem('Token',response.data.sessionKey.acess_token);
          this.toastr.success('<small>' + 'Seja bem vindo ' + response.data.nome + '<small>', 'Mensagem:');   
          this.router.navigate(['/', 'main'])
        }else{
          this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }
}
