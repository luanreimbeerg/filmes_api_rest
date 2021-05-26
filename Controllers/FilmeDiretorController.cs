using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace filmes_api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeDiretorController : ControllerBase
    {
        [HttpPost]

        public Models.Request.FilmeDiretorRequest Salvar(Models.Request.FilmeDiretorRequest request)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            ctx.TbFilme.Add(request.Filme);
            ctx.SaveChanges();

            request.Diretor.IdFilme = request.Filme.IdFilme;
            ctx.TbDiretor.Add(request.Diretor);

            ctx.SaveChanges();

            return request;
        }

        [HttpPost("encadeado")]

        public Models.TbFilme SalvarEncadeado(Models.TbFilme filme)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            ctx.TbFilme.Add(filme);
            ctx.SaveChanges();

            return filme;

        }

        [HttpGet("consultar/diretor")]

        public List<Models.TbDiretor> Cosultar()
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            List<Models.TbDiretor> lista = ctx.TbDiretor.Include(x => x.IdFilmeNavigation).ToList();

            return lista;
        }


    }
}