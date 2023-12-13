
using BookMyShowProjectNewAPI.DTO;
using BookMyShowProjectNewAPI.Entity;
using BookMyShowProjectNewAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowProjectNewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplexInfoController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public MultiplexInfoController(UnitOfWork uw)
        {
            unitOfWork = uw;
        }

        [HttpGet]
        public IActionResult GetAllMultiplexInfo()
        {
            return Ok(unitOfWork.MultiplexInfoImplObject.GetAll());
        }

        [HttpPost]
        public IActionResult AddMultiplexInfo(MultiplexInfoDTO multiplexInfo)
        {
            bool status = unitOfWork.MultiplexInfoImplObject.Add(multiplexInfo);
            if (status)
            {
                unitOfWork.SaveAll();
                return Ok(multiplexInfo);
            }
            return BadRequest("Error In Adding Multiplex");
        }

        [HttpPut("{id}")]
        public IActionResult EditMultiplex(int id, MultiplexInfoDTO updatedMultiplex)
        {
            updatedMultiplex.MulID = id; // Assuming the ID is passed in the URL

            bool status = unitOfWork.MultiplexInfoImplObject.Update(updatedMultiplex);
            if (status)
            {
                unitOfWork.SaveAll();
                return Ok("Success");
            }
            return BadRequest($"Multiplex with ID {id} not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMultiplex(int id)
        {
            var multiplexToDelete = unitOfWork.MultiplexInfoImplObject.GetAll().FirstOrDefault(m => m.MulID == id);
            if (multiplexToDelete != null)
            {
                bool status = unitOfWork.MultiplexInfoImplObject.Delete(multiplexToDelete);
                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok("Success");
                }
                return BadRequest("Deletion failed");
            }
            return BadRequest($"Multiplex with ID {id} not found");
        }
    }
}

