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

        public Client FindById(int id)
        {
            return (Client) Program.Users.Where(user => user.Id == id).First();
        }

        public Client FindByName(string name)
        {
            if (name != null)
            {
                return (Client) Program.Users.Find(x => x.Name == name);
            }
            else
            {
                Message.Text("O nome para a busca não pode ser nulo.");
                return null;
            }
        }

        public void AddBalance(ref Client client, double value)
        {
            client.Balance += value;
        }

        public void WithDraw(ref Client client, double value)
        {
            client.Balance -= value;
        }
    }
}
