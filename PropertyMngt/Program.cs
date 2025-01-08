using PropertyMngt.Models;
using PropertyMngt.Services;
using System;

Console.WriteLine("Property Management sln ");

Console.WriteLine("Question 1: Create 10 properties: ");


PropertyService propertyService = new PropertyService();

BuyerService buyerService = new BuyerService();

var apartment1 = new Apartment(5, "Big House", "Baabda");

var apartment2 = new Apartment(3, "Medium house", "Beirut");

var apartment3 = new Apartment(7, "Very big house", "Yarzeh");

var apartment4 = new Apartment(2, "small house", "hamra");

var apartment5 = new Apartment(1, "studio ap", "badaro");

var land1 = new Land(140, true, "Farming Land", "Bekaa");

var land2 = new Land(30, false, "Living Land", "Beirut");

var shop1 = new Shop(25, "Food", "Food Delicious", "hamra");

var shop2 = new Shop(120, "Repair", "Mechanic", "Dawra");

var shop3 = new Shop(50, "Retail", "Zara", "ABC");

var props = new List<Property>()
{
    apartment1, apartment2 , apartment3 , apartment4 , apartment5, land1, land2, shop1 , shop2 , shop3
};

Console.WriteLine();
Console.WriteLine();

foreach (var property in props)
{
    Console.WriteLine(property);
}


Console.WriteLine();
Console.WriteLine("land properties are:");
foreach (var landprop in props.OfType<Land>())
{
    Console.WriteLine(landprop);
}

Console.WriteLine();
Console.WriteLine();

var buyer1 = new Buyer("Omar J.", 60_000m);

var buyer2 = new Buyer("Jamal S.", 400_000m);

var buyer3 = new Buyer("Ali M.", 10_000m);

var buyers = new List<Buyer>()
{
    buyer1, buyer2, buyer3
};

Console.WriteLine();
Console.WriteLine();



Console.WriteLine("Properties with price between 45 and 100k are:");
foreach (var property in props.Where(p => p.Price >= 45_000 && p.Price <= 100_000))
{
    Console.WriteLine("Title: {0}, Price: {1}", property.Title, property.Price);
}

buyerService.PurchaseProperty(buyer1, shop3);
buyerService.PurchaseProperty(buyer2, apartment5);
buyerService.PurchaseProperty(buyer2, apartment5);
buyerService.PurchaseProperty(buyer3, apartment4);
buyerService.PurchaseProperty(buyer1, apartment1);
buyerService.PurchaseProperty(buyer1, land2);
buyerService.PurchaseProperty(buyer2, apartment2);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

var ownedProps = new List<Property>()
{
    shop3, apartment5, apartment4, apartment1, land2, apartment2
};

Console.WriteLine();
Console.WriteLine();

buyerService.DisplayBuyers(buyers);

Console.WriteLine();
Console.WriteLine();

bool validInput = false;
int userPropId = -1;
string title = "";
while (!validInput)
{

    Console.WriteLine("Hey, mohammad. Which property id would like to update?");
    if (!int.TryParse(Console.ReadLine(), out int propId))
    {
        continue;
    }
    userPropId = propId;
    Console.WriteLine("Noted! Enter title");
    title = Console.ReadLine();
    if (string.IsNullOrEmpty(title))
    {
        continue;
    }

    validInput = true;
}
propertyService.UpdateProperty(userPropId, title, props);

var prop = props.FirstOrDefault(p => p.Id == userPropId);
Console.WriteLine(prop);

var rand = new Random();


while(true)
{
    var idx1 = rand.Next(props.Count);
    var idx2 = rand.Next(props.Count);
    if(idx1 == idx2)
    {
        continue;
    }
    var prop1 = props[idx1];
    var prop2 = props[idx2];

    if (ownedProps.Contains(prop1) || ownedProps.Contains(prop2))
    {
        continue;
    }

    props.RemoveAt(idx1);
    props.RemoveAt(idx2);

    Console.WriteLine($"removed property with id{prop1.Id} titled {prop1.Title}");
    Console.WriteLine($"removed property with id{prop2.Id} titled {prop2.Title}");

    break;
}

Console.WriteLine();
Console.WriteLine();

foreach (var property in props)
{
    Console.WriteLine(property);
}
