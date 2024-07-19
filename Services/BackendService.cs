using System.ComponentModel;
using ProjConsoleLanHouse.Data;

public static class BackendService
{
    public static bool ValidateLogin(string user, string password)
    {
        return user == "adm" && password == "123";
    }

    public static void AddNewClient(string name, string phone)
    {
        using (var context = new LanHouseContext())
        {
            if (context.Clients.Any(c => c.Phone == phone))
            {
                Console.WriteLine("Já existe um cliente com esse telefone.");
                return;
            }

            var newClient = new Client(name, phone);
            context.Clients.Add(newClient);
            context.SaveChanges();
        }
    }

    public static Client? GetClientByPhone(string phone)
    {
        using (var context = new LanHouseContext())
        {
            return context.Clients.FirstOrDefault(c => c.Phone == phone);
        }
    }

    public static void UpdateClientPhone(Client client, string newPhone)
    {
        using (var context = new LanHouseContext())
        {
            var existingClient = context.Clients.Find(client.Id);
            if (existingClient != null)
            {
                existingClient.Phone = newPhone;
                context.SaveChanges();
            }
        }
    }

    public static void RentDVD(Client client, DVD dvd)
    {
        using (var context = new LanHouseContext())
        {
            var existingDVD = context.DVDs.Find(dvd.Id);
            if (existingDVD != null && !existingDVD.IsRented)
            {
                existingDVD.IsRented = true;
                existingDVD.RentedBy = client;
                context.SaveChanges();
            }
        }
    }

    public static void ReleaseDVD(Client client, DVD dvd)
    {
        using (var context = new LanHouseContext())
        {
            var existingDVD = context.DVDs.Find(dvd.Id);
            if (existingDVD != null && existingDVD.RentedBy != null && existingDVD.RentedBy.Id == client.Id)
            {
                existingDVD.IsRented = false;
                existingDVD.RentedBy = null;
                context.SaveChanges();
            }
        }
    }

    public static List<DVD> GetRentedDVDs(Client client)
    {
        using (var context = new LanHouseContext())
        {
            return context.DVDs.Where(d => d.RentedBy != null && d.RentedBy.Id == client.Id).ToList();
        }
    }
}
