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
        Task<List<Hotel>> HotelGetAll();
        Task<Hotel> HotelGetById(int id);
        Task<List<Hotel>> HotelGetName(string name);
        Task<Hotel> HotelAdded(Hotel hotel);
        Task<Hotel> HotelUpdated(Hotel hotel);
        Task HotelDeleted(int id);
    }
}
