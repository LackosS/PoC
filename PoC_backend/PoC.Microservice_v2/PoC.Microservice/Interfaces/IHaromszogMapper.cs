using PoC.Microservice.Database;
using PoC.Microservice.Models;

namespace PoC.Microservice.Interfaces
{
    public interface IHaromszogMapper
    {
        HaromszogRecord MapModelToRecord(HaromszogModel haromszogModel);
        HaromszogModel MapRecordToModel(HaromszogRecord haromszogRecord);
    }
}