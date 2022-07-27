﻿using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Vehicle
{
    public class VehicleWriteRepository : WriteRepository<EntityLayer.Entities.Vehicle>, IVehicleWriteRepository
    {
        public VehicleWriteRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
