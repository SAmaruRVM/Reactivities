using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public sealed class Create
    {
        public class Command : IRequest 
        {
            public Activity Activity { get; set; } 
        }
        public class Handler : IRequestHandler<Command>
        {
              private readonly DataContext _dataContext = default;     
            public Handler(DataContext dataContext) => (_dataContext) = (dataContext);

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken) 
            {
                _dataContext.Activities.Add(request.Activity); 
                await _dataContext.SaveChangesAsync();

                return Unit.Value; // <<-- void
            }
        }
    }
}