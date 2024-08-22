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
        Message Message = new();
        public void Create(Client client)
        {
            if (client != null)
            {
                Program.Users.Add(client);
                this.Message.Text("Usuário salvo com sucesso!");
                Menu menu = new();
                menu.LoggedMenu();
            } 
            else
            {
                Menu Menu = new();
                this.Message.Text("O cliente a ser salvo não pode ser nulo. Tente novamente!");
                Menu.InitialMenu();
            }
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
