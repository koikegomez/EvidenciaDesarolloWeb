using Evidencia1ClaseWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Evidencia1ClaseWeb.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        List<RolClass> listaRol = new List<RolClass>();
        public ActionResult Index()
        {
            using (var bd = new IDGS81NETEntities()) 
            {
                listaRol = (from ROL in bd.ROL where ROL.ESTATUS == 1 select new RolClass
                {
                    IDROL = ROL.IDROL,
                    NOMBRE = ROL.NOMBRE,
                    DESCRIPCION = ROL.DESCRIPCION

                }).ToList();
                
            
            }
                return View(listaRol);
        }
    }
}