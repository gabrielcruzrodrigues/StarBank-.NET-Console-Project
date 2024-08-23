using StarBank.Display;
using StarBank.Entities;
using StarBank.Repositories;
using StarBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Services
{
    public class ClientService
    {
        public VerifyFieldType VerifyFieldType = new VerifyFieldType();
        public ClientRepository ClientRepository;
        public ClientService()
        {
            this.ClientRepository = new ClientRepository();
        }

        public void CreateClient()
        {
            Message.Text("Preencha os campos abaixo para criar a sua conta!");

            string? name;
            do
            {
                Message.Text("Qual o seu nome?");
                name = Console.ReadLine();
                if (!Verify(name, 1))
                {
                    Message.Text("Resposta inválida, tente novamente.");
                    name = null;
                }

                if (Program.Users.Any(user => user.Name == name))
                {
                    Message.Text("O nome de usuário já existe, tente novamente!");
                    name = null;
                }
            }
            while (!Verify(name, 1) && !Program.Users.Any(user => user.Name == name));

            string? age;
            do
            {
                Message.Text("Quantos anos você tem?");
                age = Console.ReadLine();
                if (!Verify(age, 2))
                {
                    Message.Text("Resposta inválida, tente novamente!");
                    age = null;
                }
            }
            while (!Verify(age, 2));

            string? password;
            do
            {
                Message.Text("Crie uma senha para acessar a sua conta.");
                password = Console.ReadLine();
                if (!VerifyPassword(password))
                {
                    Message.Text("Sua senha não pode ser nula ou menor que 5 caracteres. Tente novamente!");
                    password = null;
                }
            }
            while (!VerifyPassword(password));

            int id = GetAvaliableId();
            Client newClient = new Client(id, name, Convert.ToInt32(age), password);

            ClientRepository.Create(newClient);
        }

        public Client findById(int id)
        {
            Client client = (Client) Program.Users.Where(user => user.Id == id).First();
            if (client == null)
            {
                Message.Text("Ocorreu um erro ao buscar o usuário por Id.");
                Menu.LoggedMenu();
                return null;
            } 
            else
            {
                return client;
            }
        }

        public void SeeTotalValue(int id)
        {
            Client client = findById(id);
            Message.Text($"Seu saldo é de: {client.Balance}!");
            Menu.LoggedMenu();
        }

        public void Deposit(int id)
        {
            Client client = this.findById(id);

            Message.Text("Quanto você gostaria de depositar?");
            decimal value = Convert.ToDecimal(Console.ReadLine());

            client.Balance += value;

            Message.Text($"Seu saldo é de: {client.Balance}!");

            Menu.LoggedMenu();
        }

        public void SeeAllLimit(int id)
        {
            Client client = this.findById(id);
            Message.Text($"O seu limite é de: {client.CreditLimit}!");
            Menu.LoggedMenu();
        }

        private bool Verify(string input, int type)
        {
            return this.VerifyFieldType.VerifyType(input, type);
        }

        private bool VerifyPassword(string password)
        {
            return !(password == null || password.Length < 5);
        }

        private int GetAvaliableId()
        {
            if (Program.Users.Count == 0)
            {
                return 1;
            }

            List<int> ids = new();

            foreach (var user in Program.Users)
            {
                ids.Add(user.Id);
            }

            return ids.Max() + 1;
        }
    }
}