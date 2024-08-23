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
            try
            {
                Program.Users.Add(client);
                Message.Text("Usuário salvo com sucesso!");
                Program.LoggedUser = client.Id;
            }
            catch (Exception)
            {
                Message.Text("O cliente a ser salvo não pode ser nulo. Tente novamente!");
                Menu.InitialMenu();
            }
        }

        public Client FindById(int id)
        {
            try 
            {
                return (Client) Program.Users.Where(user => user.Id == id).First();
            }
            catch (Exception)
            {
                Message.Text("Houve um erro ao tentar buscar o cliente pelo id.");
                Menu.LoggedMenu();
                return null;
            }
        }

        public Client FindByName(string name)
        {
            try
            {
                return (Client) Program.Users.Find(x => x.Name == name);
            }
            catch(Exception)
            {
                Message.Text("Ouve um erro ao tentar buscar o usuário pelo nome.");
                Menu.InitialMenu();
                return null;
            }
        }

        public void AddBalance(ref Client client, double value)
        {
            try 
            {
                client.Balance += value;
            }
            catch(Exception)
            {
                Message.Text("Ouve um erro ao tentar fazer um deposito.");
                return;
            }
        }

        public void WithDraw(ref Client client, double value)
        {
            try
            {
                client.Balance -= value;
            }
            catch(Exception)
            {
                Message.Text("Ouve um erro ao tentar fazer um saldo.");
                return;
            }
        }
    }
}
