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
                Thread.Sleep(2000);
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
            DisplayLogo();

            Console.WriteLine("\n1 - Alugar um PC");
            Console.WriteLine("2 - Liberar um PC");
            Console.WriteLine("3 - Verificar status dos PCs");
            Console.WriteLine("4 - Sair do programa");
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
                        break; // Sair do loop interno e voltar para o menu principal
                    }

                    if (int.TryParse(input, out int optionNumber) && optionNumber > 0 && Enum.IsDefined(typeof(MenuOption), optionNumber))
                    {
                        return (action, optionNumber); // Retornar a ação e o número do desktop escolhido
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
                Console.WriteLine("\nSaindo do programa...");
                Thread.Sleep(1000);
                return (MenuOption.Exit, 0); // Não precisa de número de desktop para sair do programa
            }
            else
            {
                Console.WriteLine("\n# Opção inválida. Tente novamente. #");
                Thread.Sleep(1500);
            }
        }
    }

}
