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
         Database.FilmeDatabase db = new Database.FilmeDatabase();
        
        [HttpPost]
        public Models.TbFilme Salvar(Models.TbFilme filme)
        {
            Models.TbFilme film = db.Salvar(filme);

            return film;
        }

        [HttpGet]
        public List<Models.TbFilme> Listar()
        {
            List<Models.TbFilme> lista = db.Listar();

            return lista;
        }
        [HttpGet("consultar")]
    
        public List<Models.TbFilme> Consultar(string genero)
        {
            
            List<Models.TbFilme> lista = db.Consultar(genero);

            return lista;
        }
        [HttpPut]

        public void Alterar (Models.TbFilme filme)
        {
            db.Alterar(filme);

        }

       [HttpPut("disponibilidade")]

        public void AlterarDispobinibilidade(Models.TbFilme filme)
        {
            db.AlterarDispobinibilidade(filme);
        }

        [HttpDelete]

        public void Remover(Models.TbFilme filme)
        {
            db.Remover(filme);
        }

    }
}