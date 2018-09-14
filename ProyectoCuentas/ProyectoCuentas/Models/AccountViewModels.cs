using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;




    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Display(Name = "Administrador")]
        public bool Administrador { get; set; }
    }



