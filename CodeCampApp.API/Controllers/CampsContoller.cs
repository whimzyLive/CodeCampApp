using AutoMapper;
using CodeCampApp.API.Services;
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
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IPublisher _publisher;

        public CampsController(ICampRepository repository, IMapper mapper, LinkGenerator linkGenerator, IPublisher publiser)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _publisher = publiser;
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> Get(bool includeTalks = false)
        {
            try
            {
                var camps = await _repository.GetAllCampsAsync(includeTalks);
                return _mapper.Map<CampModel[]>(camps);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> GetCampByMoniker(string moniker, bool includeTalks = false)
        {
            try
            {
                var result = await _repository.GetCampAsync(moniker, includeTalks);

                if (result == null)
                {
                    return NotFound(new { Message = "No such Camp.." });
                }
                return _mapper.Map<CampModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to get camp {moniker}");
            }

        }

        [HttpPost]
        public async Task<ActionResult<CampModel>> Post(CampModel model)
        {
            string location = _linkGenerator.GetPathByAction("GetCampByMoniker", "Camps", new { moniker = model.Moniker });
            try
            {
                var camp = _mapper.Map<Camp>(model);
                _repository.Add(camp);
                if (await _repository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<CampModel>(camp));
                }
                return BadRequest("Cloud not create Camp");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong");
            }
        }


        [HttpPost("Notify")]
        public IActionResult Notify()
        {
            Subscriber sub1 = new("Subscriber 1");
            Subscriber sub2 = new("Subscriber 2");

            _publisher.OnChange += (sender, e) => sub1.Update(sender, e);
            _publisher.OnChange += (sender, e) => sub2.Update(sender, e);

            _publisher.Notify(new CustomEvent("Time to go home."));

            return Ok();
        }
    }
}