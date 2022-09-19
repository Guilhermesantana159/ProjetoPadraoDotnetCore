import { EPerfil } from "src/enums/EPerfil";
import { RetornoPadrao } from "./RetornoPadrao";

export interface Usuario extends RetornoPadrao
{
    data: DataUsuario
}

export interface DataUsuario
{
    idUsuario: string, 
    nome: string,
    telefone: string,
    login: string,
    senha: string,
    cpf: string,
    perfil: EPerfil,
    idUbs: string
}