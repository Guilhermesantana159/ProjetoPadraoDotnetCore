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
    DisplayName: string
}