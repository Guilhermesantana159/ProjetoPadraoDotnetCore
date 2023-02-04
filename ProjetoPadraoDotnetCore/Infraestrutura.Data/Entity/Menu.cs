namespace Infraestrutura.Entity;

public class Menu
{
    public int IdMenu { get; set; }
    public string Nome { get; set; }
    public string Link { get; set; }
    public int IdModulo { get; set; }

    #region Relacionamento
    public virtual Modulo Modulo { get; set; }

    #endregion
}