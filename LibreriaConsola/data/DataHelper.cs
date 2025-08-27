using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataHelper GetInstance()
        {
            if (_instance == null )
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPRead(string sp, int id = 0)
        {
            using (Sqlc)
        }

        public int ExecuteSPModify(string sp, List<Parameter> parameters)
        {

        }
    }
}
