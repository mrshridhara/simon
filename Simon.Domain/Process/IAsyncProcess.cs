using System.Threading.Tasks;

namespace Simon.Domain.Process
{
    public interface IAsyncProcess<TContext, TResult>
    {
        Task<TResult> ExecuteAsync(TContext context);
    }
    
    public interface IAsyncProcess<TContext>
    {
        Task ExecuteAsync(TContext context);
    }
}
