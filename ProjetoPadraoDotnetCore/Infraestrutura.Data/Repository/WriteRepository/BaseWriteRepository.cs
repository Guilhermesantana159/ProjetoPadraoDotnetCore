using Infraestrutura.DataBaseContext;
using Infraestrutura.Repository.Interface.Base;

namespace Infraestrutura.Repository.WriteRepository;

public class BaseWriteRepository <T> : IBaseWriteRepository<T> where T : class
{
    private Context Context;

    public BaseWriteRepository(Context context)
    {
        Context = context;
    }
    
    public void Add(T entidade)
    {
        Context.Set<T>().Add(entidade);
        Context.SaveChanges();
    }

    public void AddRange(List<T> lEntidade)
    {
        Context.AddRange(lEntidade);
        Context.SaveChanges();
    }

    public void Update(T entidade)
    {
        Context.Set<T>().Update(entidade);
        Context.SaveChanges();
    }
    
    public void UpdateRange(List<T> lEntidade)
    {
        Context.UpdateRange(lEntidade);
        Context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var entidade = Context.Set<T>().Find(id);
        if (entidade != null)
            Context.Set<T>().Remove(entidade);
       
        Context.SaveChanges();
    }

    public void DeleteRange(List<T> lEntidade)
    {
        Context.Remove(lEntidade);
        Context.SaveChanges();
    }
    
    public void Dispose() {}
}