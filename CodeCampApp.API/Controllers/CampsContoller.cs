using AutoMapper;
using CodeCampApp.Data;
using CodeCampApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeCampApp.API.Controllers
{
    [Route("api/[Controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository repository;
        private readonly IMapper mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> Get()
        {
            try
            {
                var camps = await this.repository.GetAllCampsAsync();
                return this.mapper.Map<CampModel[]>(camps);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
    }
}