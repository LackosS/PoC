using System;
using PoC.Microservice.Database;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Models;

namespace PoC.Microservice.Mappers
{
    public class HaromszogMapper : IHaromszogMapper
    {
        public HaromszogModel MapRecordToModel(HaromszogRecord haromszogRecord)
        {
            return new HaromszogModel()
            {
                Guid = haromszogRecord.Guid,
                Irany = new PontModel{ X = Convert.ToInt32(haromszogRecord.Irany.Split(',')[0]), Y = Convert.ToInt32(haromszogRecord.Irany.Split(',')[1])},
                Pont1 = new PontModel{ X = Convert.ToInt32(haromszogRecord.Pont1.Split(',')[0]), Y = Convert.ToInt32(haromszogRecord.Pont1.Split(',')[1])},
                Pont2 = new PontModel{ X = Convert.ToInt32(haromszogRecord.Pont2.Split(',')[0]), Y = Convert.ToInt32(haromszogRecord.Pont2.Split(',')[1])},
                Pont3 = new PontModel{ X = Convert.ToInt32(haromszogRecord.Pont3.Split(',')[0]), Y = Convert.ToInt32(haromszogRecord.Pont3.Split(',')[1])},
                Color = haromszogRecord.Color
            };
        }

        public HaromszogRecord MapModelToRecord(HaromszogModel haromszogModel)
        {
            return new HaromszogRecord()
            {
                Guid = haromszogModel.Guid,
                Irany = haromszogModel.Irany.X + "," + haromszogModel.Irany.Y,
                Pont1 = haromszogModel.Pont1.X + "," + haromszogModel.Pont1.Y,
                Pont2 = haromszogModel.Pont2.X + "," + haromszogModel.Pont2.Y,
                Pont3 = haromszogModel.Pont3.X + "," + haromszogModel.Pont3.Y,
                Color = haromszogModel.Color
            };
        }
    }
}