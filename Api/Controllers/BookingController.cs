using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using DtoLayer.PoductDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator) {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ListBooking() {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto) {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Rezervasyon yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id) {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto) {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id) {
            var value = _bookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id) {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Onaylandı olarak değiştirildi");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id) {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması İptal Edildi olarak değiştirildi");
        }

    }
}
