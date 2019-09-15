using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Web.Areas.AreaIndex.Models;
using Project.Repository.Persistence;
using Project.Entity.Enuns;
using Project.Entity;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class ContaController : Controller
    {
        // GET: AreaIndex/Conta
        public ActionResult ManutencaoConta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Consultar()
        {
            string sBusca = Request.Params["sBusca"].ToString().ToUpper();
            string sStatus = Request.Params["sStatus"].ToString().ToUpper();

            List<ContaViewModelConsulta> lista = new List<ContaViewModelConsulta>();
            try
            {
                ContaPersistence cp = new ContaPersistence();
                foreach (var item in cp.ListarTodos())
                {
                    ContaViewModelConsulta model = new ContaViewModelConsulta();
                    model.Id = item.Id;
                    model.Descricao = item.Descricao;
                    model.Status = item.Status;


                    if (item.Status.Equals("A"))
                    {
                        model.DescricaoStatus = Status.A.ObterDescricao();
                    }
                    else if (item.Status.Equals("I"))
                    {
                        model.DescricaoStatus = Status.I.ObterDescricao();
                    }
                    else
                    {
                        model.DescricaoStatus = "Valor Desconhecido";
                    }

                    lista.Add(model);

                    if (sBusca.Trim().Length > 0)
                    {
                        lista = lista.Where(c => c.Descricao.Trim().ToUpper().Contains(sBusca.Trim().ToUpper())).ToList();
                    }
                    if (sStatus.Length > 0 && !sStatus.Equals("-1"))
                    {
                        lista = lista.Where(f => f.Status.Equals(sStatus)).ToList();
                    }

                }
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(new { aaData = lista }, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Inclusao()
        {
            return View();
        }

        public ActionResult Edicao( int id)
        {
            try
            {
                ContaPersistence cp = new ContaPersistence();
                Conta c = cp.ObterPorId(id);

                ViewBag.Id = c.Id;
                ViewBag.Descricao = c.Descricao;
                ViewBag.Status = c.Status;
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        [HttpPost]
        public JsonResult Incluir(string descricao)
        {
            var _cod = -1;
            var _msg = "";

            try
            {
                if (descricao.Trim().Length > 0)
                {
                    ContaPersistence cp = new ContaPersistence();

                    if (cp.ObterPorDescricao(descricao).Count > 0)
                    {
                        _msg = "A Conta " + descricao + " já está cadastrada";
                    }
                    else
                    {

                        cp.Inserir(new Conta()
                        {
                            Descricao = descricao
                        });

                        _cod = 1;
                        _msg = "A Conta <strong>" + descricao + "</strong> foi cadastrada com sucesso";
                    }
                }
                else
                {
                    _msg = "A Conta deve ser preenchida";
                }

            }
            catch (Exception ex)
            {
                return Json(new { cod = _cod, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { cod = _cod, msg = _msg }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var msg = "";
            try
            {
                ContaPersistence cp = new ContaPersistence();
                Conta c = new Conta();
                c = cp.ObterPorId(id);
                cp.Excluir(c);

                msg = "A Conta <strong>" + c.Descricao + "</strong> foi excluída com sucesso!";

            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Editar(ContaViewModelEdicao model)
        {
            var _cod = -1;
            var _msg = "";
            try
            {
                ContaPersistence cp = new ContaPersistence();

                Conta c = cp.ObterPorId(model.Id);

                c.Descricao = model.Descricao;
                c.Status = model.Status;

                cp.Atualizar(c);
                _cod = 1;
                _msg = "A Conta <strong>" + model.Descricao + "</strong> foi editada com sucesso!";
            }
            catch (Exception ex)
            {
                _msg = ex.Message;
            }
            return Json(new { cod = _cod, msg = _msg }, JsonRequestBehavior.AllowGet);
        }
    }
}