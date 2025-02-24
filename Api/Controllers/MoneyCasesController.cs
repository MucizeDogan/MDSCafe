﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCasesController(IMoneyCaseService moneyCaseService) {
            _moneyCaseService = moneyCaseService;
        }
        [HttpGet("TotalMoneyCase")]
        public IActionResult TotalMoneyCase() {
            return Ok(_moneyCaseService.TTotalMoneyCase());
        }
    }
}
