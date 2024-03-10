using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CafeTablesController : ControllerBase {
        private readonly ICafeTableService _cafeTableService;

        public CafeTablesController(ICafeTableService cafeTableService) {
            _cafeTableService = cafeTableService;
        }
        
        [HttpGet("CafeTableCount")]
        public IActionResult CafeTableCount() {
            return Ok(_cafeTableService.TCafeTableCount());
        }
    }
}
