using System.Data.Entity;
using System.Linq;
using CarRental.Model;

namespace CarRental
{
    public class Database
    {
        public static Database Instance { get; private set; }
        
        public DatabaseContext DatabaseContext { get; set; }

        public Database()
        {
            DatabaseContext = new DatabaseContext();
            Instance = this;
        }

        public static void RemoveClient(Client client)
        {
            Instance = new Database();
            
            Instance.DatabaseContext.Clients.Load();
            Instance.DatabaseContext.Rentals.Load();

            Rental clientRental = Instance.DatabaseContext.Rentals.FirstOrDefault(r => r.Client.Id == client.Id);
            if (clientRental is null == false)
                Instance.DatabaseContext.Rentals.Remove(Instance.DatabaseContext.Rentals.First(r => r.Client.Id == client.Id));
                
            Instance.DatabaseContext.Clients.Remove(Instance.DatabaseContext.Clients.First(x => x.Id == client.Id));

            Instance.DatabaseContext.SaveChanges();
        }

        public static void RemoveCar(Car car)
        {
            Instance = new Database();
            
            Instance.DatabaseContext.Cars.Load();
            Instance.DatabaseContext.Rentals.Load();

            Rental carRental = Instance.DatabaseContext.Rentals.FirstOrDefault(r => r.Car.Id == car.Id);
            if (carRental is null == false)
                Instance.DatabaseContext.Rentals.Remove(Instance.DatabaseContext.Rentals.First(r => r.Car.Id == car.Id));
                
            Instance.DatabaseContext.Cars.Remove(Instance.DatabaseContext.Cars.First(x => x.Id == car.Id));

            Instance.DatabaseContext.SaveChanges();
        }
    }
}