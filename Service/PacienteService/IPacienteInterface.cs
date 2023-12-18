using WebApi.Models;

namespace WebApi.Service.PacienteService
{
    public interface IPacienteInterface
    {
        Task<ServiceResponse<List<PacienteModel>>> GetPacientes();

        Task<ServiceResponse<List<PacienteModel>>> CreatePaciente(PacienteModel novoPaciente);

        Task<ServiceResponse<PacienteModel>> GetPacientebyId(int id);

        Task<ServiceResponse<List<PacienteModel>>> UpdatePaciente(PacienteModel editadoPaciente);

        Task<ServiceResponse<List<PacienteModel>>> DeletePaciente(int id);
    }
}
