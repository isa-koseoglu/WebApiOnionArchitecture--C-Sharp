using HotelFinder.Bisuiness.Abstcract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.ConCreate;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Bisuiness.ConCreate
{
    public class HotelManager: IHotelService
    {
        private IHotelRepository _hotelRespository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRespository = hotelRepository;
        }

        

        public List<Hotel> HotelGetAll()
        {
            return _hotelRespository.HotelGetAll();
        }

        public Hotel HotelGetById(int id)
        {
            return _hotelRespository.HotelGetById(id);
        }

        public Hotel HotelAdded(Hotel hotel)
        {
            return _hotelRespository.HotelAdded(hotel);
        }

        public Hotel HotelUpdated(Hotel hotel)
        {
            return _hotelRespository.HotelUpdated(hotel);
        }

        public void HotelDeleted(int id)
        {
            _hotelRespository.HotelDeleted(id);
        }

        public List<Hotel> HotelGetNameOrId(int id=0, string name="")
        {
            var hotelFindName = _hotelRespository.HotelGetName(name);
            var hotelFindId = _hotelRespository.HotelGetById(id);
            if (hotelFindId != null)
            {
                hotelFindName.Clear();
                hotelFindName.Add(hotelFindId);
            }
            return hotelFindName;
            
        }
    }
}
