using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Fsd_Mvc_Assign
{
    public class Helper
    {
        public static string ConString = "Data Source=RAM-PC\\SQLEXPRESS; Initial Catalog=CTSFSD; User id=ctsfsd;Password=ctsfsd;";
        SqlConnection con;
        SqlCommand cmd;
        private void OpenConnection()
        {
            if (con == null)
                con = new SqlConnection(ConString);
            con.Open();
        }

        private void CloseConnection()
        {
            if (con == null) return;
            con.Close();
            con.Dispose();
            con = null;
        }

        public Helper(string conStr)
        {
            ConString = conStr;
            cmd = new SqlCommand();
        }

        public IDataReader GetDataReader(string spName)
        {
            InitCommand(spName);

            try
            {
                OpenConnection();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetDataTable(string spName)
        {
            return GetDataTable(spName, null);
        }

        public DataTable GetDataTable(string spName, List<IDbDataParameter> parameters)
        {
            OpenConnection();
            InitCommand(spName, parameters);
            var da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            var ds = new DataSet();

            try
            {

                da.Fill(ds);
                return ds.Tables[0];
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateDb(string spName, List<IDbDataParameter> updateParams, DataTable newTable)
        {
            var da = new SqlDataAdapter();
            OpenConnection();
            InitCommand(spName, updateParams);
            da.UpdateCommand = cmd;
            try
            {
                da.Update(newTable.DataSet);
            }
            finally
            {
                CloseConnection();
            }
        }

        public IDataReader GetDataReader(string spName, List<IDbDataParameter> spParams)
        {
            try
            {
                OpenConnection();
                InitCommand(spName, spParams);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                CloseConnection();
                throw;
            }
        }


        public void ExecuteNonQuery(string spName, List<IDbDataParameter> spParams)
        {
            OpenConnection();
            InitCommand(spName, spParams);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public IDbDataParameter GetParameter(string name, string value)
        {
            return new SqlParameter(name, value);
        }

        public IDbDataParameter GetParameter(string name, SqlDbType type, int size, string sourceColumn)
        {
            return new SqlParameter(name, type, size, sourceColumn);
        }

        private void InitCommand(string spName)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Connection = con;
            cmd.Parameters.Clear();
        }

        private void InitCommand(string spName, List<IDbDataParameter> parameters)
        {
            InitCommand(spName);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
        }        

        public void DeleteDb(string spName, List<IDbDataParameter> updateParams, DataTable newTable)
        {
            var da = new SqlDataAdapter();
            OpenConnection();
            InitCommand(spName, updateParams);
            da.DeleteCommand = cmd;
            try
            {
                da.Update(newTable.DataSet);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void InsertDb(string spName, List<IDbDataParameter> updateParams, DataTable newTable)
        {
            var da = new SqlDataAdapter();
            OpenConnection();
            InitCommand(spName, updateParams);
            da.InsertCommand = cmd;
            try
            {
                da.Update(newTable.DataSet);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}