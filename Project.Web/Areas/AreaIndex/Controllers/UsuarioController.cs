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
    public class UsuarioController : Controller
    {
        public ActionResult ConsultaFiltro()
        {

            return View();
        }

        public ActionResult Inclusao()
        {

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

            return View(model);
        }

        [HttpPost]
        public JsonResult Consultar(UsuarioViewModelFiltro model)
        {

            UsuarioPersistence up = new UsuarioPersistence();

            IEnumerable<Usuario> usuarios = null;

            if (model.Busca != null)
            {
                usuarios = up.ListarTodos().Where(u => u.IdUsuario.Contains(model.Busca) || u.Nome.Contains(model.Busca))
                                           .OrderBy(u => u.IdUsuario);
            }

            if (model.Id_Perfil > 0)
            {
                if (usuarios == null)
                {
                    usuarios = up.ListarTodos().OrderBy(u => u.IdUsuario);
                }
                usuarios = usuarios.Where(u => u.IdPerfil.Equals(model.Id_Perfil));
            }

            if (model.IdStatus != "-1" && model.IdStatus != null)
            {
                if (usuarios == null)
                {
                    usuarios = up.ListarTodos().OrderBy(u => u.IdUsuario);
                }
                usuarios = usuarios.Where(u => u.Status.Equals(model.IdStatus == Convert.ToString(-1) ? "" : model.IdStatus));
            }

            List<UsuarioViewModelConsulta> lista = new List<UsuarioViewModelConsulta>();

            foreach (var item in usuarios)
            {
                UsuarioViewModelConsulta u = new UsuarioViewModelConsulta();
                u.IdUsuario = item.IdUsuario;
                u.Nome = item.Nome;
                u.Perfil = item.Perfil.Descricao;
                u.Status = item.Status;

                lista.Add(u);
            }

            return Json(lista);
        }



        [HttpPost]
        public ActionResult Incluir(UsuarioViewModelInclusao usuarioModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();

                    if (up.LoginExistente(usuarioModel.Id_Usuario) > 0)
                    {
                        ViewBag.Mensagem = "O Login informado já existe";
                    }
                    else
                    {

                        Usuario u = new Usuario();

                        u.IdUsuario = usuarioModel.Id_Usuario;
                        u.Nome = usuarioModel.Nome;
                        u.Senha = Criptografia.EncriptarSenha(usuarioModel.Senha);
                        u.IdPerfil = usuarioModel.Id_Perfil;

                        up.Inserir(u);

                        RedirectToAction("ConsultaFiltro");
                    }

                    ViewBag.Mensagem = "Operação realizada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message.ToString();
            }

            return PartialView(usuarioModel);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioViewModelEdicao usuarioModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    Usuario u = new Usuario();

                    u.IdUsuario = usuarioModel.Id_Usuario;
                    u.Nome = usuarioModel.Nome;
                    u.IdPerfil = usuarioModel.Id_Perfil;

                   // up.Atualizar(u);
                    TempData["MensagemEdicao"] = $"Os dados do usuário {usuarioModel.Nome} foram salvos com sucesso!";
                    
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message.ToString() });

            }

            return Json(" ");
        }
        
        [HttpPost]
        public JsonResult ListaPerfis()
        {
            PerfilPersistence pp = new PerfilPersistence();

            List<PerfilViewModelConsulta> lista = new List<PerfilViewModelConsulta>();

            foreach (var item in pp.ListarTodos().ToList())
            {
                PerfilViewModelConsulta p = new PerfilViewModelConsulta();
                p.Id = item.Id;
                p.Descricao = item.Descricao;
                lista.Add(p);
            }

            return Json(lista); 
        }
        
        [HttpPost]
        public JsonResult ListaStatus()
        {
            return Json(Combobox.Listar(typeof(Status)));
        }




    }
}