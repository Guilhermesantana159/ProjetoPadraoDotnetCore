namespace Aplication.Models.Request;

public class LoginRequest
{
    public string EmailLogin { get; set; } = null!;
    public string SenhaLogin { get; set; } = null!;
}