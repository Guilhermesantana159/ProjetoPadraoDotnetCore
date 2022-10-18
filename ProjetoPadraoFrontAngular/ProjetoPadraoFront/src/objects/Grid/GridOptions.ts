import { EActionButton } from "src/enums/EActionButton"
import { TypeActionButton } from "src/enums/TypeActionButton"
import { TypeFilter } from "src/enums/TypeFilter"

export interface GridOptions{
    Parametros: Parametros,
    Colunas: Array<Coluna>
}

export interface Parametros{
    Controller: string,
    Metodo: string,
    PaginatorSizeOptions: Array<number> | undefined,
    PageSize: number | undefined
}

export interface Coluna{
    Field: string,
    DisplayName: string,
    CellTemplate: string | undefined,
    ActionButton: Array<Action> | undefined,
    Type: TypeFilter,
    Filter: boolean,
    ServerField: string 
}

export interface Action{
    TypeActionButton: TypeActionButton,
    TypeButton: EActionButton
    ParametrosAction: ParametrosAction
}

export interface ParametrosAction{
    Controller: string | undefined,
    Metodo: string | undefined,
    PropriedadeEnviadaServer: Array<string>,
    ClassProperty: string | undefined,
    Disabled: boolean,
    Hidden: boolean,
    Target: string | undefined,
    Href: string | undefined,
    Conteudo: string,
    Tooltip: string
}