using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Controllers.Resources;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;

        }
        //[HttpPost("/api/vehicles")]
        [HttpPost]
        //public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        {

            //var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            Console.WriteLine("test:"+vehicle);

            return Ok(vehicle);
        }
    }
}