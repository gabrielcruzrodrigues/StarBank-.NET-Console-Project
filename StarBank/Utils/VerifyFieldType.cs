using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Utils
{
    public class VerifyFieldType
    {
        public bool VerifyType(string field, int type)
        {
            if (field == null)
            {
                return false;
            }

            switch (type)
            {
                case 1: //string
                    return field.All(char.IsLetter) ? true : false;
                case 2: //int
                    return field.All(char.IsNumber) ? true : false;
                default:
                    Console.WriteLine("Aconteceu um erro ao verificar o tipo de entrada.");
                    break;
            }
            return false;
        }
    }
}
