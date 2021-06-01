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
        public List<Models.TbFilme> Listar()
        {
            List<Models.TbFilme> lista = b.Listar();

            return lista;
        }

        [HttpGet("consultar")]
        public List<Models.TbFilme> Consultar(string genero)
        {
            
            List<Models.TbFilme> lista = b.Consultar(genero);

            return lista;
        }
        
        [HttpPut]
        public void Alterar (Models.TbFilme filme)
        {
            b.Alterar(filme);

        }

       [HttpPut("disponibilidade")]
        public void AlterarDispobinibilidade(Models.TbFilme filme)
        {
            b.AlterarDispobinibilidade(filme);
        }

        [HttpDelete]
        public void Remover(Models.TbFilme filme)
        {
            b.Remover(filme);
        }

    }
}