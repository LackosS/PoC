using PoC.Microservice.Models;

namespace PoC.Gateway;

public interface IProcessesDictionary
{
    public void Add(string guid, ProcessModel process);
    public ProcessModel GetProcess(string guid);
    public void SetProcessIsRun(string guid, bool IsRun);
    public List<ProcessesModel> MapDictionaryToList();
}