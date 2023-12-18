using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;
using WebApi.Service.PacienteService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteInterface _pacienteInterface;

        public PacienteController(IPacienteInterface pacienteInterface)
        {
            _pacienteInterface = pacienteInterface;


        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> GetPacientes()
        {
            return Ok(await _pacienteInterface.GetPacientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PacienteModel>>> GetPacientebyId(int id)
        {
            ServiceResponse<PacienteModel> serviceResponse = await _pacienteInterface.GetPacientebyId(id);
            return Ok(serviceResponse);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> CreatePaciente(PacienteModel novoPaciente)
        {
            return Ok(await _pacienteInterface.CreatePaciente(novoPaciente));
        } 

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> UpdatePaciente (PacienteModel editadoPaciente)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = await _pacienteInterface.UpdatePaciente(editadoPaciente);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PacienteModel>>>> DeletePaciente(int id)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = await _pacienteInterface.DeletePaciente(id);
            return Ok(serviceResponse);
        }
    }
}
