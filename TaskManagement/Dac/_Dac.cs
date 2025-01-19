using Dapper;
using Microsoft.Data.SqlClient;

namespace TaskManagement.Dac
{
    public class _Dac
    {
        private readonly IConfiguration _configuration;

        public _Dac(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 取得連線字串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Dapper.QueryAsync的泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IList<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                try
                {
                    var result = await conn.QueryAsync<T>(sql, parameters);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new List<T>();
                }
            }
        }
        /// <summary>
        /// Dapper.ExecuteAsync的泛型
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                return await conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}

