using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TuChance.Helpers;

namespace TuChance.Library
{
    public class MsSqlExtensions
    {
        private readonly AppSettings _appSettings;

        public MsSqlExtensions(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public DataTable ExecuteDataTable(string procedureName, params SqlParameter[] parameters)
        {
            SqlConnection cnn = new SqlConnection(_appSettings.ConnectionStringDatabase);
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            if(parameters!=null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            cnn.Open();
            SqlDataReader dtr = cmd.ExecuteReader();
            DataTable rtn = new DataTable();
            rtn.Load(dtr);
            cnn.Close();
            return rtn;
        }

        public SqlParameter[] ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {
            SqlConnection cnn = new SqlConnection(_appSettings.ConnectionStringDatabase);
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            SqlParameter[] rtn = parameters.Where(x => x.Direction.Equals(ParameterDirection.Output)).ToArray();
            return rtn;
        }
    }
}
