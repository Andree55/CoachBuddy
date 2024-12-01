using MediatR;

namespace CoachBuddy.Application.Group.Queries.GetGroupDetails
{
    public class GetGroupDetailsQuery:IRequest<GroupDto>
    {
        public string EncodedName { get; }

        public GetGroupDetailsQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}

