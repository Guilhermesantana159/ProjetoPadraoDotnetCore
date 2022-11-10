import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { ConsultaModal } from 'src/objects/Consulta-Padrao/consulta-modal';
import { ConsultaModalParams } from 'src/objects/Consulta-Padrao/ConsultaModalParams';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BaseService } from 'src/factorys/base.service';
import { Endereco } from 'src/objects/Endereco/Endereco';
import { BaseOptions, SelectPadrao } from 'src/objects/Select/SelectPadrao';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { RetornoPadrao } from 'src/objects/RetornoPadrao';
import { ValidateDataAniversario, ValidateSenha } from 'src/factorys/validators/validators-form';

@Component({
  selector: 'usuario-crud-root',
  templateUrl: './usuario-crud.component.html',
  styleUrls: ['../usuario.component.css']
})

export class UsuarioCrudComponent{
  //Variaveis funcionais comportamento da tela tela
  loading = false;
  UserRegisterFormGroup: FormGroup;
  submitRegister = false;
  indexTab: number = 0;

  //Aba configurações
  paramsConsultaUsuario: ConsultaModalParams = {
    Label: 'Usuário que cadastrou',
    Title: 'Consulta de usuário',
    Disabled: false,
    Class: 'col-sm-12 col-xs-6 col-md-6 col-lg-6'
  };

  //Aba endereço
  disabledForApiCep: boolean = true;

  //Aba Principal
  options!: Array<BaseOptions>;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  addOnBlur = true;
  lSkill: string[] = [];

  constructor(private formBuilder: FormBuilder,private response: BaseService,
    private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {

    //Formulario builder
    this.UserRegisterFormGroup = this.formBuilder.group({
      PerfilAdministrador: [false],
      dedicacao: [0, Validators.min(1)],
      idUsuarioCadastro: ['', [Validators.required]],
      cep: ['', [Validators.required,Validators.minLength(8)]],
      pais: ['Brasil', [Validators.required]],
      estado: ['', [Validators.required]],
      cidade: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      rua: ['', [Validators.required]],
      numero: ['', [Validators.required]],
      nome: ['', [Validators.required]],
      email: ['', [Validators.required]],
      nomeMae: ['', [Validators.required]],
      nomePai: [''],      
      cpf: ['', [Validators.required,Validators.minLength(11)]],
      observacao: [''],     
      rg: ['', [Validators.minLength(9)]],
      telefone: ['', [Validators.minLength(11)]],
      genero: ['', [Validators.required]],
      dataNascimento: ['', [Validators.required,ValidateDataAniversario]],
      idProfissao: ['', [Validators.required]],
      lSkills: [[]],
      senha: ['', [Validators.required,ValidateSenha]]
    });

    this.response.Get("Utils","ConsultarProfissoes").subscribe(
      (response: SelectPadrao) =>{        
        if(response.sucesso){
          this.options = response.data;
        }else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
      }
    );

    this.route.params.subscribe(params => {
      //Load Edit
      if(params['id'] != undefined){
         this.response.Get("Usuario","ConsultarViaId/" + params['id']).subscribe(
      (response: any) =>{        
        if(response.sucesso){
          this.UserRegisterFormGroup.setValue(response.data);
        }else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
      });
      }
    });
  }

  //Funções aba principal
  Add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.lSkill.push(value);
    }

    event.chipInput!.clear();
    this.UserRegisterFormGroup.get('lSkills')?.setValue(this.lSkill);
  }

  Remove(skill: string): void {
    const index = this.lSkill.indexOf(skill);

    if (index >= 0) {
      this.lSkill.splice(index, 1);
    }

    this.UserRegisterFormGroup.get('lSkills')?.setValue(this.lSkill);
  }
 
  //Aba configurações endereço
  FormatLabel(value: number) {
    if (value >= 1000) {
      return Math.round(value / 1000) + '%';
    }

    return value;
  }

  //Aba Endereco funções
  PesquisarEndereco = () =>{
    let cepValue = this.UserRegisterFormGroup.get('cep'); 
    this.loading = true;

    if(cepValue?.invalid){
      this.loading = false;
      this.toastr.error('<small>Preencha o campo cep corretamente!</small>', 'Mensagem:');
      return;
    }

    this.response.Get("Utils","ConsultarEnderecoCep/" + cepValue?.value).subscribe(
      (response: Endereco) =>{        
        if(response.sucesso){
          this.UserRegisterFormGroup.get('estado')?.setValue(response.data.estado);
          this.UserRegisterFormGroup.get('cidade')?.setValue(response.data.cidade);
          this.UserRegisterFormGroup.get('rua')?.setValue(response.data.rua);
          this.UserRegisterFormGroup.get('bairro')?.setValue(response.data.bairro);
          this.disabledForApiCep = response.data.statusApi;
        }
        else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
        this.loading = false;
      }
    );
  
  };

  //Operacional da página
  Salvar = (form:FormGroup) =>{
    this.loading = true;
    this.submitRegister = true;

    form.get('genero')?.setValue(parseInt(form.get('genero')?.value));

    form.get('lSkills')?.setValue(
      [{Descricao: 'C#',IdUsuario:0},{Descricao: 'Angular',IdUsuario:0}]
    );

    if(this.UserRegisterFormGroup.invalid){
      this.loading = false;
      this.toastr.error('<small>Preencha os campos corretamente no formulário!</small>', 'Mensagem:');
      return;
    }
    this.response.Post("Usuario","Cadastrar",form.value).subscribe(
      (response: RetornoPadrao) =>{        
        if(response.sucesso){
          this.toastr.success(response.mensagem, 'Mensagem:');
          this.router.navigateByUrl('/main/usuario/')
        }else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }

  //Modais
  ModalUsuarioChange(event: ConsultaModal){
    this.UserRegisterFormGroup.get('idUsuarioCadastro')?.setValue(event.SelectedValue);
  }

  LimparCampoData(){
    this.UserRegisterFormGroup.get('dataNascimento')?.setValue('');
  }

  //Interação das abas
  ControleAbas(event: number){
    this.indexTab = event;
  }

  ButtonEventAba(acc: number){
    this.indexTab += acc;
  }
};


