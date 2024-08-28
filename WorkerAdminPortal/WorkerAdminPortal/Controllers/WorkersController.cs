using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkerAdminPortal.Data;
using WorkerAdminPortal.Models;
using WorkerAdminPortal.Models.Entities;

namespace WorkerAdminPortal.Controllers
{
    // localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public WorkersController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllWorkers()
        {
            var allWorkers = dbcontext.Workers.ToList();

            return Ok(allWorkers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetWorkerById(Guid id)
        {
            var worker = dbcontext.Workers.Find(id);

            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        [HttpPost]
        public IActionResult AddWorker(AddWorkerDto addWorkerDto)
        {
            var workerEntity = new Worker()
            {
                Name = addWorkerDto.Name,
                Email = addWorkerDto.Email,
                Phone = addWorkerDto.Phone,
                Salary = addWorkerDto.Salary
            };

            dbcontext.Workers.Add(workerEntity);
            dbcontext.SaveChanges();

            return Ok(workerEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateWorker(Guid id, UpdateWorkerDto updateWorkerDto)
        {
            var worker = dbcontext.Workers.Find(id);

            if (worker == null)
            { 
                return NotFound(); 
            }
            worker.Name = updateWorkerDto.Name;
            worker.Email = updateWorkerDto.Email;
            worker.Phone = updateWorkerDto.Phone;
            worker.Salary = updateWorkerDto.Salary;

            dbcontext.SaveChanges();

            return Ok(worker);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteWorker(Guid id)
        {
            var worker = dbcontext.Workers.Find(id);

            if (worker is null)
            {
            return NotFound();
            }

            dbcontext.Workers.Remove(worker);

            dbcontext.SaveChanges();

            return Ok();
        }
    }
}
