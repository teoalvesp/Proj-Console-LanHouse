
public static class Display
{
    public static void Init()
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

            bool is_logged = Validation.ValidateLogin(user, password);

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
                Thread.Sleep(2000);
                Console.Clear();
                Init();
            }
        }

    }

    public static void Menu()
    {
        Console.WriteLine("\n1 - ");
    }

}

