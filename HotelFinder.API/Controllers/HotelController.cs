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
        [HttpGet("{action}/{id}")]
        public IActionResult HotelGetAll(int id)
        {
            var hotels= _hotelService.HotelGetById(id);
            if (hotels is not null)
                return Ok(hotels);

            return NotFound();
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
        public bool HotelDeleted(int id)
        {
            _hotelService.HotelDeleted(id);
            return true;
        }

        /// <summary>
        /// Updated Hotels --- Action = HotelUpdated / Hotel -> Models
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut("{action}")]
        public Hotel HotelUpdated([FromBody] Hotel hotel)
        {
            return _hotelService.HotelUpdated(hotel);
        }
    }
}
