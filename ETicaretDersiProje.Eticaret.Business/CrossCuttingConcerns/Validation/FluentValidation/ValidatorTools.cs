using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ETicaretDersiProje.Eticaret.Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTools
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count>0)
            {
                throw  new ValidationException(result.Errors);
            }
        }
    }
}
