using AutoMapper;
using DelsaMovie.IRepository;
using DelsaMovie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DelsaMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;


        public UsersController(IUnitOfWork unitOfWork, ILogger<UsersController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {

            try
            {
                var users = await _unitOfWork.Users.GetAll();
                var results = _mapper.Map<IList<UserDTO>>(users);
                return Ok(results);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetUsers)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");

                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == id, new List<string> { "Comments" });
                var result = _mapper.Map<UserDTO>(user);

                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetUser)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");

                throw;
            }

        }

    }
}
