namespace Aplication.Models.Request.SkillUsuario;

public class SkillUsuarioEditarRequest
{
    public int IdSkillUsuario { get; set; }
    public string Descricao { get; set; } = null!;
    public int IdUsuario { get; set; }
}