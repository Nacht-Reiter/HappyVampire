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
    public class DonationController : ControllerBase
    {
        private readonly IDonationService service;

        public DonationController(IDonationService service)
        {
            this.service = service;
        }

        // GET: Donation
        [HttpGet]
        public async Task<IActionResult> GetAllDonations()
        {
            var donation = await service.GetAllAsync();
            return donation == null ? NotFound() as IActionResult : Ok(donation);
        }

        // GET: Donation/5
        [HttpGet("{id}", Name = "GetDonation")]
        public async Task<IActionResult> GetDonation(int id)
        {
            var donation = await service.GetAsync(id);
            return donation == null ? NotFound() as IActionResult : Ok(donation);
        }

        // POST: Donation
        [HttpPost]
        public async Task<IActionResult> AddDonation([FromBody] DonationDTO donation)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(donation);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Donation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeDonation(int id, [FromBody] DonationDTO donation)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, donation);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Donation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
