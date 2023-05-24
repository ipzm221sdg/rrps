using System;

namespace main
{
    abstract class Logistics
    {
       public abstract Transport CreateTransport();
       
       public string PlanDelivery()
        {
            var transport = CreateTransport();
            var result = "Logistics: The product has been "
                + transport.Deliver() + "\n";

            return result;
        }
    }

   class RoadLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Truck();
        }
    }

    class SeaLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Truck();
        }
    }
    
    class AirLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Plane();
        }
    }

    public interface Transport
    {
        string Deliver();
    }

    class Truck : Transport
    {
        public string Deliver()
        {
            return "{delivered by truck}";
        }
    }

    class Ship : Transport
    {
        public string Deliver()
        {
            return "{delivered by ship}";
        }
    }
    
    class Plane : Transport
    {
        public string Deliver()
        {
            return "{delivered by plane}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Products sent by road.\n");
            ClientCode(new RoadLogistics());
            
            Console.WriteLine("");

            Console.WriteLine("App: Products sent by water.\n");
            ClientCode(new SeaLogistics());
            
            Console.WriteLine("");

            Console.WriteLine("App: Products sent by air.\n");
            ClientCode(new AirLogistics());
        }

       public void ClientCode(Logistics logistics)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class, " +
                "but it still works.\n" + logistics.PlanDelivery());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
