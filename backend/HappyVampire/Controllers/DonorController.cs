using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyVampire.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService service;

        public DonorController(IDonorService service)
        {
            this.service = service;
        }

        // GET: Donor
        [HttpGet]
        public async Task<IActionResult> GetAllDonors()
        {
            var donor = await service.GetAllAsync();
            return donor == null ? NotFound() as IActionResult : Ok(donor);
        }

        // GET: Donor/5
        [HttpGet("{id}", Name = "GetDonor")]
        public async Task<IActionResult> GetDonor(int id)
        {
            var donor = await service.GetAsync(id);
            return donor == null ? NotFound() as IActionResult : Ok(donor);
        }

        // POST: Donor
        [HttpPost]
        public async Task<IActionResult> AddDonor([FromBody] DonorDTO donor)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(donor);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Donor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeDonor(int id, [FromBody] DonorDTO donor)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, donor);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Donor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
