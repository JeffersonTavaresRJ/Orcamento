using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Entity;
using Project.Repository.Persistence;
using Project.Entity.Enuns;
using Project.Utility.UtilComboBox;
using Project.Web.Areas.AreaIndex.Models;
using Project.Web.Models.Usuario;
using Project.Utility.UtilString;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class PermissoesController : Controller
    {
        SelectList listaPerfil;
        SelectList listaStatus;

        public ActionResult Consulta()
        {
            fPopulaCombos();

            return View();
        }

        private void fPopulaCombos()
        {
            if (listaPerfil == null)
            {
                PerfilPersistence pp = new PerfilPersistence();
                List<Perfil> listPerfil = pp.ListarTodos().ToList();
                listPerfil.Add(new Perfil { Id = -1, Descricao = "--Selecione--" });
                listaPerfil = new SelectList(listPerfil.OrderBy(p => p.Id), "Id", "Descricao", -1);
            }           

            if (listaStatus == null)
            {
                listaStatus = new SelectList(Combobox.Listar(typeof(Status)), "Key", "Value");
            }

            ViewBag.ListaPerfis = listaPerfil;
            ViewBag.ListaStatus = listaStatus;
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
            return PartialView("Usuarios", usuarios);
        }


        public ActionResult Cadastro(string id)
        {
            fPopulaCombos();

            UsuarioPersistence up = new UsuarioPersistence();
            UsuarioViewModelCadastro model = new UsuarioViewModelCadastro();

            if (id == null)
            {
                model.Acao = "I";
            }
            else
            {
                var usuario = up.ObterPorId(id);
                model.Acao = "E";
                model.Id_Usuario = usuario.IdUsuario;
                model.Nome = usuario.Nome;
                model.Id_Perfil = usuario.IdPerfil;
                model.Senha = usuario.Senha;
                model.ConfirmaSenha = usuario.Senha;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastro(UsuarioViewModelCadastro usuarioModel)
        {
            try
            {
                fPopulaCombos();

                if (ModelState.IsValid)
                {
                    UsuarioPersistence up = new UsuarioPersistence();
                    PerfilPersistence pp = new PerfilPersistence();

                    Usuario u = new Usuario();
                    u.IdUsuario = usuarioModel.Id_Usuario;
                    u.Nome = usuarioModel.Nome;
                    u.Senha = Criptografia.EncriptarSenha(usuarioModel.Senha);
                    u.IdPerfil = usuarioModel.Id_Perfil;

                    if (usuarioModel.Acao.Equals("I"))
                    {
                        if (up.LoginExistente(u.IdUsuario) > 0)
                        {
                            ViewBag.Mensagem = "O Login informado já existe";
                        }
                        else
                        {
                            up.Inserir(u);
                            //após inserir, a tela deve ser fechada
                            ModelState.Clear();//limpa os campos da tela
                        }
                        
                    }
                    else
                    {
                        up.Atualizar(u);
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




    }
}