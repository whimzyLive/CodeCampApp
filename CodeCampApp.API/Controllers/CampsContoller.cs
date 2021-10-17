using CodeCampApp.Data;
using CodeCampApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeCampApp.API.Controllers
{
    [Route("api/[Controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository repository;

        public CampsController(ICampRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Task<Camp[]> Get()
        {
            return this.repository.GetAllCampsAsync();
        }
    }
}