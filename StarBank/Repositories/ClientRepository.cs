using StarBank.Display;
using StarBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public void Create(Client client)
        {
            if (client != null)
            {
                Program.Users.Add(client);
                Message.Text("Usuário salvo com sucesso!");
                Program.LoggedUser = client.Id;
                Menu.LoggedMenu();
            } 
            else
            {
                Message.Text("O cliente a ser salvo não pode ser nulo. Tente novamente!");
                Menu.InitialMenu();
            }
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
