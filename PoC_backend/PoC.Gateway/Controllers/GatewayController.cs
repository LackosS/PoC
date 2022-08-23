using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using PoC.Microservice.Models;
[assembly: InternalsVisibleTo("PoC.Gateway.Tests")]

namespace PoC.Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GatewayController : Controller
{
    internal IProcessesDictionary _processes;
    private static readonly HttpClient client = new HttpClient();

    public GatewayController(IProcessesDictionary processes)
    {
        _processes = processes;
    }

    [HttpPost("CreateHaromszog")]
    public async Task<ActionResult<HaromszogModel>> CreateHaromszog(string guid, int port, int screenWidth, int screenHeight)
    {
        {
            CreateProcess(port);
            ProcessModel pr = new ProcessModel() { Port = port, IsRun = true };
            _processes.Add(guid, pr);
            var response =
                await client.PostAsync(
                    $"http://localhost:{port}/api/haromszog/createharomszog?guid={guid}&height={screenHeight}&width={screenWidth}",
                    null);
            var haromszog = await response.Content.ReadFromJsonAsync<HaromszogModel>();
            return Ok(haromszog);
        }
    }
    
    [HttpGet("GetHaromszog")]
    public async Task<ActionResult<HaromszogModel>> GetHaromszog(string guid, int screenWidth, int screenHeight)
    {
        ProcessModel pr = _processes.GetProcess(guid);
        int port = pr.Port;
        try
        {
            var response = await client.GetAsync(
                $"http://localhost:{port}/api/haromszog/getharomszog?height={screenHeight}&width={screenWidth}");
            
            var haromszog = await response.Content.ReadFromJsonAsync<HaromszogModel>();
            return Ok(haromszog);
        }
        catch (Exception e)
        {
            return await Restart(guid,port, pr);
        }
    }
    [HttpGet("GetAllProcess")]
    public async Task<ActionResult<List<ProcessesModel>>> GetAllProcess()
    {
        return _processes.MapDictionaryToList();
    }
    private void CreateProcess(int port)
    {
        string fileName;
        string sourcePath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory())+@"\PoC.Microservice\bin\Release";
        string targetPath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory())+@$"\Versions\{port}";
        System.IO.Directory.CreateDirectory(targetPath);
        string destFile;

        string[] files = System.IO.Directory.GetFiles(sourcePath);

        foreach (string s in files)
        {
            fileName = System.IO.Path.GetFileName(s);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }

        fileName = "PoC.Microservice.exe";
        var process = Process.Start(targetPath + @"\" + fileName, port.ToString());
    }
    private async Task<ActionResult<HaromszogModel>> Restart(string guid,int port, ProcessModel pr)
    {
        string fileName;
        string sourcePath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory())+@"\PoC.Microservice\bin\Release";
        string targetPath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory())+@$"\Versions\{port}";
        
        System.IO.Directory.Delete(targetPath,true);
        System.IO.Directory.CreateDirectory(targetPath);

        string destFile;

        string[] files = System.IO.Directory.GetFiles(sourcePath);

        foreach (string s in files)
        {
            fileName = System.IO.Path.GetFileName(s);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }

        fileName = "PoC.Microservice.exe";
        var process = Process.Start(targetPath + @"\" + fileName, port.ToString());
        Thread.Sleep(3000);
        var help = await client.GetAsync($"http://localhost:{pr.Port}/api/haromszog/restartprocess?guid={guid}");
        var loadedHaromszog = await help.Content.ReadFromJsonAsync<HaromszogModel>();
        return Ok(loadedHaromszog);    
    }
}