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

        

        public async Task<List<Hotel>> HotelGetAll()
        {
            return await _hotelRespository.HotelGetAll();
        }

        public async Task<Hotel> HotelGetById(int id)
        {
            return await _hotelRespository.HotelGetById(id);
        }

        public async Task<Hotel> HotelAdded(Hotel hotel)
        {
            return await _hotelRespository.HotelAdded(hotel);
        }

        public async Task<Hotel> HotelUpdated(Hotel hotel)
        {
            return await _hotelRespository.HotelUpdated(hotel);
        }

        public async Task HotelDeleted(int id)
        {
            await _hotelRespository.HotelDeleted(id);
        }

        public async Task<List<Hotel>> HotelGetNameOrId(int id=0, string name="")
        {
            var hotelFindName = await _hotelRespository.HotelGetName(name);
            var hotelFindId =await  _hotelRespository.HotelGetById(id);
            if (hotelFindId != null)
            {
                hotelFindName.Clear();
                hotelFindName.Add(hotelFindId);
            }
            return hotelFindName;
            
        }
    }
}
