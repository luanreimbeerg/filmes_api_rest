using System;

namespace filmes_api_rest.Models.Response
{
    public class ErroResponse
    {
        public ErroResponse(Exception ex, int codigo)
        {
            Codigo = codigo;
            Erro = ex.Message;
        }


        public int Codigo { get; set; }

        public string Erro { get; set; }

    }
}