using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PoC.Microservice;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Models;

namespace PoC.Tests
{
public class HaromszogControllerTests
    {
        [Test]
        public void CreateHaromszogTestSuccessfully()
        {
            var haromszogService = new Mock<IHaromszogService>();
            haromszogService.Setup(s => s.CreateHaromszog("asd", 500, 500)).Returns(
                new HaromszogModel() { });
            var haromszogController = new HaromszogController(haromszogService.Object);
            Action a = () => haromszogController.CreateHaromszog("asd", 500, 500);
            a.Should().NotThrow();
        }
        [Test]
        public void CreateHaromszogTestNotSuccessfully()
        {
            var haromszogService = new Mock<IHaromszogService>();
            haromszogService.Setup(s => s.CreateHaromszog("asd", 500, 500)).Throws<Exception>();
            var haromszogController = new HaromszogController(haromszogService.Object);
            Action a = () => haromszogController.CreateHaromszog("asd", 500, 500);
            a.Should().Throw<Exception>();
        }

        [Test]
        public void GetHaromszogTestSuccessfully()
        {
            var haromszogService = new Mock<IHaromszogService>();
            haromszogService.Setup(s => s.UpdateHaromszogKoordinatak(500, 500)).Returns(
                new HaromszogModel() { });
            var haromszogController = new HaromszogController(haromszogService.Object);
            Action a = () => haromszogController.GetHaromszog( 500, 500);
            a.Should().NotThrow();
        }

        [Test]
        public void GetHaromszogTestNotSuccessfully()
        {
            var haromszogService = new Mock<IHaromszogService>();
            haromszogService.Setup(s => s.UpdateHaromszogKoordinatak( 500, 500)).Throws<Exception>();
            var haromszogController = new HaromszogController(haromszogService.Object);
            Action a = () => haromszogController.GetHaromszog( 500, 500);
            a.Should().Throw<Exception>();
        }

        [Test]
        public void RestartProcessTestSuccessfully()
        {
            var haromszogService = new Mock<IHaromszogService>();
            haromszogService.Setup(s => s.Load("asd")).Returns(
                new HaromszogModel() { });
            var haromszogController = new HaromszogController(haromszogService.Object);
            Action a = () => haromszogController.RestartProcess( "asd");
            a.Should().NotThrow();
        }

        [Test]
        public void RestartProcessTestNotSuccessfully()
        {
            var haromszogService = new Mock<IHaromszogService>();
            haromszogService.Setup(s => s.Load("asd")).Throws<Exception>();
            var haromszogController = new HaromszogController(haromszogService.Object);
            Action a = () => haromszogController.RestartProcess("asd");
            a.Should().Throw<Exception>();
        }
    }
}