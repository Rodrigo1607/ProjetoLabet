using WebApi.Enum;

namespace WebApi.Models
{
    public class ModeloExameModel
    {
        public int Id { get; set; }
        public string NomePaciente { get; set; }
        public string NomeExame { get; set; }
        public decimal ValorLeucocitos { get; set; }
        public decimal ValorPlaquetas { get; set; }

        
    }
}
