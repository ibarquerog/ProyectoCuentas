using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProyectoCuentas.Controllers
{
    public class HomeController : Controller
    {
        public string Admin = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpPost]
        public ActionResult iniciarSesion(LoginViewModel model)
        {
            if (model.Administrador)
            {

                return View("Clientes");
            }
            else
            {
                return View("viewUsuariosClientes");
            }
            
        }

        [HttpPost]
        public ActionResult editarCliente(IndexViewModel model)
        {
            SqlConnection conexion = new SqlConnection("data source=DESKTOP-2OQBEMO;initial catalog=BD_Cuentas;integrated security=True;MultipleActiveResultSets=True;");
            SqlCommand cmd = new SqlCommand("spModificarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = 2;
            cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 50).Value = model.NombreE.ToString();
            cmd.Parameters.Add("@ValorDocId", System.Data.SqlDbType.Int).Value = int.Parse(model.IDE);
            cmd.Parameters.Add("@Admin", System.Data.SqlDbType.VarChar, 50).Value = "Admin2";
            cmd.Parameters.Add("@Contrasena", System.Data.SqlDbType.VarChar, 50).Value = model.ContrasenaE.ToString();
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }

            return View("Clientes");
        }

        [HttpPost]
        public ActionResult guardarCliente(IndexViewModel model)
        {

            SqlConnection conexion = new SqlConnection("data source=DESKTOP-2OQBEMO;initial catalog=BD_Cuentas;integrated security=True;MultipleActiveResultSets=True;");
            SqlConnection conexion2 = new SqlConnection("data source=DESKTOP-2OQBEMO;initial catalog=BD_Cuentas;integrated security=True;MultipleActiveResultSets=True;");
            SqlCommand cmd = new SqlCommand("spInsertarClientes",conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 50).Value = model.Nombre.ToString();
            cmd.Parameters.Add("@ValorDocId", System.Data.SqlDbType.Int).Value = int.Parse(model.ID);
            cmd.Parameters.Add("@Contrasena", System.Data.SqlDbType.VarChar, 50).Value = model.Contrasena.ToString();
            cmd.Parameters.Add("@Admin", System.Data.SqlDbType.VarChar, 50).Value = "admin1";
            SqlCommand cmd2 = new SqlCommand("spInsertarCuentas", conexion);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@docIdCliente", System.Data.SqlDbType.VarChar, 50).Value = model.ID;
            cmd2.Parameters.Add("@TipoCuenta", System.Data.SqlDbType.Int).Value = int.Parse(model.TipoCuenta);
            cmd2.Parameters.Add("@Saldo", System.Data.SqlDbType.Money).Value = 0.0;
            cmd2.Parameters.Add("@FechaCreacion", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
            cmd2.Parameters.Add("@InteresesAcumulados", System.Data.SqlDbType.Money).Value = 0.0;
            cmd2.Parameters.Add("@CodigoCuenta", System.Data.SqlDbType.VarChar,50).Value = generarCodigoCuenta();
            cmd2.Parameters.Add("@Activo", System.Data.SqlDbType.Bit).Value = 1;
            cmd2.Parameters.Add("@Admin", System.Data.SqlDbType.VarChar, 50).Value = "admin1";


            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }


            return View("Clientes");
        }

        private string generarCodigoCuenta()
        {
            Random rand = new Random();
            string numero = "CR";
            int i;
            for (i = 1; i < 11; i++)
            {
                numero += rand.Next(0, 9).ToString();
            }
            return numero;
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";

            return View("Login");
        }
        public ActionResult Clientes()
        {
            return View();
        }

        public ActionResult Cuentas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult editarCuenta(Cuentas model)
        {
            SqlConnection conexion = new SqlConnection("data source=DESKTOP-2OQBEMO;initial catalog=BD_Cuentas;integrated security=True;MultipleActiveResultSets=True;");
            SqlCommand cmd = new SqlCommand("spModificarCuentas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = model.IdCuentaE;
            cmd.Parameters.Add("@TipoCuenta", System.Data.SqlDbType.Int).Value = int.Parse(model.TipoCuentaE);
            cmd.Parameters.Add("@Admin", System.Data.SqlDbType.VarChar, 50).Value = "admin1";

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }

            return View("Cuentas");
        }

        [HttpPost]
        public ActionResult eliminarCliente(IndexViewModel model)
        {
            SqlConnection conexion = new SqlConnection("data source=DESKTOP-2OQBEMO;initial catalog=BD_Cuentas;integrated security=True;MultipleActiveResultSets=True;");
            SqlCommand cmd = new SqlCommand("spEliminarCliente", conexion);
            cmd.Parameters.Add("@Admin", System.Data.SqlDbType.VarChar, 50).Value = "admin1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = int.Parse(model.idEliminarUsuario);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }

            return View("Clientes");
        }

        public ActionResult dataTableCuentas()
        {
            return View();
        }
        public ActionResult cargarDatosCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearCuenta(Cuentas model)
        {
            SqlConnection conexion = new SqlConnection("data source=DESKTOP-2OQBEMO;initial catalog=BD_Cuentas;integrated security=True;MultipleActiveResultSets=True;");
            SqlCommand cmd = new SqlCommand("spInsertarCuentas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@docIdCliente", System.Data.SqlDbType.VarChar, 50).Value = model.IdCliente;
            cmd.Parameters.Add("@TipoCuenta", System.Data.SqlDbType.Int).Value = int.Parse(model.TipoCuenta);
            cmd.Parameters.Add("@Saldo", System.Data.SqlDbType.Money).Value = 0.0;
            cmd.Parameters.Add("@FechaCreacion", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@InteresesAcumulados", System.Data.SqlDbType.Money).Value = 0.0;
            cmd.Parameters.Add("@CodigoCuenta", System.Data.SqlDbType.VarChar, 50).Value = generarCodigoCuenta();
            cmd.Parameters.Add("@Activo", System.Data.SqlDbType.Bit).Value = 1;
            cmd.Parameters.Add("@Admin", System.Data.SqlDbType.VarChar, 50).Value = "admin1";
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
            return View("Cuentas");
        }





    }
} 