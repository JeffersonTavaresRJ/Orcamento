using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Entity.Enuns;
using Project.Utility.UtilTables;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PermissoesController : Controller
    {
        public ActionResult Consulta()
        {
            return View();
        }

        public ActionResult Listar(string parBusca = "", string parPerfil = "-1", string parStatus = "-1")
        {
            UsuarioPersistence up = new UsuarioPersistence();

            //IEnumerable<Usuario> usuarios = null;

            //if (parBusca != null)
            //{
            //    usuarios = up.ListarTodos().Where(u => u.IdUsuario.Contains(parBusca) || u.Nome.Contains(parBusca));
            //}

            //if (parPerfil != "-1")
            //{
            //    usuarios = usuarios.Where(u => u.Perfil.IdPerfil.Equals(parPerfil));
            //}

            //if (parStatus != "-1")
            //{
            //    usuarios = usuarios.Where(u => u.Status.Equals(parStatus == Convert.ToString(-1) ? "" : parStatus));
            //}

            //if (usuarios != null)
            //{
            //    usuarios = usuarios.OrderBy(u => u.IdUsuario);
            //}

            var usuarios = up.ListarTodos().Where(u => u.IdUsuario.Contains(parBusca) || u.Nome.Contains(parBusca));
            return PartialView("Usuarios", usuarios);
        }



    }
}