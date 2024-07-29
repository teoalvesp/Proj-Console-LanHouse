public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<DVD> RentedDVDs { get; set; }

    public Client(string name, string phone)
    {
        Name = name;
        Phone = phone;
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
            RentedDVDs.Remove(dvd); // Remove o DVD da lista de DVDs alugados pelo cliente
        }
        else
        {
            Console.WriteLine($"O DVD '{dvd.Title}' não está alugado por este cliente.");
        }
    }

}
