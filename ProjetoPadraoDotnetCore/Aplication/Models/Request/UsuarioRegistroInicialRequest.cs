﻿namespace Aplication.Models.Request;

public class UsuarioRegistroInicialRequest
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Senha { get; set; } = null!;
}