using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MessageDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper) {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListMessage() {
            var values = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto) {
            createMessageDto.MessageDate = DateTime.Now;
            createMessageDto.Status = false;
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);
            return Ok("Mesaj kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id) {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj alanı başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto) {
            updateMessageDto.Status = false;
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesaj alanı başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id) {
            var value = _messageService.TGetById(id);
            return Ok(_mapper.Map<GetMessageDto>(value));
        }
    }
}
