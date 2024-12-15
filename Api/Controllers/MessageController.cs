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

        public MessageController(IMessageService messageService) {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult ListMessage() {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto) {
            Message message = new Message() {
                Mail = createMessageDto.Mail,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                subject = createMessageDto.Subject,
                MessageContent = createMessageDto.MessageContent,
                MessageDate = DateTime.Now,
                Status = false
            };
            _messageService.TAdd(message);
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
            Message message = new Message() {
                MessageID = updateMessageDto.MessageID,
                Mail = updateMessageDto.Mail,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                MessageDate = updateMessageDto.MessageDate,
                Status = false
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj alanı başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id) {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }
    }
}
