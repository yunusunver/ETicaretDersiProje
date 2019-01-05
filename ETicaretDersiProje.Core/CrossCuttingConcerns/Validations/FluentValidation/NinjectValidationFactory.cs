using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ninject;
using Ninject.Modules;

namespace ETicaretDersiProje.Core.CrossCuttingConcerns.Validations.FluentValidation
{
    public class NinjectValidationFactory:ValidatorFactoryBase
    {
        private IKernel _kernel;

        public NinjectValidationFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }


        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator)_kernel.TryGet(validatorType);
        }
    }
}
