using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApi.Models;
using WebApi.Service.ModeloExameService;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloExameController : ControllerBase
    {
        private readonly IModeloExameInterface _modeloexameInterface;

        public ModeloExameController(IModeloExameInterface modeloexameInterface)

        {
            _modeloexameInterface = modeloexameInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ModeloExameModel>>>> GetModeloExame()
        {
            return Ok(await _modeloexameInterface.GetModeloExame());
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<ServiceResponse<ModeloExameModel>>> GetModeloExameId(int id)
        {
            ServiceResponse<ModeloExameModel> serviceResponse = await _modeloexameInterface.GetModeloExamebyId(id);
            return Ok(serviceResponse);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ModeloExameModel>>>> CreateModeloExame(ModeloExameModel novoModeloExame)
        {
            return Ok(await _modeloexameInterface.CreateModeloExame(novoModeloExame));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ModeloExameModel>>>> UpdateModeloExame(ModeloExameModel editadoModeloExame)
        {
            ServiceResponse<List<ModeloExameModel>> serviceResponse = await _modeloexameInterface.UpdateModeloExame(editadoModeloExame);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ModeloExameModel>>>> DeleteModeloExame(int id)
        {
            ServiceResponse<List<ModeloExameModel>> serviceResponse = await _modeloexameInterface.DeleteModeloExame(id);
            return Ok(serviceResponse);
        }



    }
}
