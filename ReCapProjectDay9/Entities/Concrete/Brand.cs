using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand :IEntity  //Core katmanına taşıdığımız için proje referansını Core olrak işaretliyoruz, sonra using Core.Entities ekliyoruz
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

    }
}
