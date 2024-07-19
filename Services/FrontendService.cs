using System.ComponentModel;
using Azure.Core;
using ProjConsoleLanHouse.Data;

public enum MenuOption
{
    Rent = 1,
    Release,
    DisplayStatus,
    Exit,
    EspecificDesktop
}

public static class FrontendService
{
    public static void DisplayLogo()
    {
        Console.Clear();
        Console.WriteLine("\t=============================");
        Console.WriteLine("\t          LanhAlves          ");
        Console.WriteLine("\t=============================");
    }

    public static void Login()
    {
        while (true)
        {
            Console.WriteLine("-- usuário padrão: adm senha: 123 --\n");
            Console.Write("Usuário: ");
            string user = Console.ReadLine() ?? "None";
            Console.Write("Senha: ");
            string password = Console.ReadLine() ?? "None";

            bool is_logged = BackendService.ValidateLogin(user, password);

            if (is_logged)
            {
                Console.WriteLine("\n<< Usuário logado com sucesso! >>");
                Thread.Sleep(1700);
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("\n<< Usuário ou senha inválida! Tente novamente... >>");
                Thread.Sleep(1700);
                Console.Clear();
                DisplayLogo();
            }
        }
    }

    public static (MenuOption option, int desktopNumber) Menu()
    {
        while (true)
        {
            Console.Clear();
            DisplayLogo();

            Console.WriteLine("\n1 - Alugar um PC");
            Console.WriteLine("2 - Liberar um PC");
            Console.WriteLine("3 - Verificar status dos PCs");
            Console.WriteLine("4 - Locação de DVDs");
            Console.WriteLine("5 - Sair do programa");
            Console.Write("\nEscolha uma opção: ");

            string option = Console.ReadLine()?.Trim() ?? "";

            if (option == "1" || option == "2")
            {
                bool isRenting = option == "1";
                MenuOption action = isRenting ? MenuOption.Rent : MenuOption.Release;

                while (true)
                {
                    Console.Write($"Escolha o Desktop que deseja {(isRenting ? "Alugar" : "Liberar")} (ou digite 'sair' para voltar): ");
                    string input = Console.ReadLine()?.Trim() ?? "";

                    if (input.ToLower() == "sair")
                    {
                        break;
                    }

                    if (int.TryParse(input, out int optionNumber) && optionNumber > 0 && Enum.IsDefined(typeof(MenuOption), optionNumber))
                    {
                        return (action, optionNumber);
                    }
                    else
                    {
                        Console.WriteLine("Número inválido, tente novamente!");
                    }
                }

                // Após escolher o desktop e retornar, sair do loop interno para voltar ao menu principal
            }
            else if (option == "3")
            {
                return (MenuOption.DisplayStatus, 0); // Retorna a opção para exibir o status dos PCs
            }
            else if (option == "4")
            {
                Thread.Sleep(1700);
                Console.Clear();
                DisplayLogo();
                DVDRentMenu();
            }
            else if (option == "5")
            {
                Console.WriteLine("\nSaindo do programa...");
                Thread.Sleep(1000);
                return (MenuOption.Exit, 0);
            }
            else
            {
                Console.WriteLine("\n# Opção inválida. Tente novamente. #");
                Thread.Sleep(1500);
            }
        }
    }

    public static void DVDRentMenu()
    {
        Console.WriteLine("\nLocação de DVDs >>>>>\n");
        Console.Write("Digite o número do telefone do cliente\n(ou digite 'new' para cadastrar novo cliente): ");
        string phone = Console.ReadLine()?.Trim() ?? "";

        if (phone.ToLower() == "new")
        {
            // Cadastro de novo cliente
            Console.Write("Digite o nome do cliente: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Digite o número do telefone do cliente: ");
            string newPhone = Console.ReadLine()?.Trim() ?? "";

            // Adicionar novo cliente
            BackendService.AddNewClient(name, newPhone);
            var newClient = BackendService.GetClientByPhone(newPhone);

            if (newClient != null)
            {
                Thread.Sleep(1700);
                Console.Clear();

                ShowClientMenu(newClient);
            }
        }
        else
        {
            // Buscar cliente pelo telefone
            var client = BackendService.GetClientByPhone(phone);
            if (client != null)
            {
                Console.Write($"Cliente '{client.Name}' encontrado. Confirmar? (s/n): ");
                string confirmation = Console.ReadLine()?.Trim().ToLower() ?? "";
                if (confirmation == "s")
                {
                    Thread.Sleep(1700);
                    Console.Clear();

                    ShowClientMenu(client);
                }
                else
                {
                    Console.WriteLine("Operação cancelada.");
                }
            }
            else
            {
                Console.Write("Cliente não encontrado. Deseja cadastrar um novo cliente?(s/n): ");
                string confirmation = Console.ReadLine()?.Trim().ToLower() ?? "";
                if (confirmation == "s")
                {
                    // Cadastro de novo cliente
                    Console.Write("Digite o nome do cliente: ");
                    string name = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Confirme o número do telefone do cliente: ");
                    string newPhone = Console.ReadLine()?.Trim() ?? "";

                    // Adicionar novo cliente
                    BackendService.AddNewClient(name, newPhone);
                    var newClient = BackendService.GetClientByPhone(newPhone);

                    if (newClient != null)
                    {
                        Thread.Sleep(1700);
                        Console.Clear();

                        ShowClientMenu(newClient);
                    }

                }
            }
        }
    }

    public static void ShowClientMenu(Client client)
    {
        Console.WriteLine($"\n## Cliente: {client.Name} ##\n");
        Console.WriteLine("1. Atualizar Dados do Cliente");
        Console.WriteLine("2. Alugar DVD");
        Console.WriteLine("3. Devolver DVD");
        Console.WriteLine("4. Verificar DVDs alugados");
        Console.WriteLine("5. Sair");
        string option = Console.ReadLine()?.Trim() ?? "";

        switch (option)
        {
            case "1":
                Console.Write("Digite o novo número do telefone: ");
                string newPhone = Console.ReadLine()?.Trim() ?? "";
                BackendService.UpdateClientPhone(client, newPhone);
                break;
            case "2":
                // Lógica para alugar DVD
                // pode envolver listar DVDs disponíveis e permitir que o usuário escolha um para alugar
                break;
            case "3":
                // Lógica para devolver DVD
                //  pode envolver listar DVDs alugados pelo cliente e permitir que o usuário escolha um para devolver
                break;
            case "4":
                var rentedDVDs = BackendService.GetRentedDVDs(client);
                Console.WriteLine("DVDs alugados:");
                foreach (var dvd in rentedDVDs)
                {
                    Console.WriteLine($"- {dvd.Title}");
                }
                break;
            case "5":
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

}
