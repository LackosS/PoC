using System.Web.Http;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Models;

namespace PoC.Microservice
{
    public class HaromszogController : ApiController
    {
        private IHaromszogService _service;

        public HaromszogController()
        {
            
        }
        public HaromszogController(IHaromszogService service)
        {
            _service = service;
        }
        
        [Route("GetHaromszog")]
        [HttpGet]
        public HaromszogModel GetHaromszog(int height,int width)
        {
            return _service.UpdateHaromszogKoordinatak(width, height);
        }

        [Route("CreateHaromszog")]
        [HttpPost]
        public HaromszogModel CreateHaromszog(string guid,int height,int width)
        {
            return _service.CreateHaromszog( guid,width, height);
        }

        [Route("RestartProcess")]
        [HttpGet]
        public HaromszogModel RestartProcess(string guid)
        {
            return _service.Load(guid);
        }
        
    }
}