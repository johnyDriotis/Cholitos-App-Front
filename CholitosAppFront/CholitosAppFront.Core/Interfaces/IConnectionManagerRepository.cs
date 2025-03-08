using CholitosAppFront.Core.DTOs;
using System.Data;
using System.Data.SqlClient;

namespace CholitosAppFront.Core.Interfaces
{
    public interface IConnectionManagerRepository
    {
        string ConnectToDatabaseWithMessage();
        IDbConnection OpenAndReturnConnectionOfDatabase();
        void CloseConnectionToDatabase();
    }
}
