import { EventEmitter, Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class GridService{
    public recarregar = new EventEmitter(); 
    public selecionar = new EventEmitter<any>(); 

    public RecarregarGrid()
    {
        this.recarregar.emit(); 
    };

    public SelecionarModal(data: any)
    {
        this.selecionar.emit(data); 
    };
}