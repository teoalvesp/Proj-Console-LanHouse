public class Client
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<DVD>? DVDsAlugados { get; set; }

    public Client(int id, string? name)
    {
        Id = id;
        Name = name;
        DVDsAlugados = new List<DVD>();
    }

    public void RentDVD(DVD dvd)
    {
        if (!dvd.ItsRented)
        {
            dvd.Rent();
            DVDsAlugados.Add(dvd);
        }
        else
        {
            Console.WriteLine($"O DVD {dvd.title} já está alugado.");
        }
    }

    public void ReleaseDVD(DVD dvd)
    {
        if (DVDsAlugados.Contains(dvd))
        {
            dvd.Release();
            DVDsAlugados.Remove(dvd);
        }
        else
        {
            Console.WriteLine($"O DVD {dvd.title} não está alugado por este cliente.");
        }
    }
}