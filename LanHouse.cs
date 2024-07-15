public class LanHouse
{

    private List<Desktop> desktops;

    // Construtor para inicializar a lan house com um número específico de PCs
    public LanHouse(int numberOfDesktop)
    {
        desktops = new List<Desktop>();

        for (int i = 0; i <= numberOfDesktop; i++)
        {
            desktops.Add(new Desktop(i)); // Cria cada PC com seu número
        }
    }

    // Método para alugar um Desktop
    public void RentDesktop(int number)
    {
        if (number >= 0 && number < desktops.Count)
        {
            desktops[number].Rent();
            Thread.Sleep(1500);
        }
        else
        {
            Console.WriteLine("\nNúmero de Desktop inválido.");
            Thread.Sleep(1500);
        }
    }
    // Método para liberar um Desktop
    public void ReleaseDesktop(int number)
    {
        if (number >= 0 && number < desktops.Count)
        {
            desktops[number].Release();
            Thread.Sleep(1500);
        }

        else
        {
            Console.WriteLine("\nNúmero de Desktop inválido.");
            Thread.Sleep(1500);
        }
    }
    // Método para exibir o status de todos os Desktops
    public void DisplayStatus()
    {

        Console.WriteLine("===================");
        foreach (var desktop in desktops)
        {
            if (desktop.Number != 0) // Ignora o desktop com número 0
            {
                string status = desktop.isOccupied ? "Ocupado" : "Livre";
                Console.WriteLine($"Desktop {desktop.Number}: {status}");
            }
        }

        Console.WriteLine("===================");
        Console.Write("Pressione qualquer tecla para continuar ");
        Console.ReadKey();

    }

}