using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel> HotelGetAll();
        Hotel HotelGetById(int id);
        List<Hotel> HotelGetName(string name);
        Hotel HotelAdded(Hotel hotel);
        Hotel HotelUpdated(Hotel hotel);
        void HotelDeleted(int id);
    }
}
