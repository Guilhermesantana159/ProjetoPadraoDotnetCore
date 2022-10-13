namespace Aplication.Models.Request.Usuario;

public class UsuarioRequest
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
}