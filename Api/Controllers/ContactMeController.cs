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
              
            _contactMeService.TAdd(new ContactMe() {
                FooterDescription=createContactMeDto.FooterDescription,
                Location=createContactMeDto.Location,
                Mail=createContactMeDto.Mail,
                Phone=createContactMeDto.Phone
            });
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContactMe(int id) {
            var value = _contactMeService.TGetById(id);
            _contactMeService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateContactMe(UpdateContactMeDto updateContactMeDto) {
            _contactMeService.TUpdate(new ContactMe() {
                ContactMeID = updateContactMeDto.ContactMeID,
                FooterDescription = updateContactMeDto.FooterDescription,
                Location = updateContactMeDto.Location,
                Mail = updateContactMeDto.Mail,
                Phone = updateContactMeDto.Phone
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetContactMe")]
        public IActionResult GetContactMe(int id) { 
            var value = _contactMeService.TGetById(id);
            return Ok(value);
        }
    }
}
