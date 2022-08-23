using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PoC.Microservice.Database;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Mappers;

namespace PoC.Tests.DatabaseTests
{
    public class HaromszogRepositoryTests
    {
        public HaromszogDbContext context { get; set; }
        
        [SetUp]
        public void Setup()
        {
            CreateTestDataBaseClass.CreateDataBase();
            context = new HaromszogDbContext("TestHaromszogDbContext");
        }

        [TearDown]
        public void TearDown()
        {
            context.Haromszogek.RemoveRange(context.Haromszogek);
            context.SaveChanges();
        }

        [Test]
        public void HaromszogRepositoryNotThrowTest()
        {
            var mockHaromszogMapper = new Mock<IHaromszogMapper>();
            Action a = () => new HaromszogRepository(context,mockHaromszogMapper.Object );
            a.Should().NotThrow();
        }
        
        [Test]
        public void HaromszogRepositoryNotNullTest()
        {
            var mockHaromszogMapper = new Mock<IHaromszogMapper>();
            var haromszogRepository =  new HaromszogRepository(context,mockHaromszogMapper.Object );
            haromszogRepository.Should().NotBeNull();
        }


        [Test]
        public void PersistTest()
        {
            var haromszgMapper = new HaromszogMapper();
            var haromszogRepository =  new HaromszogRepository(context,haromszgMapper);
                
            haromszogRepository.Persist(TestHelper.GetHaromszogModel());

            var res = context.Haromszogek.First(x => x.Guid == "Abcd1234");

            res.Should().NotBeNull();
        }
        
        [Test]
        public void LoadTest()
        {
            var haromszgMapper = new HaromszogMapper();
            var haromszogRepository =  new HaromszogRepository(context,haromszgMapper);
            context.Haromszogek.Add(TestHelper.GetHaromszogRecord());
            context.SaveChanges();
            haromszogRepository.Load("Abcd1234");

            var res = context.Haromszogek.First(x => x.Guid == "Abcd1234");

            res.Should().NotBeNull();
        }
        
        [Test]
        public void UpdateTest()
        {
            var haromszgMapper = new HaromszogMapper();
            var haromszogRepository =  new HaromszogRepository(context,haromszgMapper);
            var record = context.Haromszogek.Add(TestHelper.GetHaromszogRecord());
            context.SaveChanges();

            var current = context.Haromszogek.First(x => x.Id == record.Id);

            var color = "blue";
            var irany = "3,-2";
            var pont1 = "50,120";
            var pont2 = "70,210";
            var pont3 = "150,250";

            current.Color = color;
            current.Irany = irany;
            current.Pont1 = pont1;
            current.Pont2 = pont2;
            current.Pont3 = pont3;
            
            haromszogRepository.Update(haromszgMapper.MapRecordToModel(current));

            var res = context.Haromszogek.First(x => x.Id == record.Id);

            res.Color.Should().Be(color);
            res.Irany.Should().Be(irany);
            res.Pont1.Should().Be(pont1);
            res.Pont2.Should().Be(pont2);
            res.Pont3.Should().Be(pont3);
            
        }

        [Test]
        public void PersistThrowNull()
        {
            var haromszgMapper = new HaromszogMapper();
            var haromszogRepository =  new HaromszogRepository(context,haromszgMapper);
                
            Action a =() => haromszogRepository.Persist(null);
            a.Should().Throw<Exception>();
        }
        
        [Test]
        public void LoadThrowNull()
        {
            var haromszgMapper = new HaromszogMapper();
            var haromszogRepository =  new HaromszogRepository(context,haromszgMapper);
                
            Action a =() => haromszogRepository.Load(null);
            a.Should().Throw<Exception>();
        }

    }

}