using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PoC.Microservice.Models;

namespace PoC.Gateway.Tests;

public class Tests
{
    [Test]
    public async Task CreateHaromszogTestsSuccessfully()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var httpClient = webAppFactory.CreateDefaultClient();

        var res = await httpClient.PostAsJsonAsync("api/Gateway/CreateHaromszog?guid=asdasd&port=8000&height=500&width=500",
                new HaromszogModel() { Guid = "asdasd", 
                    Pont1 = new PontModel(){X=12,Y=22}, Pont2 = new PontModel(){X=12,Y=22},Pont3 = new PontModel(){X=12,Y=22},Irany = new PontModel(){X=12,Y=22},Color = "aqua"});
        res.IsSuccessStatusCode.Should().BeTrue();
    }
    [Test]
    public async Task CreateHaromszogTestsNotSuccessfully()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var httpClient = webAppFactory.CreateDefaultClient();

        var res = await httpClient.PostAsJsonAsync("api/Gateway/CreateHaromszog?guid=asdasd&height=500&width=500",
            new HaromszogModel() { Guid = "asdasd", 
                Pont1 = new PontModel(){X=12,Y=22}, Pont2 = new PontModel(){X=12,Y=22},Pont3 = new PontModel(){X=12,Y=22},Irany = new PontModel(){X=12,Y=22},Color = "aqua"});
        res.IsSuccessStatusCode.Should().BeFalse();
    }
    [Test]
    public async Task GetHaromszogTestsSuccessfully()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var httpClient = webAppFactory.CreateDefaultClient();
        var createRes = await httpClient.PostAsJsonAsync("api/Gateway/CreateHaromszog?guid=asd&port=8000&height=500&width=500",
            new HaromszogModel() { Guid = "asd", 
                Pont1 = new PontModel(){X=12,Y=22}, Pont2 = new PontModel(){X=12,Y=22},Pont3 = new PontModel(){X=12,Y=22},Irany = new PontModel(){X=12,Y=22},Color = "aqua"});
        
        var res = await httpClient.GetAsync("api/Gateway/GetHaromszog?guid=asd&screenWidth=500&screenHeight=500");
        res.IsSuccessStatusCode.Should().BeTrue();
    }
    [Test]
    public async Task GetHaromszogTestsNotSuccessfully()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var httpClient = webAppFactory.CreateDefaultClient();

        var res = await httpClient.GetAsync("api/Gateway/GetHaromszog?height=500&width=500");
        res.IsSuccessStatusCode.Should().BeFalse();

    }
    [Test]
    public async Task GetAllProcessTestsSuccessfully()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var httpClient = webAppFactory.CreateDefaultClient();
        var res = await httpClient.GetAsync("api/Gateway/GetAllProcess");
        res.IsSuccessStatusCode.Should().BeTrue();

    }
}