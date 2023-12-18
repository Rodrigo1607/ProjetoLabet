using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.DataContext;
using WebApi.Models;

namespace WebApi.Service.PacienteService
{
    public class PacienteService : IPacienteInterface
    {

        private readonly ApplicationDbContext _context;

        public PacienteService(ApplicationDbContext context)
        {
            // Inicialize sua lista de pacientes ou outro mecanismo de armazenamento
            _context = context;
        }


        public async  Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel novoPaciente)
        {

            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();

            try
            {
                if (novoPaciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Entrar com Dados!";
                    serviceResponse.Sucesso = false; 
                    return serviceResponse;

                }

                _context.Add(novoPaciente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Paciente.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;


            //throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PacienteModel>>> DeletePaciente(int id)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();


            try
            {


                PacienteModel paciente = _context.Paciente.FirstOrDefault(x => x.Id == id);
                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Paciente não Encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;

                }
                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Paciente.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
            //throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PacienteModel>> GetPacientebyId(int id)
        {

            ServiceResponse<PacienteModel> serviceResponse = new ServiceResponse<PacienteModel>();

            try
            {
                PacienteModel paciente = _context.Paciente.FirstOrDefault(x  => x.Id == id);

                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Paciente não Localizado!";
                    serviceResponse.Sucesso=false;
                    
                }

                serviceResponse.Dados = paciente;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            
                return serviceResponse;
                            
            //throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PacienteModel>>> GetPacientes()
        {
            ServiceResponse < List < PacienteModel >> serviceResponse = new ServiceResponse<List<PacienteModel>>();

            try
            {
                serviceResponse.Dados = _context.Paciente.ToList();

                if(serviceResponse.Dados.Count == 0)
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

        public async Task<ServiceResponse<List<PacienteModel>>> UpdatePaciente (PacienteModel editadoPaciente)
        {
            ServiceResponse<List<PacienteModel>> serviceResponse = new ServiceResponse<List<PacienteModel>>();

            try
            {
                PacienteModel paciente = _context.Paciente.AsNoTracking().FirstOrDefault(x => x.Id == editadoPaciente.Id);
                if (paciente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Paciente não Localizado!";
                    serviceResponse.Sucesso = false;

                }

                _context.Paciente.Update(editadoPaciente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Paciente.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
            
            //throw new NotImplementedException();
        }
    }
}
