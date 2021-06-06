using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public sealed class List
    {
        public class Query : IRequest<List<Activity>>{}
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _dataContext = default;     
            public Handler(DataContext dataContext) => (_dataContext) = (dataContext);


            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken) => await _dataContext.Activities.AsNoTracking().ToListAsync();
        }
    }
}