using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactMeDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMeController : ControllerBase {
        private readonly IContactMeService _contactMeService;
        private readonly IMapper _mapper;

        public ContactMeController(IContactMeService contactMeService, IMapper mapper) {
            _contactMeService = contactMeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListContactMe() {
            var values = _mapper.Map<List<ResultContactMeDto>>(_contactMeService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContactMe(CreateContactMeDto createContactMeDto) {

            var value = _mapper.Map<ContactMe>(createContactMeDto);
            _contactMeService.TAdd(value);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactMe(int id) {
            var value = _contactMeService.TGetById(id);
            _contactMeService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateContactMe(UpdateContactMeDto updateContactMeDto) {
            var value = _mapper.Map<ContactMe>(updateContactMeDto);
            _contactMeService.TUpdate(value);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactMe(int id) { 
            var value = _contactMeService.TGetById(id);
            return Ok(_mapper.Map<GetContactMeDto>(value));
        }
    }
}
