using System;
using System.Web.Mvc;
using Project.Repository.Persistence;
using System.Linq;
using System.Collections.Generic;
using Project.Web.Areas.AreaIndex.Models;
using Project.Entity;
using Project.Entity.Enuns;

namespace Project.Web.Areas.AreaIndex.Controllers
{
    public class FormaPagamentoController : Controller
    {
        // GET: AreaIndex/FormaPagamento
        public ActionResult ManutencaoFormaPagamento()
        {
            return View();
        }

        public ActionResult Inclusao()
        {
            return View();
        }

        public ActionResult Edicao(int id)
        {
            FormaPagamentoPersistence fpp = new FormaPagamentoPersistence();
            FormaPagamento fp = fpp.ObterPorId(id);

            ViewBag.Id = id;
            ViewBag.Descricao = fp.Descricao;
            ViewBag.Status = fp.Status;

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
                    FormaPagamentoPersistence fpp = new FormaPagamentoPersistence();

                    if (fpp.ObterPorDescricao(descricao).Count > 0)
                    {
                        _msg = "A Forma de Pagamento " + descricao + " já está cadastrada";
                    }
                    else
                    {

                        fpp.Inserir(new FormaPagamento()
                        {
                            Descricao = descricao
                        });

                        _cod = 1;
                        _msg = "A Forma de Pagamento <strong>" + descricao + "</strong> foi cadastrada com sucesso";
                    }
                }
                else
                {
                    _msg = "A Forma de Pagamento deve ser preenchida";
                }

            }
            catch (Exception ex)
            {
                return Json(new { cod = _cod, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { cod = _cod, msg = _msg }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Editar(FormaPagamentoViewModelEdicao model)
        {
            var _cod = -1;
            var _msg = "";
            try
            {
                FormaPagamentoPersistence fpp = new FormaPagamentoPersistence();

                FormaPagamento fp = fpp.ObterPorId(model.Id);

                fp.Descricao = model.Descricao;
                fp.Status = model.Status;

                fpp.Atualizar(fp);
                _cod = 1;
                _msg = "A Forma de Pagamento <strong>" + model.Descricao + "</strong> foi editada com sucesso!";
            }
            catch (Exception ex)
            {
                _msg = ex.Message;
            }
            return Json(new { cod = _cod, msg = _msg }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Consultar()
        {
            string sBusca = Request.Params["sBusca"].ToString().ToUpper();
            string sStatus = Request.Params["sStatus"].ToString();

            List<FormaPagamentoViewModelConsulta> lista = new List<FormaPagamentoViewModelConsulta>();
            try
            {
                FormaPagamentoPersistence fpp = new FormaPagamentoPersistence();

                foreach (var item in fpp.ListarTodos().ToList())
                {

                    FormaPagamentoViewModelConsulta fp = new FormaPagamentoViewModelConsulta();
                    fp.Id = item.Id;
                    fp.Descricao = item.Descricao;
                    fp.Status = item.Status;

                    if (item.Status.Equals("A"))
                    {
                        fp.DescricaoStatus = Status.A.ObterDescricao();
                    }
                    else if (item.Status.Equals("I"))
                    {
                        fp.DescricaoStatus = Status.I.ObterDescricao();
                    }
                    else
                    {
                        fp.DescricaoStatus = "Valor Desconhecido";
                    }

                    lista.Add(fp);

                };


                if (sBusca.Trim().Length > 0)
                {
                    lista = lista.Where(f => f.Descricao.Trim().ToUpper().Contains(sBusca.Trim().ToUpper())).ToList();
                }
                if ( sStatus.Length >0 && !sStatus.Equals("-1"))
                {
                    lista = lista.Where(f => f.Status.Equals(sStatus)).ToList();
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                aaData = lista
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var msg = "";
            try
            {
                FormaPagamentoPersistence fpp = new FormaPagamentoPersistence();
                FormaPagamento fp = new FormaPagamento();
                fp = fpp.ObterPorId(id);
                fpp.Excluir(fp);

                msg = "A Forma de Pagamento <strong>" + fp.Descricao + "</strong> foi excluída com sucesso!";

            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

    }
}