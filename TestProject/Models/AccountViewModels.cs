using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestProject.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Pamiętasz tę przeglądarkę?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Adres e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj hasło")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasło i jego potwierdzenie są niezgodne.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "PESEL")]
        [PESELValidator(ErrorMessage = "PESEL nie jest poprawny")]
        [PESELRepeatValidator(ErrorMessage = "Podany PESEL istnieje w bazie")]
        public string PESEL { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasło i jego potwierdzenie są niezgodne.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }
    }

    public class PESELValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            string PESEL = value.ToString();
            bool flag = true;

            if (PESEL.Length != 11)
                return false;

            int[] array = new int[11];
            int number;
            for (int i = 0; i < 11; i++)
            {
                if (int.TryParse(PESEL[i].ToString(), out number))
                    array[i] = number;
                else
                    flag = false;
            }

            int sum = array[0] + 3 * array[1] + 7 * array[2] + 9 * array[3] + array[4] + 3 * array[5] + 7 * array[6] + 9 * array[7] + array[8] + 3 * array[9] + array[10];

            if (sum % 10 != 0)
                flag = false;

            return flag;
        }
    }

    public class PESELRepeatValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Context db = new Context();
            string PESEL = value.ToString();

            bool repeat = db.Doctors.Any(x => x.Doctor_PESEL == PESEL);

            return !repeat;
        }
    }
}
