using System;
using System.Threading;
using MediatR;
using Persistence;
using System.Threading.Tasks;

namespace Application.Activities
{
    public sealed class Delete
    {
         public class Command : IRequest 
        {
            public Guid Id { get; set; } 
        }
        public class Handler : IRequestHandler<Command>
        {
              private readonly DataContext _dataContext = default;     
            public Handler(DataContext dataContext) => (_dataContext) = (dataContext);

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken) 
            {
                


                _dataContext.Activities.Remove(
                    entity: await _dataContext.Activities.FindAsync(request.Id)
                ); 
                await _dataContext.SaveChangesAsync();

                return Unit.Value; // <<-- void
            }
        }
    }
}