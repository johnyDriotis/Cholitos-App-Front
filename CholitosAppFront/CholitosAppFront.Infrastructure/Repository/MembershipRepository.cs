using AutoMapper;
using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Interfaces;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;
using CholitosAppFront.Core.Utils;
using CholitosAppFront.Infrastructure.Queries;
using Dapper;
using System.Data;
using System.Diagnostics;

namespace CholitosAppFront.Infrastructure.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly IConnectionManagerRepository _connectionManagerRepository;
        private readonly IDbConnection _dbConnection;       

        public MembershipRepository(IConnectionManagerRepository connectionManagerRepository, IMapper mapper, IProperties properties)
        {
            _connectionManagerRepository = connectionManagerRepository ?? throw new ArgumentNullException(nameof(connectionManagerRepository));
            _dbConnection = _connectionManagerRepository.OpenAndReturnConnectionOfDatabase();
        }

        public async Task<GenericResponse<MembershipDto>> AddMembership(MerbershipRequest membershipRequest)
        {
            try
            {
                string codeGym = ClientUtils.GenerateGymCode(5);

                string query = MembershipQuery.AddMembership();
                int res = await _dbConnection.ExecuteAsync(query, new
                {
                    IdCliente = membershipRequest.IdCliente,
                    FechaPago = membershipRequest.FechaPago,
                    FechaInicio = membershipRequest.FechaInicio,
                    FechaFin = membershipRequest.FechaFin,
                    Tipo = membershipRequest.Tipo
                });

                return new GenericResponse<MembershipDto>()
                {
                    GeneroError = false,
                    Item = new MembershipDto()
                    {
                        IdCliente = membershipRequest.IdCliente,
                        FechaPago = membershipRequest.FechaPago,
                        FechaInicio = membershipRequest.FechaInicio,
                        FechaFin = membershipRequest.FechaFin,
                        Tipo = membershipRequest.Tipo
                    }
                };

            }
            catch (Exception ex)
            {
                Trace.WriteLine("MembershipRepository - AddMembership - Ocurrio un error al guardar la membresia: " + ex.Message);

                return new GenericResponse<MembershipDto>()
                {
                    GeneroError = true,
                    ErrorGenerado = ex.Message
                };
            }

        }
    }
}
