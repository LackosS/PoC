using PoC.Microservice.Models;

namespace PoC.Microservice.Interfaces
{
    public interface IHaromszogRepository
    {
        void Persist(HaromszogModel haromszog);
        HaromszogModel Load(string guid);
        
        void Update(HaromszogModel haromszog);
    }
}