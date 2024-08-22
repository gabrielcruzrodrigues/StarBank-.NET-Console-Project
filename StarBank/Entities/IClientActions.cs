using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Entities
{
    public interface IClientActions
    {
        public void AddValue(decimal value);
        public void RemoveValue(decimal value);
        public void SeeTotalValue();
    }
}
