using PoC.Microservice.Models;

namespace PoC.Microservice.Interfaces
{
    public interface IHaromszogService
    {
        HaromszogModel CreateHaromszog(string guid,int screenWidth, int screenHeight);
        HaromszogModel UpdateHaromszogKoordinatak(int screenWidth, int screenHeight);

        public HaromszogModel Load(string guid);
    }
}