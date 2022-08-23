using PoC.Gateway;

namespace PoC.Microservice.Models;

public class ProcessesModel
{
    public string guid { get; set; }
    public ProcessModel process { get; set; }
}