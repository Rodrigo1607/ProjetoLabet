using WebApi.Models;

namespace WebApi.Service.ModeloExameService
{
    public interface IModeloExameInterface
    {
        Task<ServiceResponse<List<ModeloExameModel>>> GetModeloExame();

        Task<ServiceResponse<List<ModeloExameModel>>> CreateModeloExame(ModeloExameModel novoModeloExame);

        Task<ServiceResponse<ModeloExameModel>> GetModeloExamebyId(int id);

        Task<ServiceResponse<List<ModeloExameModel>>> UpdateModeloExame(ModeloExameModel editadoModeloExame);

        Task<ServiceResponse<List<ModeloExameModel>>> DeleteModeloExame(int id);
    }
}
