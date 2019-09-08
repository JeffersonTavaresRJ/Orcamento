using Project.Entity.Enuns;
using Project.Repository.Persistence;
using Project.Utility.UtilComboBox;
using Project.Web.Areas.AreaIndex.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class ListaController : Controller
    {
        [HttpPost]
        public JsonResult Status()
        {
            return Json(Combobox.Listar(typeof(Status)));
        }

        [HttpPost]
        public JsonResult Perfil()
        {
            ArrayList lista = new ArrayList();
            try
            {

                PerfilPersistence pp = new PerfilPersistence();
                foreach (var item in pp.ListarTodos().ToList())
                {
                    lista.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Descricao.ToString()));

                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FormaPagamento()
        {
            ArrayList lista = new ArrayList();
            try
            {
                FormaPagamentoPersistence fpp = new FormaPagamentoPersistence();
                foreach (var item in fpp.ListarTodos().ToList())
                {
                    lista.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Descricao.ToString()));
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}