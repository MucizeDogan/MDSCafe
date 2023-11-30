using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using DtoLayer.PoductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService) {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult ListBooking() {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto) {
            Booking booking = new Booking() {
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id) {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto) {
            Booking booking = new Booking() {
                BookingID = updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id) {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
