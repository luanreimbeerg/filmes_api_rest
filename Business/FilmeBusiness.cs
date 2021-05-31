using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace filmes_api_rest.Business
{
    public class FilmeBusiness
    {
        Database.FilmeDatabase db = new Database.FilmeDatabase();
        
        public Models.TbFilme Salvar(Models.TbFilme filme)
        {
            if(string.IsNullOrEmpty(filme.NmFilme))
                throw new ArgumentException("Nome é obrigatório");
            
            if(string.IsNullOrEmpty(filme.DsGenero))
                throw new ArgumentException("Gênero é obrigatorio");
            
            if(filme.VlAvaliacao < 0)
                throw new ArgumentException("Avaliação é obrigatorio");
            
            if(db.FilmeExiste(filme.NmFilme) == true)
                throw new ArgumentException("Filme já cadastrado!");
  

            Models.TbFilme f = db.Salvar(filme);
            return f;
        }

        public List<Models.TbFilme> Listar()
        {
            List<Models.TbFilme> lista = db.Listar();
            return lista;   
        }

        public List<Models.TbFilme> Consultar(string genero)
        {
           if(string.IsNullOrEmpty(genero))
                throw new ArgumentException("O gênero não pode ficar vazio");

            List<Models.TbFilme> lista = db.Consultar(genero);

            return lista;
        }

        public void Alterar (Models.TbFilme filme)
        {

          db.Alterar(filme);
        }

        public void AlterarDispobinibilidade(Models.TbFilme filme)
        {
         db.AlterarDispobinibilidade(filme);
        }

        public void Remover(Models.TbFilme filme)
        {
            db.Remover(filme);
        }

    }
}