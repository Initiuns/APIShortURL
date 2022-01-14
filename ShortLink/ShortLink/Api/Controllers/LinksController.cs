using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortLink.Models;
using Microsoft.EntityFrameworkCore;

namespace ShortLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LinksController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Links>>> GetLinks()
        {
            return await _context.Links.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Links>> GetLink(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return link;
        }
        
        [HttpPost]
        public async Task<ActionResult<Links>> PostLink(Links link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLink", new { id = link.Id }, link);
        }

        private string GerarChave(int length = 6)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

    }
}
