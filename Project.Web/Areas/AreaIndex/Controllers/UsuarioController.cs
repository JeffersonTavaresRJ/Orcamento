using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Entity.Enuns;
using Project.Utility.UtilComboBox;
using Project.Web.Areas.AreaIndex.Models;
using Project.Utility.UtilString;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        string mensagem = null;

        public ActionResult ManutencaoUsuario()
        {

            return View();
        }

        public ActionResult Inclusao()
        {
            PerfilPersistence pp = new PerfilPersistence();
            ViewBag.ListaPerfis = new SelectList(pp.ListarTodos().ToList(), "Id", "Descricao");
            return View();
        }

        public ActionResult Edicao(string id)
        {

            UsuarioPersistence up = new UsuarioPersistence();
            UsuarioViewModelEdicao model = new UsuarioViewModelEdicao();

            var usuario = up.ObterPorId(id);
            model.Id_Usuario = usuario.IdUsuario;
            model.Nome = usuario.Nome;
            model.Id_Perfil = usuario.IdPerfil;

            PerfilPersistence pp = new PerfilPersistence();
            ViewBag.ListaPerfis = new SelectList(pp.ListarTodos().ToList(), "Id", "Descricao");

            return View(model);
        }

        [HttpPost]
        public JsonResult Consultar()
        {

            //string sSearche = Request.Params["sSearch"].ToString();
            string sBusca =  Request.Params["sBusca"].ToString().ToUpper();
            string sPerfil = Request.Params["sPerfil"].ToString();
            string sStatus = Request.Params["sStatus"].ToString();


            UsuarioPersistence up = new UsuarioPersistence();
            IEnumerable<Usuario> totalUsuarios = up.ListarTodos();
            IList<Usuario> filtroUsuarios = totalUsuarios.ToList<Usuario>();

            if (sBusca != null)
            {
                filtroUsuarios = filtroUsuarios
                    .Where(u =>
                            (u.IdUsuario.ToUpper().Contains(sBusca.ToUpper())) ||
                            (u.Nome.ToString().ToUpper().Contains(sBusca.ToUpper()))
                     ).ToList<Usuario>();
            }

            if (sPerfil != "-1")
            {
                filtroUsuarios = filtroUsuarios
                    .Where(u => u.Perfil.Id.ToString().Contains(sPerfil.ToUpper())
                     ).ToList<Usuario>();
            }

            if (sStatus != "-1")
            {
                filtroUsuarios = filtroUsuarios
                    .Where(u => u.Status.ToString().Contains(sStatus.ToUpper())
                     ).ToList<Usuario>();
            }

            List<UsuarioViewModelConsulta> lista = new List<UsuarioViewModelConsulta>();

            foreach (var item in filtroUsuarios)
            {
                UsuarioViewModelConsulta u = new UsuarioViewModelConsulta();
                u.IdUsuario = item.IdUsuario;
                u.Nome = item.Nome;
                u.Perfil = item.Perfil.Descricao;
                u.Status = item.Status;

                lista.Add(u);
            }

            var Resultado = new
            {
                aaData = lista
            };

            return Json(Resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Incluir(UsuarioViewModelInclusao usuarioModel)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();

                    if (up.LoginExistente(usuarioModel.Id_Usuario) > 0)
                    {
                        mensagem = "O Login informado já existe";
                    }
                    else
                    {

                        Usuario u = new Usuario();

                        u.IdUsuario = usuarioModel.Id_Usuario;
                        u.Nome = usuarioModel.Nome;
                        u.Senha = Criptografia.EncriptarSenha("ABC123");
                        u.IdPerfil = usuarioModel.Id_Perfil;

                        up.Inserir(u);
                        mensagem = $"Os dados do usuário {usuarioModel.Nome} foram gravados com sucesso!";
                    }
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message.ToString();
            }

            return Json(new { msg = mensagem });
        }

        [HttpPost]
        public JsonResult Editar(UsuarioViewModelEdicao usuarioModel)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    Usuario u = up.ObterPorId(usuarioModel.Id_Usuario);

                    u.Nome = usuarioModel.Nome;
                    u.IdPerfil = usuarioModel.Id_Perfil;

                    if (usuarioModel.RedefinirSenha)
                    {
                        u.Senha = Criptografia.EncriptarSenha("ABC123");
                    }

                    up.Atualizar(u);
                    mensagem = $"Os dados do usuário {usuarioModel.Nome} foram editados com sucesso!";

               }
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message.ToString() });

            }

            return Json(new { msg = mensagem });
        }

        [HttpPost]
        public JsonResult Excluir(string id)
        {

            try
            {
                    UsuarioPersistence up = new UsuarioPersistence();
                    Usuario u = up.ObterPorId(id);

                    up.Excluir(u);
                    mensagem = $"Os dados do usuário {u.Nome} foram excluídos com sucesso!";                
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message.ToString() });

            }

            return Json(new { msg = mensagem });
        }

        [HttpPost]
        public JsonResult ListaStatus()
        {
            return Json(Combobox.Listar(typeof(Status)));
        }




    }
}