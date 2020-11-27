using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace AtributosClaseDatos
{
    public class ClaseDatos
    {
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string Cadena { get; set; }

        [LongValidator(MinValue = 1, MaxValue = 100, ExcludeRange = true)]
        public long miLong { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(2, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Cadena2 { get; set; }

    }
}
