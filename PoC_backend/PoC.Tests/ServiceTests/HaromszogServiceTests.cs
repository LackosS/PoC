using FluentAssertions;
using Moq;
using NUnit.Framework;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Models;
using PoC.Microservice.Services;
using PoC.Tests.DatabaseTests;

namespace PoC.Tests.ServiceTests
{
    public class HaromszogServiceTests
    {
        [Test]
        public void UpdateHaromszogKoordinatakNotThrow()
        {
            var mockHaromszogRepository = new Mock<IHaromszogRepository>();

            var res = new HaromszogService(mockHaromszogRepository.Object);

            res.Should().NotBeNull();
        }

        [Test]
        public void UpdateHaromszogKoordinatakNotNullTest()
        {
            var mockHaromszogRepository = new Mock<IHaromszogRepository>();
            mockHaromszogRepository.Setup(r => r.Update(It.IsAny<HaromszogModel>()));
            var haromszogService = new HaromszogService(mockHaromszogRepository.Object);
            haromszogService.haromszog = TestHelper.GetHaromszogModel();
            var res = haromszogService.UpdateHaromszogKoordinatak(1000, 1000);
            
            res.Should().NotBeNull();
        }
        
        [Test]
        public void LoadNotNullTest()
        {
            var mockHaromszogRepository = new Mock<IHaromszogRepository>();
            mockHaromszogRepository.Setup(r => r.Load(It.IsAny<string>())).Returns(new HaromszogModel());
            var haromszogService = new HaromszogService(mockHaromszogRepository.Object);
            
            var res = haromszogService.Load("guid");
            
            res.Should().NotBeNull();
        }

        [Test]
        public void LoadMethodCallOnceTest()
        {
            var mockHaromszogRepository = new Mock<IHaromszogRepository>();
            var haromszogService = new HaromszogService(mockHaromszogRepository.Object);
            
            haromszogService.Load(It.IsAny<string>());
        
            mockHaromszogRepository.Verify(s => s.Load(It.IsAny<string>()), Times.Once);
            
        }
        
        
        [Test]
        public void CreateHaromszogReturnsNotNullTest()
        {
            var mockHaromszogRepository = new Mock<IHaromszogRepository>();
            mockHaromszogRepository.Setup(r => r.Persist(It.IsAny<HaromszogModel>()));
            
            var haromszogService = new HaromszogService(mockHaromszogRepository.Object);

            string testGuid = "GuidTest123";
            int sreenWidth = 1000;
            int screenHeight = 1000;
            var res = haromszogService.CreateHaromszog(testGuid, sreenWidth, screenHeight);

            res.Should().NotBeNull();
            res.Guid.Should().Be(testGuid);
            res.Pont1.Should().NotBeNull();
            res.Pont2.Should().NotBeNull();
            res.Pont3.Should().NotBeNull();
            res.Pont1.X.Should().BeLessThan(sreenWidth);
            res.Pont1.Y.Should().BeLessThan(screenHeight);
            res.Pont1.X.Should().BeGreaterThan(0);
            res.Pont1.Y.Should().BeGreaterThan(0);
            
            res.Pont2.X.Should().BeLessThan(sreenWidth);
            res.Pont2.Y.Should().BeLessThan(screenHeight);
            res.Pont2.X.Should().BeGreaterThan(0);
            res.Pont2.Y.Should().BeGreaterThan(0);
            
            res.Pont3.X.Should().BeLessThan(sreenWidth);
            res.Pont3.Y.Should().BeLessThan(screenHeight);
            res.Pont3.X.Should().BeGreaterThan(0);
            res.Pont3.Y.Should().BeGreaterThan(0);

            res.Irany.Should().NotBeNull();
            
            res.Irany.X.Should().BeLessThan(5);
            res.Irany.Y.Should().BeLessThan(5);
            res.Irany.X.Should().BeGreaterThan(-5);
            res.Irany.Y.Should().BeGreaterThan(-5);

        }
    }
}