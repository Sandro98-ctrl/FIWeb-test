using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebAtividadeEntrevista.Validations;

namespace WebAtividadeEntrevista.Models.Validations
{
    public class CpfValidationAttribute : ValidationAttribute, IClientValidatable
    {
        public CpfValidationAttribute() : this("O CPF informado não é válido") { }

        public CpfValidationAttribute(string errorMessage) : base(errorMessage) { }

        public override bool IsValid(object value)
        {
            var cpf = value as string;

            if (string.IsNullOrEmpty(cpf))
                return true;

            return CpfValidator.Validate(cpf);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(null),
                ValidationType = "cpfValidation"
            };
        }
    }
}