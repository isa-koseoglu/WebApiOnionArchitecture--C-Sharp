using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Bisuiness.Abstcract
{
    public interface IHotelService
    {
        List<Hotel> HotelGetAll();
        Hotel HotelGetById(int id);
        Hotel HotelAdded(Hotel hotel);
        Hotel HotelUpdated(Hotel hotel);
        void HotelDeleted(int id);
    }
}
