using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Entity.Enuns;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PermissoesController : Controller
    {
        
        public ActionResult ConsultaPermissoes()
        {
            return View();
        }
        
        
        // GET: AreaIndex/Permissoes
        public ActionResult ListaUsuarios(int pagina=1, string busca = null, string perfil=null, string status=null)
        {
            UsuarioPersistence up = new UsuarioPersistence();

            return View(up.ListarTodos().Where(u=>u.IdUsuario.Contains(busca) || 
                                                  u.Nome.Contains(busca) ||
                                                  u.Perfil.Descricao.Equals(perfil) ||
                                                  u.Status.Equals(status))
                                        .OrderBy(u=>u.Nome)
                                        .ToPagedList(pagina,5));
        }
    }
}