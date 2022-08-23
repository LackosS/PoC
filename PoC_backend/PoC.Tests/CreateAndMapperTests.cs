using FluentAssertions;
using NUnit.Framework;
using PoC.Microservice.Database;
using PoC.Microservice.Mappers;
using PoC.Microservice.Models;

namespace PoC.Tests
{
    public class CreateAndMapperTests
    {
        private HaromszogModel haromszogModel;
        private HaromszogRecord haromszogRecord;
        private HaromszogMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            haromszogModel = new HaromszogModel() { Guid = "asd", Pont1 = new PontModel(){X=12,Y=22},Pont2 = new PontModel(){X=12,Y=22},Pont3 = new PontModel(){X=12,Y=22},Irany = new PontModel(){X=12,Y=22},Color = "aqua" };
            haromszogRecord = new HaromszogRecord() { Guid = "asd", Pont1 = "12,22",Pont2 = "12,22",Pont3 = "12,22",Irany = "12,12",Color = "aqua" };
            _mapper = new HaromszogMapper();
        }

        [Test]
        public void CreateTrianglesSuccessfully()
        {
            haromszogModel.Guid.Should().Be("asd");
            haromszogModel.Pont1.Should().NotBeNull();
            haromszogModel.Pont2.Should().NotBeNull();
            haromszogModel.Pont3.Should().NotBeNull();
            haromszogModel.Color.Should().Be("aqua");

            haromszogRecord.Guid.Should().Be("asd");
            haromszogRecord.Pont1.Should().NotBeNull();
            haromszogRecord.Pont2.Should().NotBeNull();
            haromszogRecord.Pont3.Should().NotBeNull();
            haromszogRecord.Color.Should().Be("aqua");
        }

        #region MapperTests

        [Test]
        public void MapperModelToRecordSuccessfully()
        {
            var haromszogRecord = _mapper.MapModelToRecord(haromszogModel);
            
            haromszogRecord.Guid.Should().Be("asd");
            haromszogRecord.Pont1.Should().NotBeNull();
            haromszogRecord.Pont2.Should().NotBeNull();
            haromszogRecord.Pont3.Should().NotBeNull();
            haromszogRecord.Color.Should().Be("aqua");
            haromszogRecord.Should().BeOfType<HaromszogRecord>();
        }
        [Test]
        public void MapperRecordToModelSuccessfully()
        {
            var haromszogModel = _mapper.MapRecordToModel(haromszogRecord);
            
            haromszogModel.Guid.Should().Be("asd");
            haromszogModel.Pont1.Should().NotBeNull();
            haromszogModel.Pont2.Should().NotBeNull();
            haromszogModel.Pont3.Should().NotBeNull();
            haromszogModel.Color.Should().Be("aqua");
            haromszogModel.Should().BeOfType<HaromszogModel>();
        }

        #endregion
    }
}