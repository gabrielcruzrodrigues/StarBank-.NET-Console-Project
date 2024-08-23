﻿using StarBank.Entities;
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
            string LoggedMenu = @"
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

            Console.WriteLine(LoggedMenu);
            var option = Console.ReadLine();

            List<string> options = [ "1", "2", "3", "4", "5", "6" ];

            if (!options.Contains(option))
            {
                this.Message.Text("Opção invalida, tente novamente!");
                option = null;
                this.LoggedMenu();
            }
            int selected = Convert.ToInt32(option);
            int idLoggedUser = Program.LoggedUser;

            switch (selected)
            {
                case 1:
                    this.ClientService.SeeTotalValue(idLoggedUser);
                    break;
                case 2:
                    this.ClientService.Deposit(idLoggedUser);
                    break;
                case 3:
                    break;
                case 4:
                    this.ClientService.SeeAllLimit(idLoggedUser);
                    break;
                case 5:
                    break;
                case 6:
                    Program.LoggedUser = 0;
                    this.Message.Text("Deslogando da sua conta, volte sempre!");
                    Menu menu = new();
                    menu.InitialMenu();
                    break;
                default:
                    this.Message.Text("Aconteceu um erro interno...");
                    break;
            }
        }
    }
}
