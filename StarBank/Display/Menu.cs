using StarBank.Entities;
using StarBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Display
{
    public class Menu
    {
        public Menu()
        { }

        public static void InitialMenu()
        {

            string initialMenu = @"
****************************************************
*                    Star Bank                     *        
*      Seja muito bem vindo ao nosso banco!        *
*                                                  *
*               * Menu Principal *                 *
*                                                  *
*    1 - Criar uma conta.                          *
*    2 - Entrar na minha conta.                    *
*    3 - Sair.                                     *
*                                                  *
*   * Digite a opção selecionada abaixo.           *
*                                                  *
****************************************************
            ";

            Console.WriteLine(initialMenu);
            var option = Console.ReadLine();

            if (option != "1" && option != "2" && option != "3")
            {
                Message.Text("Opção invalida, tente novamente!");
                option = null;
                InitialMenu();
            }

            int selected = Convert.ToInt32(option);

            ClientService clientService = new();
            switch (selected)
            {
                case 1:
                    clientService.CreateClient();
                    break;
                case 2:
                    //this.Client.Login();
                    break;
                case 3:
                    Message.Text("Saindo do Star Bank, até a próxima!");
                    Environment.Exit(0);
                    break;
                default:
                    Message.Text("Aconteceu um erro interno...");
                    break;
            }
        }

        public static void LoggedMenu()
        { 
            string LoggedMenuText = @"
****************************************************
*                    Star Bank                     *        
*          No que podemos te ajudar hoje?          *                 
*                                                  *
*    1 - Ver o valor total na conta.               *
*    2 - Depositar valor.                          *
*    3 - Sacar valor                               *
*    4 - Ver meu limite.                           *
*    5 - Solicitar mais limite.                    *
*    6 - Deslogar da conta.                        *                 
*                                                  *
*   * Digite a opção selecionada abaixo.           *
*                                                  *
****************************************************
            ";

            Console.WriteLine(LoggedMenuText);
            var option = Console.ReadLine();

            List<string> options = [ "1", "2", "3", "4", "5", "6" ];

            if (!options.Contains(option))
            {
                Message.Text("Opção invalida, tente novamente!");
                option = null;
                LoggedMenu();
            }
            int selected = Convert.ToInt32(option);
            int idLoggedUser = Program.LoggedUser;

            ClientService clientService = new();
            switch (selected)
            {
                case 1:
                    clientService.SeeTotalValue(idLoggedUser);
                    break;
                case 2:
                    clientService.Deposit(idLoggedUser);
                    break;
                case 3:
                    break;
                case 4:
                    clientService.SeeAllLimit(idLoggedUser);
                    break;
                case 5:
                    break;
                case 6:
                    Program.LoggedUser = 0;
                    Message.Text("Deslogando da sua conta, volte sempre!");
                    InitialMenu();
                    break;
                default:
                    Message.Text("Aconteceu um erro interno...");
                    break;
            }
        }
    }
}
