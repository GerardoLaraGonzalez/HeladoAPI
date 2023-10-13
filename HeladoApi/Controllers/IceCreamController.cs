using HeladoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeladoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamController : ControllerBase
    {
        private readonly IceCreamContext _iceCreamContext;
        public IceCreamController(IceCreamContext iceCreamContext) { 
            _iceCreamContext = iceCreamContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IceCream>> GetIceCream()
        {
            return _iceCreamContext.IceCreams;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IceCream>> GetById(int id)
        {
            var icecream = await _iceCreamContext.IceCreams.FindAsync(id);
            return icecream;
        }

        [HttpPost]
        public async Task<ActionResult> Create(IceCream iceCream)
        {
            await _iceCreamContext.IceCreams.AddAsync(iceCream);
            await _iceCreamContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(IceCream iceCream)
        {
            _iceCreamContext.IceCreams.Update(iceCream);
            await _iceCreamContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int iceCreamId)
        {
            var icecream = await _iceCreamContext.IceCreams.FindAsync(iceCreamId);
            _iceCreamContext.IceCreams.Remove(icecream);
            await _iceCreamContext.SaveChangesAsync(); 
            return Ok();
        }
    }
}
