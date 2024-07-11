
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
            Console.WriteLine("--usuario padrão: adm senha: 123--\n");
            Console.Write("Usuario: ");
            string user = Console.ReadLine() ?? "None";
            Console.Write("Senha: ");
            string password = Console.ReadLine() ?? "None";

            bool is_logged = BackendService.ValidateLogin(user, password);

            if (is_logged)
            {
                Console.WriteLine("\n<< Usuario logado com Sucesso! >>");
                Thread.Sleep(2000);
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("\n<< Usuario ou Senha inválida! tente de novo.. >>");
                Thread.Sleep(1700);
                Console.Clear();
                DisplayLogo();
            }
        }

    }


    public static void Menu()
    {
        while (true)
        {
            DisplayLogo();

            Console.WriteLine("\n1 - Alugar um PC");
            Console.WriteLine("2 - Liberar um PC");
            Console.WriteLine("3 - Verificar status dos PCs");
            Console.WriteLine("4 - Sair do programa");
            Console.Write("\nEscolha uma opção: "); ;

            string option = Console.ReadLine() ?? "None";

            if (option == "1")
            {
                Console.WriteLine("Escolheu a opção 1");
                break;
            }
            else if (option == "2")
            {
                Console.WriteLine("Escolheu a opção 2");
                break;
            }
            else if (option == "3")
            {
                Console.WriteLine("Escolheu a opção 3");
                break;
            }
            else if (option == "4")
            {
                Console.WriteLine("\nSaindo do programa...");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                Console.WriteLine("\n# Opção inválida. Tente novamente. #");
                Thread.Sleep(1500);
                Console.Clear();
            }


        }

    }

}

