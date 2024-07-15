public class Desktop
{
    public int Number { get; set; }
    public bool isOccupied { get; set; }

    public Desktop(int number)
    {
        Number = number;
        isOccupied = false;
    }

    // método para alugar o Desktop
    public void Rent()
    {
        if (!isOccupied)
        {
            isOccupied = true;
            Console.WriteLine($"\n>>Desktop {Number} Alugado!");
        }
        else
        {
            Console.WriteLine($"\n>> Desktop {Number} já ocupado!");
        }
    }

    // método para liberar um desktop
    public void Release()
    {
        if (isOccupied)
        {
            isOccupied = false;
            Console.WriteLine($"\n>> Desktop {Number} Liberado!");
        }
        else
        {
            Console.WriteLine($"\n>> Desktop {Number} já está livre.");
        }
    }

}

