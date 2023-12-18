using System.ComponentModel.DataAnnotations;
using WebApi.Enum;

namespace WebApi.Models
{
    public class PacienteModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
    }
    
}