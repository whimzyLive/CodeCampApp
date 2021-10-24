using AutoMapper;
using CodeCampApp.Data;
using CodeCampApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace CodeCampApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository repository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public CampsController(ICampRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> Get(bool includeTalks = false)
        {
            try
            {
                var camps = await this.repository.GetAllCampsAsync(includeTalks);
                return this.mapper.Map<CampModel[]>(camps);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> GetCampByMoniker(string moniker, bool includeTalks = false)
        {
            try
            {
                var result = await this.repository.GetCampAsync(moniker, includeTalks);

                if (result == null)
                {
                    return NotFound(new { Message = "No such Camp.." });
                }
                return this.mapper.Map<CampModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Failed to get camp {moniker}");
            }

        }

        [HttpPost]
        public async Task<ActionResult<CampModel>> Post(CampModel model)
        {
            string location = this.linkGenerator.GetPathByAction("GetCampByMoniker", "Camps", new { moniker = model.Moniker });
            try
            {
                var camp = this.mapper.Map<Camp>(model);
                this.repository.Add(camp);
                if (await this.repository.SaveChangesAsync())
                {
                    return Created(location, this.mapper.Map<CampModel>(camp));
                }
                return BadRequest("Cloud not create Camp");
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Something went wrong");
            }
        }
    }
}