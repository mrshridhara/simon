using System.Threading.Tasks;

namespace Simon.Domain.Process
{
    public interface IProcess<TContext, TResult>
    {
        Task<TResult> ProcessAsync(TContext context);
    }
    
    public interface IProcess<TContext>
    {
        Task ProcessAsync(TContext context);
    }
}
