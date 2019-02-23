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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService service;

        public PatientController(IPatientService service)
        {
            this.service = service;
        }

        // GET: Patient
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patient = await service.GetAllAsync();
            return patient == null ? NotFound() as IActionResult : Ok(patient);
        }

        // GET: Patient/5
        [HttpGet("{id}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await service.GetAsync(id);
            return patient == null ? NotFound() as IActionResult : Ok(patient);
        }

        // POST: Patient
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDTO patient)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(patient);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangePatient(int id, [FromBody] PatientDTO patient)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, patient);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
