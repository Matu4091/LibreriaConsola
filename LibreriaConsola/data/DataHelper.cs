using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LibreriaConsola.data
{
    internal class DataHelper
    {
        private static DataHelper? _instance;
        private string _connString;

        private DataHelper()
        {
            _connString = Properties.Resources.ConnectionChain;
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null )
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPRead(string sp, Parameter? p = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (p != null)
                        {
                            cmd.Parameters.AddWithValue(p.Name, p.Value);
                        }

                        dt.Load(cmd.ExecuteReader());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error With the Data Base: " + ex.Message);
                    throw;
                }
            }
            return dt;
        }

        public int ExecuteSPModify(string sp, List<Parameter> parameters)
        {
            int affectedRows;

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null && parameters.Count > 0)
                        {
                            foreach (Parameter p in parameters)
                            {
                                cmd.Parameters.AddWithValue(p.Name, p.Value);
                            }
                        }

                        affectedRows = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error With the Data Base: " + ex.Message);
                    throw;
                }

                return affectedRows;
            }
        }
    }
}
