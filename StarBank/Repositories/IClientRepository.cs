using StarBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Repositories
{
    public interface IClientRepository
    {
        public void Create(Client client);
        public void Update(Client client);
    }
}
