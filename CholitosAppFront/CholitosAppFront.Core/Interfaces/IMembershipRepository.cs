using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Response;
using CholitosAppFront.Core.Request;

namespace CholitosAppFront.Core.Interfaces
{
    public interface IMembershipRepository
    {
        Task<GenericResponse<MembershipDto>> AddMembership(MerbershipRequest membershipRequest);
    }
}
