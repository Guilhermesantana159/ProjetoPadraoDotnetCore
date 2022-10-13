namespace Aplication.Models.Response;

public class LoginResponse
{
    public bool Autenticado { get; set; }
    public string Nome { get; set; }
    public object SessionKey { get; set; }
}