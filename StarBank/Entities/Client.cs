using StarBank.Display;
using StarBank.Enums;
using StarBank.Services;
using StarBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Entities
{
    public class Client : User, IClientActions
    {
        public bool Active { get; set; }

        public Client()
        { }

        public Client(int id, string name, int age, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.StatusClient = StatusClientEnum.POSITIVE;
            this.Password = password;
            this.Active = true;
            this.Balance = 0.0d;
            this.CreatedAt = DateTime.UtcNow;
        }

        public void AddValue(decimal value)
        {
            throw new NotImplementedException();
        }

        public void RemoveValue(decimal value)
        {
            throw new NotImplementedException();
        }

        public void SeeTotalValue()
        {
            Message.Text($"O saldo total é de: {this.Balance:2F}!");
        }
    }
}
