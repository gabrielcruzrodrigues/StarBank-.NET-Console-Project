using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Entities
{
    public interface IBankActions
    {
        public void ChangeStatusClient(string username);
    }
}
