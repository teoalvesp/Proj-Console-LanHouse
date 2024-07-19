public class DVD
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public bool IsRented { get; set; }
    public int? RentedById { get; set; } // Chave estrangeira
    public Client? RentedBy { get; set; }

    public DVD(int id, string title, string genre, int duration)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Duration = duration;
        IsRented = false;
        RentedBy = null;
    }

    public void Rent(Client client)
    {
        if (!IsRented)
        {
            IsRented = true;
            RentedBy = client;
            Console.WriteLine($"O DVD '{Title}' foi alugado por {client.Name}.");
        }
        else
        {
            Console.WriteLine($"O DVD '{Title}' já está alugado.");
        }
    }

    public void Release()
    {
        if (IsRented)
        {
            Console.WriteLine($"O DVD '{Title}' foi devolvido por {RentedBy?.Name}.");
            IsRented = false;
            RentedBy = null;
        }
        else
        {
            Console.WriteLine($"O DVD '{Title}' não está alugado.");
        }
    }
}