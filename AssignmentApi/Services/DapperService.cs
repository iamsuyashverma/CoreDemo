using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace AssignmentApi.Services
{
    public class DapperService
    {
        private IConfiguration configuration;
        static IDbConnection db;
        public DapperService(IConfiguration configuration) 
        {
            this.configuration = configuration;
            db = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
        }
        

        public void AddUser()
        {
            var parameter = new DynamicParameters();
            db.Execute("SaveContact", parameter, commandType: CommandType.StoredProcedure);
        }

        public void GetUser(long UserId)
        {
            using (var multipleresult = db.QueryMultiple("sp_GetContact_Address", new { id = UserId }, commandType: CommandType.StoredProcedure))
            {
                //var contact = multipleresult.Read<Contact>().SingleOrDefault();
                //var Addresses = multipleresult.Read<Address>().ToList();
                //if (contact != null && Addresses != null)
                //{
                //    contact.Addresses.AddRange(Addresses);
                //}
            }

        }
    }
}
