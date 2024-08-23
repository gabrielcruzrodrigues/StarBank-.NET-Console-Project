using StarBank.Display;
using StarBank.Entities;
using StarBank.Repositories;
using StarBank.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                if (!VerifyIfIsString(name))
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
            while (!VerifyIfIsString(name) && !Program.Users.Any(user => user.Name == name));

            string? age;
            do
            {
                Message.Text("Quantos anos você tem?");
                age = Console.ReadLine();
                if (!VerifyIfIsANumber(age))
                {
                    Message.Text("Resposta inválida, tente novamente!");
                    age = null;
                }
            }
            while (!VerifyIfIsANumber(age));

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

            Menu.LoggedMenu();
        }

        public Client FindById(int id)
        {
            Client client = ClientRepository.FindById(id);
            if (client == null)
            {
                Message.Text("O usuário não existe.");
                Menu.InitialMenu();
                return null;
            } 
            else
            {
                return client;
            }
        }

        public Client FindByName(string name)
        {
            Client client = ClientRepository.FindByName(name);
            if (client == null)
            {
                Message.Text("O usuário não existe, tente novamente!");
                Menu.InitialMenu();
                return null;
            } 
            else
            {
                return client;
            }
        }

        public void SeeTotalValue(int id)
        {
            Client client = FindById(id);
            Message.Text($"Seu saldo é de: R${client.Balance:F2}!");
            Menu.LoggedMenu();
        }

        public void Deposit(int id)
        {
            Client client = FindById(id);

            Message.Text("Quanto você gostaria de depositar?");
            double value = Convert.ToDouble(Console.ReadLine());

            ClientRepository.AddBalance(ref client, value);

            Message.Text($"Seu saldo é de: R${client.Balance:F2}!");

            Menu.LoggedMenu();
        }

        public void WithDraw(int id) 
        {
            Client client = FindById(id);
            
            Message.Text("Quanto você gostaria de sacar?");
            var value = Convert.ToDouble(Console.ReadLine());
            if (value <= client.Balance)
            {
                ClientRepository.WithDraw(ref client, value);
                Message.Text($"Você sacou R${value:F2}, agora você tem R${client.Balance:F2} em sua conta!");
            }
            else {
                Message.Text($"Você tem apenas R${client.Balance:F2} em sua conta, tente outro valor!");
            }
            Menu.LoggedMenu();
        }

        public void Login()
        {
            Message.Text("Digite o nome da sua conta:");
            string? name = Console.ReadLine();

            if (name == null || !VerifyFieldType.VerifyType(name, 1)) {
                Message.Text("Nome inválido, tente novamente!");
                Menu.InitialMenu();
                return;
            }
            
            Client client = FindByName(name);

            Message.Text("Digite a sua senha:");
            string? password = Console.ReadLine();

            if (name == null) {
                Message.Text("Nome inválido, tente novamente!");
                Menu.InitialMenu();
                return;
            }

            if (client.Password == password) {
                Program.LoggedUser = client.Id;
                Message.Text($"Bem vindo de volta {client.Name}!");
                Menu.LoggedMenu();
                return;
            }
            else
            {
                Message.Text("Credenciais incorretas, tente novamente!");
                Menu.InitialMenu();
                return;
            }
        }

        private bool VerifyIfIsString(string input)
        {
            if (input != null && input.Length > 0)
            {
                return input.All(x => char.IsLetter(x) || !char.IsDigit(x));
            }
            return false;
        }

        private bool VerifyIfIsANumber(string input)
        {
            if (input != null && input.Length > 0)
            {
                return input.All(x => char.IsDigit(x) || !char.IsLetter(x));
            }
            return false;
        }

        private bool VerifyPassword(string password)
        {
            return !(password == null || password.Length < 5);
        }

        private int GetAvaliableId()
        {
            return Program.Users.Any() ? Program.Users.Max(user => user.Id) + 1 : 1;
        }
    }
}