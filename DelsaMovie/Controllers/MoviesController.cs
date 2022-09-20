using AutoMapper;
using DelsaMovie.Data.Entities;
using DelsaMovie.IRepository;
using DelsaMovie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DelsaMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;   
        private readonly ILogger<MoviesController> _logger;
        private readonly IMapper _mapper;


        public MoviesController(IUnitOfWork unitOfWork ,ILogger<MoviesController> logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _logger = logger;   
            _mapper = mapper;   

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovies()
        {
            
            try
            {
                var movies =await _unitOfWork.Movies.GetAll();
                var results = _mapper.Map<IList<MovieDTO>>(movies);
                return Ok(results);



            }catch(Exception ex)
            {
                _logger.LogError(ex ,$"Something Went Wrong in the {nameof(GetMovies)}");
                return StatusCode(500,"Internal Server Error. Please Try Again Later");

                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                var movie = await _unitOfWork.Movies.Get(q=>q.Id==id,new List<string> { "Links"} );
                var result = _mapper.Map<MovieDTO>(movie);

                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetMovie)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");

                throw;
            }

        }

        /*[HttpPost("create")]
        public async Task<ActionResult> CreateMovie(CreateMovieDTO movie)
        {
      
                return BadRequest(ModelState);

          

        }*/



    }
}
