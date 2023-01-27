using HotelFinder.Bisuiness.Abstcract;
using HotelFinder.Bisuiness.ConCreate;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels ---- Action = HotelGetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("{action}")]
        public IActionResult HotelGetAll()
        {
            var hotels = _hotelService.HotelGetAll();
            return Ok(hotels);
        }

        /// <summary>
        /// Get By Id Hotels --- Action = HotelGetAll / id -> integer (- HotelId -)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("[action]/{id}")]
        public IActionResult HotelGetAll(int id)
        {
            var hotels= _hotelService.HotelGetById(id);
            if (hotels is not null)
                return Ok(hotels);

            return NotFound();
        }
        [HttpGet()]
        [Route("[action]/id={id}&name={name}")]
        public IActionResult HotelGetAll(int id,string name)
        {
            try
            {
                int _id = id;
                string _name = name;
                if (_id <= 0) _id = 0;
                if (string.IsNullOrEmpty(_name)) _name = "";
                if(_id==0 && _name == "") NotFound();
                var hotelsFind = _hotelService.HotelGetNameOrId(_id, _name);
                if(hotelsFind!=null&&hotelsFind.Count>0)
                    return Ok(hotelsFind);
                return NotFound();

            }
            catch (System.Exception)
            {

                return NotFound();
            }
            

            
        }
        /// <summary>
        ///  Added Hotels --- Action = HotelAdded / Hotel -> Models
        /// </summary>
        /// /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost("{action}")]
        public IActionResult HotelAdded([FromBody]Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var Addedhotels = _hotelService.HotelAdded(hotel);
                var url= CreatedAtAction("HotelGetAll", new { id = Addedhotels.Id }, Addedhotels);
                return url;
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Deleted Hotel --- Action = HotelDeleted / id -> integer (- HotelId -)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{action}/{id}")]
        public IActionResult HotelDeleted(int id)
        {
            if (_hotelService.HotelGetById(id)!=null)
            {
                _hotelService.HotelDeleted(id);
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Updated Hotels --- Action = HotelUpdated / Hotel -> Models
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut("{action}")]
        public IActionResult HotelUpdated([FromBody] Hotel hotel)
        {
            if (_hotelService.HotelGetById(hotel.Id)!=null)
            {
                return Ok(_hotelService.HotelUpdated(hotel));
            }
            
            return NotFound();
        }
    }
}
