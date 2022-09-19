import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './routes/app-routing.module';
import { AppComponent } from '../app/base/app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LoginComponent } from '../app/entities/login/login.component';
import { MainComponent } from '../app/entities/main/main.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TextErrorMessageComponentModule } from 'src/components/text-error-message/text-error-message.module';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


const maskConfigFunction: () => Partial<IConfig> = () => {
  return {
    validation: true,
  };
};

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MainComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    TextErrorMessageComponentModule,
    NgxMaskModule.forRoot(maskConfigFunction),
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
