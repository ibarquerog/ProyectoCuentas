using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.Entity;


    public class IndexViewModel
    {

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Display(Name = "Nombre")]
        public string NombreE { get; set; }

        [Display(Name = "ID")]
        public string IDE { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        
        public string ContrasenaE { get; set; }

        [Display(Name = "Tipo Cuenta")]
         public string TipoCuenta { get; set; }

        [Display(Name = "ID Usuario")]
        public string idEliminarUsuario { get; set; }  



}

public class Cuentas{
    [Required]
    [Display(Name = "Id Cuenta")]
    public string IdCuenta { get; set; }

    [Required]
    [Display(Name = "Id Cuenta")]
    public string IdCuentaE { get; set; }

    [Required]
    [Display(Name = "Tipo Cuenta")]
    public string TipoCuenta { get; set; }

    //Crear cuentas
    [Required]
    [Display(Name = "Tipo Cuenta")]
    public string TipoCuentaE { get; set; }

    [Required]
    [Display(Name = "ID Cliente")]
    public string IdCliente { get; set; }


}

public class gridCuentas
{
    public string docIdCliente { get; set; }

    public int tipoCuenta { get; set; }

    public decimal Saldo { get; set; }

    public string FechaCreacion { get; set; }

    public decimal insteresesAcumulados { get; set; }

    public string codigoCuenta { get; set; }

    public int activo { get; set; }
}

public class Usuarios
{
    [Required]
    [Display(Name = "Id Cuenta")]
    public string IdCuenta { get; set; }
}



    



