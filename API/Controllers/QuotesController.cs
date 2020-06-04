using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Db;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        DataContext data { get; set; }
        public QuotesController(DataContext context)
        {
            data = context;
        }
        [HttpPost]
        public async Task<ActionResult<Quote>> Create(Quote newQuote) //Create
        {
            if (newQuote == null)
            {
                ModelState.AddModelError("quoteError", "Добаляемые данные некоррентны!");
                return BadRequest();
            }
            data.Quotes.Add(newQuote);
            await data.SaveChangesAsync();
            return Ok("Данные добавлены!");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> Read() // Select * 
        {
            return await data.Quotes.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Read(int id) //Select by id
        {
            Quote quote = await data.Quotes.FirstOrDefaultAsync(x => x.Id == id);
            if (quote == null)
                return NotFound();
            return new ObjectResult(quote);
        }
        [HttpPut]
        public async Task<ActionResult<Quote>> Update(Quote quote)
        {
            if (quote == null)
            {
                ModelState.AddModelError("quoteError", "Именяемые данные некоррентны!");
                return BadRequest();
            }
        if (!data.Quotes.Any(x => x.Id == quote.Id))
        {
            ModelState.AddModelError("quoteError", "Именяемые данные не найдены!");
            return NotFound();
        }
        data.Update(quote);
        await data.SaveChangesAsync();
        return Ok("Данные изменены!");
    }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> Delete(int id) //Delete
        {
            Quote quote = await data.Quotes.FirstOrDefaultAsync(x => x.Id == id);
            if (quote == null)
            {
                ModelState.AddModelError("quoteError", "Удаляемые данные не найдены!");
                return NotFound();
            }            
            data.Quotes.Remove(quote);
            await data.SaveChangesAsync();
            return Ok("Данные удалены");
        }
    }
}