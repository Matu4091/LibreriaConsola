using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaConsola.data
{
    internal interface IRepository
    {
        List<object> GetAll();
        object GetById(int id);
        bool Save(object obj);
        bool Delete(int id);
    }
}
