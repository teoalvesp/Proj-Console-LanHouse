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
}