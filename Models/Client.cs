public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DVD> RentedDVDs { get; set; }

    public Client(int id, string name)
    {
        Id = id;
        Name = name;
        RentedDVDs = new List<DVD>();
    }

    public void RentDVD(DVD dvd)
    {
        if (!dvd.IsRented)
        {
            dvd.Rent(this);
            RentedDVDs.Add(dvd);
        }
        else
        {
            Console.WriteLine($"O DVD '{dvd.Title}' já está alugado.");
        }
    }

    public void ReleaseDVD(DVD dvd)
    {
        if (RentedDVDs.Contains(dvd))
        {
            dvd.Release();
            RentedDVDs.Remove(dvd);
        }
        else
        {
            Console.WriteLine($"O DVD '{dvd.Title}' não está alugado por este cliente.");
        }
    }
}
