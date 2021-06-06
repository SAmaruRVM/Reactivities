using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Domain;

namespace Application.Activities
{
    public sealed class Details
    {
        public class Query : IRequest<Activity> 
        {
            public Guid Id { get; set; }


        }

        public class Handler : IRequestHandler<Query, Activity>
        {

            private readonly DataContext _dataContext = default;     
            public Handler(DataContext dataContext) => (_dataContext) = (dataContext);



            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken) => await _dataContext.Activities.FindAsync(request.Id);
        }

    }
}