namespace filmes_api_rest.Models.Request
{
    public class FilmeDiretorRequest
    {
        public Models.TbFilme Filme { get; set; }

        public Models.TbDiretor Diretor { get; set; }
        
    }
}