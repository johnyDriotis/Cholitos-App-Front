using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Interfaces;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;
using CholitosAppFront.Core.UseCases.Interfaces;

namespace CholitosAppFront.Core.UseCases
{
    public class MembershipUseCase : IMembershipUseCase
    {
        private readonly IMembershipRepository _membershipRepository;
        public MembershipUseCase(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository ?? throw new ArgumentNullException(nameof(membershipRepository));
        }

        public async Task<GenericResponse<MembershipDto>> AddMembership(MerbershipRequest membershipRequest)
        {
            var response = await _membershipRepository.AddMembership(membershipRequest);
            return response;
        }
    }
}
