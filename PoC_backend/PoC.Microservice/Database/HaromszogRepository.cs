using System;
using System.Linq;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Models;

namespace PoC.Microservice.Database
{
    public class HaromszogRepository : IHaromszogRepository
    {
        private HaromszogDbContext _context;
        private IHaromszogMapper _mapper;
        public HaromszogRepository(HaromszogDbContext context,IHaromszogMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Persist(HaromszogModel haromszog)
        {
            if (haromszog == null) throw new NullReferenceException();
            var haromszogRecord = _mapper.MapModelToRecord(haromszog);
            _context.Haromszogek.Add(haromszogRecord);
            _context.SaveChanges();
        }

        public HaromszogModel Load(string guid)
        {
            if (String.IsNullOrEmpty(guid)) throw new NullReferenceException();
            var haromszog = _context.Haromszogek.First(x => x.Guid == guid);
            return _mapper.MapRecordToModel(haromszog);
        }

        public void Update(HaromszogModel haromszog)
        {
            var current = _context.Haromszogek.First(x => x.Guid == haromszog.Guid);
            var parameterHaromszogRecord = _mapper.MapModelToRecord(haromszog);
            current.Irany = parameterHaromszogRecord.Irany;
            current.Pont1 = parameterHaromszogRecord.Pont1;
            current.Pont2 = parameterHaromszogRecord.Pont2;
            current.Pont3 = parameterHaromszogRecord.Pont3;
            _context.SaveChanges();

        }
    }
}