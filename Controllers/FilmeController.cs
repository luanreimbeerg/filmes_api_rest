using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace filmes_api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

         Business.FilmeBusiness b = new Business.FilmeBusiness();
        
        [HttpPost]
        public ActionResult<Models.TbFilme> Salvar(Models.TbFilme filme)
        {
            try
            {
                Models.TbFilme film = b.Salvar(filme);
                return film;
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }

        }

        [HttpGet]
        public ActionResult<List<Models.TbFilme>> Listar()
        {
            try
            {
                List<Models.TbFilme> lista = b.Listar();

            return lista;
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }
        }

        [HttpGet("consultar")]
        public ActionResult<List<Models.TbFilme>> Consultar(string genero)
        {
            try
            {
                
            List<Models.TbFilme> lista = b.Consultar(genero);
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
        public void Alterar (Models.TbFilme filme)
        {
           try
           {
                b.Alterar(filme);
           }
           catch (System.Exception ex)
           {
               return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
               
           }

        }

       [HttpPut("disponibilidade")]
        public void AlterarDispobinibilidade(Models.TbFilme filme)
        {
            try
            {
                b.AlterarDispobinibilidade(filme);
            }
            catch (System.Exception ex)
            {
                
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }
        }

        [HttpDelete]
        public void Remover(Models.TbFilme filme)
        {
             try
            {
                b.Remover(filme);
            }
            catch (System.Exception ex)
            {
                
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(ex, 400)
                );
            }
        }

    }
}