using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;


namespace filmes_api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiretorController : ControllerBase
    {
        Business.DiretorBusiness b = new Business.DiretorBusiness();
                
        [HttpPost]

        public ActionResult<Models.TbDiretor> Salvar(Models.TbDiretor diretor)
        {
            try
            {
                b.Salvar(diretor);
                return diretor;

            }
            catch (System.Exception ex)
            {
                
               return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }
        }

         [HttpPost("filme")]

        public ActionResult<Models.Response.DiretorResponsePorNome> SalvarPorNome(Models.Request.DiretorRequest diretorReq)
        {
            try
            {
                Models.Response.DiretorResponsePorNome diretor= b.SalvarPorNome(diretorReq);
                return diretor;
            }
            catch (System.Exception ex)
            {
                
                 return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }

        }

        [HttpGet]

        public ActionResult<List<Models.Response.DiretorResponse>> Listar()
        {
            try
            {
                List<Models.Response.DiretorResponse> lista = b.Listar();
                return lista;
            }
            catch (System.Exception ex)
            {
                
                 return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }
                
        }
         [HttpPut]

        public void Alterar(Models.TbDiretor diretor)
        {
           b.Alterar(diretor);

        }

        [HttpDelete]

        public void Deletar (Models.TbDiretor diretor)
        {
            b.Deletar(diretor);
        }
    }
}