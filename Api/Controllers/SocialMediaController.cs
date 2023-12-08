﻿using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper) {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListSocialMedia() {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto) {

            _socialMediaService.TAdd(new SocialMedia() {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
            });
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id) {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto) {
            _socialMediaService.TUpdate(new SocialMedia() {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id) {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }
    }
}
