using Microsoft.AspNetCore.Mvc;
using Ejercicios.Models;
using Ejercicios.Data;
using System.Text;

namespace Ejercicios.Controllers
{


    public class PasswordController : Controller
    {
        private readonly Datacontext _context;

        public PasswordController(Datacontext context)
        {
            _context = context;
        }

        //private string GeneratePassword(int length, bool includeSpecialChars, bool includeNumbers, bool includeUpperCase)
        //{
        //    const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        //    const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    const string numbers = "0123456789";
        //    const string specialChars = "!@#$%^&*()_-+=<>?";

        //    var charSet = lowerCase;
        //    if (includeUpperCase) charSet += upperCase;
        //    if (includeNumbers) charSet += numbers;
        //    if (includeSpecialChars) charSet += specialChars;

        //    var password = new StringBuilder();
        //    var random = new Random();

        //    for (int i = 0; i < length; i++)
        //    {
        //        var randomIndex = random.Next(charSet.Length);
        //        password.Append(charSet[randomIndex]);
        //    }

        //    return password.ToString();
        //}

        private string GeneratePassword(int length, bool includeSpecialChars, bool includeNumbers, bool includeUpperCase)
        {
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_-+=<>?";

            // Inicializar el conjunto de caracteres con letras minúsculas por defecto.
            string charSet = lowerCase;

            // Añadir los conjuntos de caracteres seleccionados.
            if (includeUpperCase) charSet += upperCase;
            if (includeNumbers) charSet += numbers;
            if (includeSpecialChars) charSet += specialChars;

            // Verificar que se hayan incluido caracteres seleccionados.
            if (string.IsNullOrEmpty(charSet))
            {
                throw new ArgumentException("Al menos un tipo de carácter debe ser seleccionado.");
            }

            var password = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                var randomIndex = random.Next(charSet.Length);
                password.Append(charSet[randomIndex]);
            }

            return password.ToString();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int length, bool includeSpecialChars, bool includeNumbers, bool includeUpperCase)
        {
            var passwordValue = GeneratePassword(length, includeSpecialChars, includeNumbers, includeUpperCase);
            var password = new Password { Value = passwordValue };

            _context.Passwords.Add(password);
            _context.SaveChanges();

            ViewBag.GeneratedPassword = passwordValue;
            return View();
        }
    }

}
