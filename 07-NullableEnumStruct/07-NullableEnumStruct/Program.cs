using _07_NullableEnumStruct;

class Program
{
    static void Main(string[] args)
    {
        

        DrinkOrder sifaris1 = new DrinkOrder(101, "Feyzullah", DrinkType.Coffee, DrinkSize.Medium);
        sifaris1.DisplayOrder();

        sifaris1.UpdateStatus(OrderStatus.Preparing);
        sifaris1.UpdateStatus(OrderStatus.Ready);
        sifaris1.UpdateStatus(OrderStatus.Delivered);

        Console.WriteLine();

        DrinkOrder sifaris2 = new DrinkOrder(102, "Ezet", DrinkType.Tea, DrinkSize.Large);
        sifaris2.DisplayOrder();

        sifaris2.UpdateStatus(OrderStatus.Ready);

        Console.WriteLine();

        DrinkOrder sifaris3 = new DrinkOrder(103, "Huseyn", DrinkType.Juice, DrinkSize.Small);
        sifaris3.DisplayOrder();

        Console.WriteLine();

        

        Console.WriteLine("---------------------------------");
        foreach (var item in Enum.GetValues(typeof(DrinkType)))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("----------------------");
        foreach (var item in Enum.GetValues(typeof(DrinkSize)))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("---------------------");
        foreach (var item in Enum.GetValues(typeof(OrderStatus)))
        {
            Console.WriteLine(item);
        }

        
        Console.WriteLine("------------------");
        Console.WriteLine(DrinkType.Coffee.ToString());
        Console.WriteLine(DrinkSize.Large.ToString());

        
        Console.WriteLine("----------");
        DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
        DrinkSize parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");

        Console.WriteLine(parsedDrink);
        Console.WriteLine(parsedSize);

        

        Console.WriteLine("-------------");
        Console.WriteLine($"Ümumi sifariş sayı: 3");

        Console.WriteLine($"1-ci sifariş qiyməti: {sifaris1.Price}");
        Console.WriteLine($"2-ci sifariş qiyməti: {sifaris2.Price}");
        Console.WriteLine($"3-cü sifariş qiyməti: {sifaris3.Price}");

        decimal total = sifaris1.Price + sifaris2.Price + sifaris3.Price;
        Console.WriteLine($"Ümumi məbləğ: {total} AZN");
    }
}