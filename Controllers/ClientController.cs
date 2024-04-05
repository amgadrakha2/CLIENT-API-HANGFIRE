using Microsoft.AspNetCore.Mvc;
using ClientApp.Models;
using ClientApp.Interface;
using AutoMapper;
using ClientApp.Dto;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        // GET api/<UserController>
        [HttpGet]
        [Route("GetClientsByFilter")]
        public async Task<IActionResult> GetPersons(
                                                 [FromQuery] FilterClient filterParameters)
        {
            var clients = await _clientRepository.GetPersonsAsync(filterParameters);
            var clientsDto = _mapper.Map<List<ClientDto>>(clients);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(clientsDto);
        }

        // GET api/<UserController>
        [HttpGet]
        [Route("GetAllClient")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        public IActionResult GetAllClients()
        {
            var clients = _mapper.Map<List<ClientDto>>(_clientRepository.GetAllClients());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(clients);
        }


        //GetClientById
        [HttpGet]
        [Route("GetClientById")]
        public IActionResult GetClientById([FromQuery] int Id)
        {
            if (!_clientRepository.IsClientExist(Id))
            {
                return NotFound();
            }
            var clientId= _clientRepository.GetClientById(Id);
            var clientMap=_mapper.Map<Client>(clientId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(clientMap);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("CreatatingClient")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClient([FromQuery] ClientDto clientCreate)
        {
            if (clientCreate == null)
                return BadRequest(ModelState);

            if (_clientRepository.IsClientExist(clientCreate.Email))
            {
                ModelState.AddModelError("", "email already used");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientMap = _mapper.Map<Client>(clientCreate);

            if (!_clientRepository.CreateClient(clientMap))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully Created");
        }

        // Put api/<UserController>
        [HttpPut("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClient(int Id ,[FromQuery] ClientDto clientUpdate)
        {
            if (!_clientRepository.IsClientExist(Id))
                return NotFound();

            if (!_clientRepository.IsClientExist(clientUpdate.Email))
            {
                if (_clientRepository.IsClientExist(clientUpdate.Email))
                {
                    return BadRequest("Email already exists");
                }
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var clientMap = _mapper.Map<Client>(clientUpdate);

            if (!_clientRepository.UpdateClient(clientMap))
            {
                ModelState.AddModelError("", "Something Went Wrong Updating Data");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int Id)
        {

            if (!_clientRepository.IsClientExist(Id))
                return NotFound();

            var clientDelete = _clientRepository.GetClientById(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_clientRepository.DeleteClient(clientDelete))
            {
                ModelState.AddModelError("", "something went wrong deleting Client");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        


    }
}
