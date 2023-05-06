using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests.AccountRequests;
using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialManagementData.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseOption _dbOptions;

        public AccountRepository(DatabaseOption dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public DefaultResponse<Account> GetAccountById(AccountByIdRequest id)
        {
            var query = "SELECT * FROM Account WHERE Number = @id";
            var parameter = new Dictionary<string, object>() { { "@id", id.Id } };
            var response = GetAccount(query, parameter);
            return new DefaultResponse<Account>
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Insert(Account account)
        {
            var query = @"INSERT INTO Account  (Number, Username, Password, Date)
                          VALUES
                          (@number, @username, @password, @date)";
            var parameters = new Dictionary<string, object>
            {
                {"@number", account.Number},
                {"@username", account.Username },
                {"@password", account.Password },
                {"date", account.Date }
            };
            var response = ExecuteQuery(query, parameters);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        private DefaultResponse<Account> GetAccount(string query, Dictionary<string, object> parameter)
        {
            var result = new DefaultResponse<Account>();
            try
            {
                using var connection = new SqlConnection(_dbOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                connection.Open();
                var sqlParameters = parameter.Select(p => new SqlParameter(p.Key, p.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                using var reader = command.ExecuteReader();
                if (reader?.Read() == true)
                {
                    var account = new Account()
                    {
                        Number = reader.GetInt32("Number"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Date = reader.GetDateTime("Date")
                    };
                    result.Data = account;
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        private DefaultResponse<int> ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            var response = new DefaultResponse<int>();
            try
            {
                using var connection = new SqlConnection(_dbOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                connection.Open();
                var sqlParameters = parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                response.Data = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}

