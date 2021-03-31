using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApp30.Models;

namespace WebApp30.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly ShopContext _context;
        public ShopController(ShopContext context)
        {
            _context = context;
            
        }

        ShopContext db;

        //GET: /api/Shops
        [HttpGet]
        public IEnumerable<Orders> Get()
        { 
            return _context.Orders.ToArray();
        }

        //GET: /api/Shops/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetById(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }


        //GET /api/Shop
        [HttpPost]
        public async Task<ActionResult<Orders>> Post(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = orders.Id }, orders);
        }

        //PUT /api/Shop/?
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Orders orders)
        {
            if (id != orders.Id)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool OrdersItemExists(int id)
        {
            throw new NotImplementedException();
        }

        //GET api/Shop/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _context.Orders.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(todoItem);
            object p = await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    }

