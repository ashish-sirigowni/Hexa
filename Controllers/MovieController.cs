using BookMyShowProjectNewAPI.DTO;
using BookMyShowProjectNewAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowProjectNewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    
        {
            private readonly UnitOfWork unitOfWork;

            public MovieController(UnitOfWork uw)
            {
                unitOfWork = uw;
            }

            [HttpGet]
            public IActionResult GetAllMovies()
            {
                return Ok(unitOfWork.MovieImplObject.GetAll());
            }

          

            [HttpPost]
            public IActionResult AddMovie(MovieDTO movie)
            {
                bool status = unitOfWork.MovieImplObject.Add(movie);
                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(movie);
                }
                return BadRequest("Error In Adding Movie");
            }

            [HttpPut("{id}")]
            public IActionResult EditMovie(long id, MovieDTO updatedMovie)
            {
                updatedMovie.MovID = id; // Assuming the ID is passed in the URL

                bool status = unitOfWork.MovieImplObject.Update(updatedMovie);
                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok("Success");
                }
                return BadRequest($"Movie with ID {id} not found");
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteMovie(long id)
            {
                var movieToDelete = unitOfWork.MovieImplObject.GetAll().FirstOrDefault(m => m.MovID == id);
                if (movieToDelete != null)
                {
                    bool status = unitOfWork.MovieImplObject.Delete(movieToDelete);
                    if (status)
                    {
                        unitOfWork.SaveAll();
                        return Ok("Success");
                    }
                    return BadRequest("Deletion failed");
                }
                return BadRequest($"Movie with ID {id} not found");
            }
        }

    }

