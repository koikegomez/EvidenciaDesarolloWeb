using Evidencia1ClaseWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System;

namespace Evidencia1ClaseWeb.Controllers
{
    public class ClientesController : Controller

    {

       

        public FileResult GenerarPDF() 
        {
            Document doc = new Document();
            byte[] buffer;


            using (MemoryStream ms = new MemoryStream()) {
                PdfWriter.GetInstance(doc, ms);
                doc.Open();


                Paragraph title = new Paragraph("Reporte clientes");
                title.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);

                //agregar espacio entre titulo y tabla de datos
                Paragraph espacio = new Paragraph(" ");

                //agregar al documento
                doc.Add(espacio);

                //parametros las columnas(id, nombre, apellidos, genero, email)
                PdfPTable table = new PdfPTable(5);

                //Ancho de las columnas
                float[] vaules = new float[5] { 10, 20, 30, 10, 40 };

                //asignar los anchos de la tabla
                table.SetWidths(vaules);

                //cerar primer celda
                PdfPCell celda1 = new PdfPCell(new Phrase("ID"));
                celda1.BackgroundColor = new BaseColor(130, 130, 130);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Nombre"));
                celda2.BackgroundColor = new BaseColor(130, 130, 130);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Apellidos"));
                celda3.BackgroundColor = new BaseColor(130, 130, 130);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Genero"));
                celda4.BackgroundColor = new BaseColor(130, 130, 130);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda4);

                PdfPCell celda5 = new PdfPCell(new Phrase("Email"));
                celda5.BackgroundColor = new BaseColor(130, 130, 130);
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda5);

                //contenido de la tabla/ datos
                List<ClientesClass> lista = (List<ClientesClass>)Session["Lista"];

                int nregistros = lista.Count;

                for (int i = 0; i < nregistros; i++){
                    table.AddCell(lista[i].idC_liente.ToString());
                    table.AddCell(lista[i].nombre_Cliente);
                    table.AddCell(lista[i].apellido_Cliente);
                    table.AddCell(lista[i].Genero.ToString());
                    table.AddCell(lista[i].eMail);


                }
                doc.Add(table);
                doc.Close();
                buffer= ms.ToArray();


            }
            return File(buffer, "application/pdf");

        }
        // GET: Clientes
        //Mostrar datos de la tabla
        public ActionResult Index()
        {
            List<ClientesClass> listaClientes = new List<ClientesClass>();
            using (IDGS81NETEntities db = new IDGS81NETEntities())
            {
                listaClientes = (from d in db.Clientes
                                 select new ClientesClass
                                 {
                                     idC_liente = d.idC_liente,
                                     nombre_Cliente = d.nombre_Cliente,
                                     apellido_Cliente = d.apellido_Cliente,
                                     eMail = d.eMail,
                                     Genero = d.Genero,
                                     eStatus = (int)d.Estatus

                                 }).ToList();
                Session["Lista"] = listaClientes;
            }

            return View(listaClientes);
        }
        //Eliminar un cliente
        public ActionResult DeleteCliente(int id)
        {
            using (IDGS81NETEntities db = new IDGS81NETEntities())
            {
                Clientes oTabla = db.Clientes.Find(id);
                db.Clientes.Remove(oTabla);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //Editar un cliente
        

public ActionResult EditarCliente(int id)
        {
            llamarSexo();
            ViewBag.lista = listaSexo;

            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            ClientesClass modelo;
            using (IDGS81NETEntities db = new IDGS81NETEntities())
            {
                Clientes cliente = db.Clientes.Where(d => d.idC_liente == id).FirstOrDefault();
                modelo = new ClientesClass
                {
                    idC_liente = cliente.idC_liente,
                    nombre_Cliente = cliente.nombre_Cliente,
                    apellido_Cliente = cliente.apellido_Cliente,
                    eMail = cliente.eMail,
                    Genero = cliente.Genero,
                    eStatus = (int)cliente.Estatus
                };

                if (cliente != null)
                {
                    return View(modelo);
                }
            }

            return RedirectToAction("Index");
        }


        //crear un nuevo cliente
        List<SelectListItem> listaSexo;
        public void llamarSexo()
        {
            using (var bd = new IDGS81NETEntities())
            {
                listaSexo = (from GeneroClass in bd.Genero
                             select GeneroClass.id_Sexo).ToList()
              .Select(x => new SelectListItem
              {
                  Text = bd.Genero.Where(y => y.id_Sexo == x).FirstOrDefault().sDescripcion,
                  Value = x.ToString()
              }).ToList();

                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });

                ViewBag.lista = listaSexo;

            }
        }
        [HttpPost]
        public ActionResult EditarCliente(ClientesClass model)
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
                        Clientes oTabla = db.Clientes.Where(d => d.idC_liente == model.idC_liente).FirstOrDefault();
                        oTabla.nombre_Cliente = model.nombre_Cliente;
                        oTabla.apellido_Cliente = model.apellido_Cliente;
                        oTabla.eMail = model.eMail;
                        oTabla.Genero = model.Genero;
                        oTabla.Estatus = model.eStatus;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }

            }

        }
        public ActionResult NuevoCliente()
        {
            llamarSexo();
            ViewBag.lista = listaSexo;
            return View();
        }



        [HttpPost]
        public ActionResult NuevoCliente(ClientesClass model)
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
                        Clientes oTabla = new Clientes();
                        oTabla.nombre_Cliente = model.nombre_Cliente;
                        oTabla.apellido_Cliente = model.apellido_Cliente;
                        oTabla.eMail = model.eMail;
                        oTabla.Genero = model.Genero;
                        oTabla.Estatus = model.eStatus;

                        db.Clientes.Add(oTabla);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
               
            }
            
        }
        public FileResult GenerarExcel()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Reporte clientes");

            //agregar los headers
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Nombre";
            worksheet.Cell(1, 3).Value = "Apellidos";
            worksheet.Cell(1, 4).Value = "Genero";
            worksheet.Cell(1, 5).Value = "Email";

            //llenar la tabla
            List<ClientesClass> lista = (List<ClientesClass>)Session["Lista"];
            int nregistros = lista.Count;

            for (int i = 0; i < nregistros; i++)
            {
                worksheet.Cell(i + 2, 1).Value = lista[i].idC_liente;
                worksheet.Cell(i + 2, 2).Value = lista[i].nombre_Cliente;
                worksheet.Cell(i + 2, 3).Value = lista[i].apellido_Cliente;
                worksheet.Cell(i + 2, 4).Value = lista[i].Genero;
                worksheet.Cell(i + 2, 5).Value = lista[i].eMail;
            }

            //configuración de formato
            worksheet.Row(1).Style.Font.Bold = true;
            string file = "ReporteClientes.xlsx";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), file);
            workbook.SaveAs(path);
            return File(path, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}