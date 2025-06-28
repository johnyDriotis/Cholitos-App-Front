using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;

namespace CholitosAppFront.Core.UseCases.Interfaces
{
    public interface IMembershipUseCase
    {
        Task<GenericResponse<MembershipDto>> AddMembership(MerbershipRequest membershipRequest);
    }
}
