using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Usuario;

namespace Infraestrutura.Repository.ReadRepository;

public class UsuarioReadRepository : BaseReadRepository<Usuario>,IUsuarioReadRepository
{
    public UsuarioReadRepository(Context context) : base(context)
    {
    }
}