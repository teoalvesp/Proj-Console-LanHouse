public class Desktop
{
    public int Number { get; set; }
    public bool isOccupied { get; set; }

    public Desktop(int number)
    {
        Number = number;
        isOccupied = true;
    }

    // método para alugar o Desktop
    public void Rent()
    {
        if (!isOccupied)
        {
            isOccupied = true;
            Console.WriteLine($"O Desktop {Number} foi Alugado!");
        }
        else
        {
            Console.WriteLine($"Desktop {Number} já ocupado!");
        }
    }

    // método para liberar um desktop
    public void Release()
    {
        if (isOccupied)
        {
            isOccupied = false;
            Console.WriteLine($"O Desktop {Number} foi Liberado!");
        }
        else
        {
            Console.WriteLine($"O Desktop {Number} já está livre.");
        }
    }

}

