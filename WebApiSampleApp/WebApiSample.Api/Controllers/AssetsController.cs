﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSample.Api.Data;
using WebApiSample.Api.Models;

namespace WebApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AssetContext _context;

        public AssetsController(AssetContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAsset()
        {
            return await _context.Asset.ToListAsync();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            var asset = await _context.Asset.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST: api/Assets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            _context.Asset.Add(asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asset>> DeleteAsset(int id)
        {
            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();

            return asset;
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.Id == id);
        }
    }
}
