using Project.Entity.Enuns;
using Project.Repository.Persistence;
using Project.Utility.UtilComboBox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Entity;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class ListaController : Controller
    {
        //leitura a partir de enuns..
        [HttpPost]
        public JsonResult Status()
        {
            return Json(Combobox.Listar(typeof(Status)));
        }

        [HttpPost]
        public JsonResult TipoItemConta()
        {
            return Json(Combobox.Listar(typeof(TipoConta)));
        }

        //camadas de persistência..
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

        [HttpPost]
        public JsonResult Grupo(int? id)
        {
            ArrayList lista = new ArrayList();
            try
            {
                GrupoPersistence gp = new GrupoPersistence();
                List<Grupo> listaGrupo = new List<Grupo>();

                if (id == null)
                {
                    listaGrupo = gp.ListarGruposNivel_1().ToList();
                }
                else
                {

                    listaGrupo = gp.ListarGruposNivel_2((int)id).ToList();
                }

                foreach (var item in listaGrupo)
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