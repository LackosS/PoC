using PoC.Microservice.Models;

namespace PoC.Gateway;

public class ProcessesDictionary : IProcessesDictionary
{
    private Dictionary<string, ProcessModel> processes;

    public ProcessesDictionary()
    {
        processes = new Dictionary<string, ProcessModel>();
    }

    public void Add(string guid, ProcessModel process)
    {
        processes.Add(guid,process);
    }

    public ProcessModel GetProcess(string guid)
    {
        return processes[guid];
    }

    public void SetProcessIsRun(string guid,bool IsRun)
    {
        processes[guid].IsRun = IsRun;
    }
    
    public List<ProcessesModel> MapDictionaryToList()
    {
        List<ProcessesModel> _processes = new List<ProcessesModel>();
        foreach(KeyValuePair<string, ProcessModel> entry in processes)
        {
            ProcessesModel pr = new ProcessesModel();
            pr.guid = entry.Key;
            pr.process = entry.Value;
            _processes.Add(pr);
        }
        return _processes;
    }
}
public class ProcessModel
{
    public int Port { get; set; }
    public bool IsRun { get; set; }
}