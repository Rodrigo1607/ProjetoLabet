using Microsoft.EntityFrameworkCore;
using WebApi.DataContext;
using WebApi.Models;

namespace WebApi.Service.ModeloExameService
{
    public class ModeloExameService : IModeloExameInterface
    {
        private readonly ApplicationDbContext _context;

        public ModeloExameService(ApplicationDbContext context)
        {
            // Inicialize sua lista de pacientes ou outro mecanismo de armazenamento
            _context = context;
        }

        public async Task<ServiceResponse<List<ModeloExameModel>>> CreateModeloExame(ModeloExameModel novoModeloExame)
        {
            ServiceResponse<List<ModeloExameModel>> serviceResponse = new ServiceResponse<List<ModeloExameModel>>();

            try
            {
                if (novoModeloExame == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Entrar com Dados!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Add(novoModeloExame);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.ModeloExame.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ModeloExameModel>>> DeleteModeloExame(int id)
        {
            ServiceResponse<List<ModeloExameModel>> serviceResponse = new ServiceResponse<List<ModeloExameModel>>();


            try
            {


                ModeloExameModel modeloexame = _context.ModeloExame.FirstOrDefault(x => x.Id == id);
                if (modeloexame == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Exame não Encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;

                }
                _context.ModeloExame.Remove(modeloexame);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.ModeloExame.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ModeloExameModel>> GetModeloExamebyId(int id)
        {
            ServiceResponse<ModeloExameModel> serviceResponse = new ServiceResponse<ModeloExameModel>();

            try
            {
                ModeloExameModel modeloexame = _context.ModeloExame.FirstOrDefault(x => x.Id == id);

                if (modeloexame == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Exame não Localizado!";
                    serviceResponse.Sucesso = false;

                }

                serviceResponse.Dados = modeloexame;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ModeloExameModel>>> GetModeloExame()
        {
            ServiceResponse<List<ModeloExameModel>> serviceResponse = new ServiceResponse<List<ModeloExameModel>>();

            try
            {
                serviceResponse.Dados = _context.ModeloExame.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ModeloExameModel>>> UpdateModeloExame(ModeloExameModel editadoModeloExame)
        {
            ServiceResponse<List<ModeloExameModel>> serviceResponse = new ServiceResponse<List<ModeloExameModel>>();

            try
            {
                ModeloExameModel modeloexame = _context.ModeloExame.AsNoTracking().FirstOrDefault(x => x.Id == editadoModeloExame.Id);
                if (modeloexame == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Exame não Localizado!";
                    serviceResponse.Sucesso = false;

                }

                _context.ModeloExame.Update(editadoModeloExame);
                await _context.SaveChangesAsync();                                                              

                serviceResponse.Dados = _context.ModeloExame.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
