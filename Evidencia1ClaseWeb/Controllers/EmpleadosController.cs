using Evidencia1ClaseWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evidencia1ClaseWeb.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            List<EmpleadoClass> listaEmpleados = new List<EmpleadoClass>();
            using (IDGS81NETEntities db = new IDGS81NETEntities())
            {
                listaEmpleados = (from d in db.Empleado
                                  select new EmpleadoClass
                                  {
                                      idEmpleado = d.idEmpleado,
                                      nombreEmpleado = d.nombreEmpelado,
                                      apellidoEmpleado = d.apellidoEmpleado,
                                      iDepartamento = (int)d.iDepartamento,
                                      fechaIngreso = (DateTime)d.fechaIngreso,
                                      empleadoCelular = d.empleadoCelular
                                  }).ToList();

            }
            return View(listaEmpleados);
        }
        public ActionResult NuevoEmpleado()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult NuevoEmpleado(EmpleadoClass model)
        {
            if (!ModelState.IsValid) {
                return View(model);

            }
            else{ 
            using (IDGS81NETEntities db = new IDGS81NETEntities())
                {
                var oTabla = new Empleado();
                oTabla.idEmpleado = model.idEmpleado;
                oTabla.nombreEmpelado = model.nombreEmpleado;
                oTabla.apellidoEmpleado = model.apellidoEmpleado;
                oTabla.iDepartamento = model.iDepartamento;
                oTabla.fechaIngreso = model.fechaIngreso;
                oTabla.empleadoCelular = model.empleadoCelular;
                db.Empleado.Add(oTabla);
                db.SaveChanges();
                }
            return Redirect("Index");
            }
            
        }
        public ActionResult DeleteEmpleado(int id)
        {
            using (IDGS81NETEntities db = new IDGS81NETEntities())
            {
                Empleado oTabla = db.Empleado.Find(id);
                db.Empleado.Remove(oTabla);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult EditarEmpleado(EmpleadoClass model)
        {

            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    using (IDGS81NETEntities db = new IDGS81NETEntities())
                    {
                        Empleado oTabla = db.Empleado.Where(d => d.idEmpleado == model.idEmpleado).FirstOrDefault();
                        if (oTabla != null)
                        {
                            oTabla.nombreEmpelado = model.nombreEmpleado;
                            oTabla.apellidoEmpleado = model.apellidoEmpleado;
                            oTabla.iDepartamento = model.iDepartamento;
                            oTabla.fechaIngreso = model.fechaIngreso;
                            oTabla.empleadoCelular = model.empleadoCelular;

                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }

            }

        }


        public ActionResult EditarEmpleado(int id)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            EmpleadoClass modelo;
            using (IDGS81NETEntities db = new IDGS81NETEntities())
            {
                Empleado empleado = db.Empleado.Where(d => d.idEmpleado == id).FirstOrDefault();
                modelo = new EmpleadoClass
                {
                    idEmpleado = empleado.idEmpleado,
                    nombreEmpleado = empleado.nombreEmpelado,
                    apellidoEmpleado = empleado.apellidoEmpleado,
                    iDepartamento= (int)empleado.iDepartamento,
                    fechaIngreso = (DateTime)empleado.fechaIngreso,
                    empleadoCelular = empleado.empleadoCelular
                };

                if (empleado != null)
                {
                    return View(modelo);
                }
            }

            return RedirectToAction("Index");
        }
    }
}