using BuildingBlocks.ValueObjectsSample;
using BuildingBlocks.ValueObjectsSample.Colors;

//ColorValueObject red = new ColorValueObject
//{
//    Blue = 0,
//    Green = 0,
//    Red = 255
//};

//red.Red = 0;
//red.Green = 255;


//string a = Console.ReadLine();
////Validation
//FirstName firstName = new FirstName(a);

LastName lastName = new LastName();
LastName lastName2 = new LastName();
lastName.Value = "Oroumand";
lastName2.Value = "Oroumand";

if (lastName == lastName2)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}


