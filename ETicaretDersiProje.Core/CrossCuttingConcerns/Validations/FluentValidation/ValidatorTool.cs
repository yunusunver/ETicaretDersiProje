using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using FluentValidation;

namespace ETicaretDersiProje.Core.CrossCuttingConcerns.Validations.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                
                throw new ValidationException(result.Errors);
            }
        }
    }
}
