import { HttpClient, JsonpClientBackend } from "@angular/common/http";
import { Injectable, OnInit } from '@angular/core';
import { environment } from "src/environments/environment.prod";

@Injectable({
    providedIn: 'root'
})

export class BaseService{
    
    //Variaveis
    request : HttpClient;
    rota: string

    //Constructor
    constructor(http: HttpClient){
        this.request = http;
        this.rota = environment.link;
    }

    Get(controller: string,metodo: string,objetoEnvio:any){
        return this.request.get<any>(this.rota + controller + '/' + metodo, objetoEnvio)
    };
    
    Post(controller: string,metodo: string,objetoEnvio: any){
        return this.request.post<any>(this.rota + controller + '/' + metodo,objetoEnvio)
    };
};