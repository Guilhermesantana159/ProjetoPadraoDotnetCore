using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.SkillUsuario;

namespace Infraestrutura.Repository.WriteRepository;

public class SkillUsuarioWriteRepository : BaseWriteRepository<SkillUsuario>, ISkillUsuarioWriteRepository
{
    public SkillUsuarioWriteRepository(Context context) : base(context)
    {
    }
}