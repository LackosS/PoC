using PoC.Microservice.Database;
using PoC.Microservice.Models;

namespace PoC.Tests.DatabaseTests
{
    public static class TestHelper
    {
        public static HaromszogModel GetHaromszogModel()
        {
            return new HaromszogModel()
            {
                Color = "red",
                Guid = "Abcd1234",
                Irany = new PontModel(){X = 2, Y =3 },
                Pont1 = new PontModel(){X = 150, Y =120 },
                Pont2 = new PontModel(){X = 200, Y =120 },
                Pont3 = new PontModel(){X = 210, Y =150 },
            };

        }
        
        
        public static HaromszogRecord GetHaromszogRecord()
        {
            return new HaromszogRecord()
            {
                Color = "red",
                Guid = "Abcd1234",
                Irany = "2,3",
                Pont1 = "150,120",
                Pont2 = "200,120",
                Pont3 = "210,150"
            };

        }
        
    }
}