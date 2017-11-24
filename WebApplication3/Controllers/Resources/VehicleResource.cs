using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        //public Model Model { get; set; }
        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }

        //public DateTime LastUpdate { get; set; }

        //public ICollection<VehicleFeature> Features { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleResource ()
        {
            Features=new Collection<int>();
        }
    }
}