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
        public ClientService ClientService;
        public Message Message;

        public Menu()
        {
            this.ClientService = new();
            this.Message = new();
        }

        public void InitialMenu()
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
                this.Message.Text("Opção invalida, tente novamente!");
                option = null;
                this.InitialMenu();
            }

            int selected = Convert.ToInt32(option);

            switch (selected)
            {
                case 1:
                    this.ClientService.CreateClient();
                    break;
                case 2:
                    //this.Client.Login();
                    break;
                case 3:
                    this.Message.Text("Saindo do Star Bank, até a próxima!");
                    Environment.Exit(0);
                    break;
                default:
                    this.Message.Text("Aconteceu um erro interno...");
                    break;
            }
        }

        public void LoggedMenu()
        {
            Console.WriteLine("Usuário logado");
            var option = Console.ReadLine();
        }
    }
}
