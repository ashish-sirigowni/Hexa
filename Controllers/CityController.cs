
using BookMyShowProjectNewAPI.Entity;

using BookMyShowProjectNewAPI.DTO;

using BookMyShowProjectNewAPI.Repo;

using Microsoft.AspNetCore.Mvc;

namespace BookMyShowProjectNewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public CityController(UnitOfWork uw)
        {
            unitOfWork = uw;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            return Ok(unitOfWork.CityImplObject.GetAll());
        }

        [HttpPost]
        public IActionResult AddNewCity(CityDTO cityNew)
        {
            bool status = unitOfWork.CityImplObject.Add(cityNew);
            if (status)
            {
                unitOfWork.SaveAll();
                return Ok(cityNew);
            }
            return BadRequest("Error In Adding City");
        }

        [HttpPut("{id}")]
        public IActionResult EditCity(int id, CityDTO updatedCity)
        {
            updatedCity.CityID = id; // Assuming the ID is passed in the URL

            bool status = unitOfWork.CityImplObject.Update(updatedCity);
            if (status)
            {
                unitOfWork.SaveAll();
                return Ok("Success");
            }
            return BadRequest($"City with ID {id} not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var cityToDelete = unitOfWork.CityImplObject.GetAll().FirstOrDefault(c => c.CityID == id);
            if (cityToDelete != null)
            {
                bool status = unitOfWork.CityImplObject.Delete(cityToDelete);
                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok("Success");
                }
                return BadRequest("Deletion failed");
            }
            return BadRequest($"City with ID {id} not found");
        }
    }
}

