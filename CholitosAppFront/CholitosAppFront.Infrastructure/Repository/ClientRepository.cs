using AutoMapper;
using CholitosAppFront.Core.Domain;
using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Interfaces;
using CholitosAppFront.Infrastructure.Queries;
using Dapper;
using System.Data;

namespace CholitosAppFront.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConnectionManagerRepository _connectionManagerRepository;
        private readonly IMapper _mapper;
        private readonly IProperties _properties;

        private readonly IDbConnection _dbConnection;

        public ClientRepository(IConnectionManagerRepository connectionManagerRepository, IMapper mapper, IProperties properties)
        {
            _connectionManagerRepository = connectionManagerRepository ?? throw new ArgumentNullException(nameof(connectionManagerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));

            _dbConnection = _connectionManagerRepository.OpenAndReturnConnectionOfDatabase();
        }

        public async Task<List<ClientDto>> GetAllClients() {
                string query = ClientQuery.GetAllClients();
                var clientsDb = await _dbConnection.QueryAsync<ClientDomain>(query);
                var dataMappedClients = _mapper.Map<List<ClientDomain>, List<ClientDto>>(clientsDb.ToList());
                return dataMappedClients;
            }                
        }
    }
