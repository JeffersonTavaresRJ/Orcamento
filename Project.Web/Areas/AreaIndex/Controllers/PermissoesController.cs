using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Entity.Enuns;
using Project.Utility.UtilTables;
using Project.Utility.UtilComboBox;
using Project.Web.Areas.AreaIndex.Models;
using System.Collections;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PermissoesController : Controller
    {
        public ActionResult Consulta()
        {
            PerfilPersistence pp = new PerfilPersistence();

            List<Perfil> listPerfil = pp.ListarTodos().ToList();
            listPerfil.Add(new Perfil { IdPerfil = -1, Descricao = "--Selecione--" });
            ViewBag.ListaPerfis = new SelectList(listPerfil.OrderBy(p=>p.IdPerfil), "IdPerfil", "Descricao", -1);

            ViewBag.ListaStatus = new SelectList(Combobox.Listar(typeof(Status)), "Key", "Value");
            return View();
        }

        public ActionResult Listar(PermissoesViewModelFiltro model)
        {
            UsuarioPersistence up = new UsuarioPersistence();

            IEnumerable<Usuario> usuarios = null;

            if (model.Busca != null)
            {
                usuarios = up.ListarTodos().Where(u => u.IdUsuario.Contains(model.Busca) || u.Nome.Contains(model.Busca))
                                           .OrderBy(u => u.IdUsuario);
            }

            if (model.IdPerfil > 0)
            {
                if (usuarios == null)
                {
                    usuarios = up.ListarTodos().OrderBy(u => u.IdUsuario);
                }
                usuarios = usuarios.Where(u => u.IdPerfil.Equals(model.IdPerfil));
            }

            if (model.IdStatus != "-1" && model.IdStatus != null)
            {
                if (usuarios == null)
                {
                    usuarios = up.ListarTodos().OrderBy(u => u.IdUsuario);
                }
                usuarios = usuarios.Where(u => u.Status.Equals(model.IdStatus == Convert.ToString(-1) ? "" : model.IdStatus));
            }
            return PartialView("Usuarios", usuarios);
        }



    }
}