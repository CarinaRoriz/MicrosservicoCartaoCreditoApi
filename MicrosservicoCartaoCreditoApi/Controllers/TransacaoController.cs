using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicrosservicoCartaoCreditoApi.Modelos;

namespace MicrosservicoCartaoCreditoApi.Controllers
{
    [Route("v1/transacoes")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        List<Transacao> listaTransacao;

        public TransacaoController()
        {
            //Situação 1: Autorizado
            listaTransacao = new List<Transacao>
            {
                new Transacao { Id = 1, IdPagamento = 1, Data = new DateTime(2019, 04, 17), IdSituacao = 1  }
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacao()
        {
            if (listaTransacao.Count() == 0)
            {
                return NotFound();
            }

            return listaTransacao;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CadastraTransacao(Transacao transacao)
        {
            try
            {
                Transacao novaTransacao = new Transacao() { Id = (listaTransacao.Max(l => l.Id) + 1), IdPagamento = transacao.IdPagamento, Data = transacao.Data, IdSituacao = 1 };
                listaTransacao.Add(novaTransacao);

                return novaTransacao.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
