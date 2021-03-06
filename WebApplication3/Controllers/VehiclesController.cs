using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Controllers.Resources;
using WebApplication3.Models;
using WebApplication3.Persistence;

namespace WebApplication3.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }
        //[HttpPost("/api/vehicles")]
        [HttpPost]
        //public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var model=await context.Models.FindAsync(vehicleResource.ModelId);
            // if(model==null)
            // {
            //     ModelState.AddModelError("ModelId","Invalid modelId.");
            //     return BadRequest(ModelState);
            // }
            // if(true)
            // {
            //     ModelState.AddModelError("...","error");
            //     return BadRequest(ModelState);
            // }
            //var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            //Console.WriteLine("test:" + vehicle);
            vehicle.LastUpdate=DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            var result=mapper.Map<Vehicle,VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]     // /api/vehicles/{id}   
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var model=await context.Models.FindAsync(vehicleResource.ModelId);
            
            //var vehicle = await context.Vehicles.FindAsync(id);
            var vehicle = await context.Vehicles.Include(v=>v.Features).SingleOrDefaultAsync(v=>v.Id==id);

            if(vehicle==null)
                return NotFound();
            
            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
        
            vehicle.LastUpdate=DateTime.Now;
            
            await context.SaveChangesAsync();

            var result=mapper.Map<Vehicle,VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle= await context.Vehicles.FindAsync(id);

            if(vehicle==null)
                return NotFound();

            context.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle= await context.Vehicles.Include(v=>v.Features).SingleOrDefaultAsync(v=>v.Id==id);

            if(vehicle==null)
                return NotFound();
            
            var vehicleResource=mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
    }
}