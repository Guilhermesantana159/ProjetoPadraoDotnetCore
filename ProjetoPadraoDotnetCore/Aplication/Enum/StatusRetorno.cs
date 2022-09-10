using System.ComponentModel;

namespace Aplication.Enum;

public enum StatusRetorno
{
    [Description("Erro")]
    Erro = 1,
    [Description("Sucesso")]
    Sucesso = 2,
    [Description("Indefinido")]
    Indefinido = 3
}