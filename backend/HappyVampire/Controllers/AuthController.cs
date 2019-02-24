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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        // POST: Donor/5
        [HttpPost("donor/{Uid}")]
        public async Task<IActionResult> RegisterDonor(string Uid, [FromBody] DonorDTO donor)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.RegisterDonorAsync(Uid, donor);
            return info == null ? StatusCode(400) :  Ok(info) as IActionResult;
        }

        // POST: Hospital/5
        [HttpPost("hospital/{Uid}")]
        public async Task<IActionResult> RegisterHospital(string Uid, [FromBody] HospitalDTO hospital)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.RegisterHospitalAsync(Uid, hospital);
            return info == null ? StatusCode(400) : Ok(info) as IActionResult;
        }
    }

    
}