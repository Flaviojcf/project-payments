using Expert.Application.OutPutModels;
using MediatR;

namespace Expert.Application.Queries.GetUser
{
    public class GetUserQuery(int id) : IRequest<UserOutputModel>
    {
        public int Id { get; private set; } = id;
    }
}
