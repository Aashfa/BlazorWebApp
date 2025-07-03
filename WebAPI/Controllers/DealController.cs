using Microsoft.AspNetCore.Mvc;
using Repo.IService;
using Entities;
using System.Threading.Tasks;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }

        // GET: api/deals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deal>>> GetAll()
        {
            var deals = await _dealService.GetAllDeals();
            return Ok(deals);
        }

        // GET api/deals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deal>> GetById(int id)
        {
            var deal = await _dealService.GetDealById(id);
            if (deal == null)
            {
                return NotFound();
            }
            return Ok(deal);
        }

        // POST api/deals
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Deal deal)
        {
            var id = await _dealService.CreateDeal(deal);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // PUT api/deals/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Deal deal)
        {
            if (id != deal.DealId)
            {
                return BadRequest();
            }

            var success = await _dealService.UpdateDeal(deal);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/deals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _dealService.DeleteDeal(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}