public class DVD
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public bool IsRented { get; set; }
    public Client? Client { get; set; }

    public DVD(int id, string title, string genre, int duration)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Duration = duration;
        IsRented = false;
        Client = null;
    }

    public void Rent(Client client)
    {
        if (!IsRented)
        {
            IsRented = true;
            Client = client;
            Console.WriteLine($"The DVD '{Title}' was rented by {client.Name}.");
        }
        else
        {
            Console.WriteLine($"The DVD '{Title}' is already rented.");
        }
    }

    public void Release()
    {
        if (IsRented)
        {
            IsRented = false;
            Console.WriteLine($"The DVD '{Title}' was returned by {Client?.Name}.");
            Client = null;
        }
        else
        {
            Console.WriteLine($"The DVD '{Title}' is not rented.");
        }
    }
}
