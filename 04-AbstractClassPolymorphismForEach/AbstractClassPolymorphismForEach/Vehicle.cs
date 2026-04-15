using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AbstractClassPolymorphismForEach
{
    public  class Vehicle
    {
        public string Brand{ get; set; }
        public string Model{ get; set; }
        public int Year{ get; set; }
        public string PlateNumber{ get; set; }
        public double FuelLevel{ get; set; }
        public int MaxSpeed{ get; set; }

        public Vehicle(string brand,string model,int year,string plateNumber,double fuelLevel,int maxSpeed)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.PlateNumber = plateNumber;
            this.FuelLevel = 100;
            this.MaxSpeed = maxSpeed;
        }
        public void ShowVehivleInfo()
        {
            Console.WriteLine($"Brand:{Brand},Model:{Model},Year:{Year},Plate Number:{PlateNumber},Fuel Level:{FuelLevel}%,Max Speed:{MaxSpeed}km/h");
        }
        
    }
   
   
        

    
}
