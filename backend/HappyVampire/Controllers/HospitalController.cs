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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService service;

        public HospitalController(IHospitalService service)
        {
            this.service = service;
        }

        // GET: Hospital
        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
           
            var hospital = await service.GetAllAsync();
            return hospital == null ? NotFound() as IActionResult : Ok(hospital);
        }

        // GET: Hospital/5
        [HttpGet("{id}", Name = "GetHospital")]
        public async Task<IActionResult> GetHospital(int id)
        {
            var hospital = await service.GetAsync(id);
            return hospital == null ? NotFound() as IActionResult : Ok(hospital);
        }

        // POST: Hospital
        [HttpPost]
        public async Task<IActionResult> AddHospital([FromBody] HospitalDTO hospital)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(hospital);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Hospital/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeHospital(int id, [FromBody] HospitalDTO hospital)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, hospital);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Hospital/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }

        // POST: Hospital/patient/5
        [HttpPost("patient/{id}")]
        public async Task<IActionResult> AddPatient(int id, [FromBody] PatientDTO patient)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddPatient(id, patient);
            return info == null ? StatusCode(400) : Ok();
        }

        // PUT: Hospital/patient/5
        [HttpPut("patient/{id}")]
        public async Task<IActionResult> ChangePatient(int id, [FromBody] PatientDTO patient)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdatePatient(id, patient);
            return result == null ? StatusCode(400) : Ok();
        }

        // DELETE: Hospital/5/patient/5
        [HttpDelete("{id}/patient/{patientId}")]
        public async Task<IActionResult> DeletePatient(int id, int patientId)
        {
            var info = await service.DeletePatient(id, patientId);
            return info ? Ok() : StatusCode(400);
        }
    }
}
