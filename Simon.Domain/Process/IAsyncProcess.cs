using System.Threading.Tasks;

namespace Simon.Domain.Process
{
    public interface IAsyncProcess<TContext, TResult>
    {
        Task<TResult> ProcessAsync(TContext context);
    }
    
    public interface IAsyncProcess<TContext>
    {
        Task ProcessAsync(TContext context);
    }
}
