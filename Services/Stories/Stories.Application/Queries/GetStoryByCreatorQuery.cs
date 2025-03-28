using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Application.Responses;

namespace Stories.Application.Queries
{
    public class GetStoryByCreatorQuery : IRequest<IList<GetStoryResponse>>
    {
        public string NickName { get; set; }
    }
}
