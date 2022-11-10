namespace Infraestrutura.Entity;

public class SkillUsuario
{
    public int IdSkill { get; set; }
    public int IdUsuario { get; set; }
    public string Descricao { get; set; } = null!;

    #region Relacionamento
    public virtual Usuario Usuario { get; set; } = null!;
    #endregion

}