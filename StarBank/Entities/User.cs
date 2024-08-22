using StarBank.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public StatusClientEnum StatusClient { get; set; }
        public string? Password { get; set; }
        public decimal Balance { get; set; }
    }
}
