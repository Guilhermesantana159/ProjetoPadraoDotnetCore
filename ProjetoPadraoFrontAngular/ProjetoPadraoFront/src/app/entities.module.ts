import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';
import { ComponentModule } from 'src/components/components.module';
import { AuthTokenInterceptor } from 'src/factorys/interceptor/header.interceptor';
import { AppComponent } from './entities/base/app.component';
import { LoginComponent } from './entities/login/login.component';
import { MainComponent } from './entities/main/main.component';
import { UsuarioComponent } from './entities/usuario/usuario.component';
import { UsuarioRoutingModule } from './entities/usuario/usuario.routing.module';


const maskConfigFunction: () => Partial<IConfig> = () => {
    return {
      validation: true,
    };
  };

@NgModule({
    declarations: [  
        AppComponent,
        LoginComponent,
        MainComponent,
        UsuarioComponent 
    ],
    exports: [  
        AppComponent,
        LoginComponent,
        MainComponent, 
        UsuarioComponent,
    ],
    imports: [  
        CommonModule,
        ComponentModule,   
        ReactiveFormsModule,
        NgxMaskModule.forRoot(maskConfigFunction),
        FormsModule,
        HttpClientModule,
        ToastrModule.forRoot(),
        UsuarioRoutingModule
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: AuthTokenInterceptor, multi: true }
    ],
})

export class EntitiesModule { }