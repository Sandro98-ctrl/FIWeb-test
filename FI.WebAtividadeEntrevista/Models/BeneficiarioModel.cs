using System.ComponentModel.DataAnnotations;
using WebAtividadeEntrevista.Models.Validations;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        [CpfValidation]
        [Required]
        public string CPF { get; set; }

        [Required]
        public string Name { get; set; }
    }
}