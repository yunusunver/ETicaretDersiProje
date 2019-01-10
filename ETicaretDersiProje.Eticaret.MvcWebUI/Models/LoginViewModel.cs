using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ETicaretDersiProje.Core.Aspects.Postsharp.ValidationAspects;
using ETicaretDersiProje.Eticaret.Business.ValidationRules.FluentValidation;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Models
{
  
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email adresinizi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parolanızı giriniz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Adınızı giriniz.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyadınızı giriniz.")]
        public string LastName { get; set; }

        
    }
}