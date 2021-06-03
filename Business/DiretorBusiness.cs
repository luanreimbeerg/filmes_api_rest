using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace filmes_api_rest.Business
{
    public class DiretorBusiness
    {
        Database.DiretorDatabase db = new Database.DiretorDatabase();

           public Models.TbDiretor Salvar(Models.TbDiretor diretor)
        {
            if (diretor.NmDiretor == string.Empty)
                throw new ArgumentException("O campo do nome do diretor não pode ficar vazio");
            if (diretor.NmDiretor == null)
                throw new ArgumentException("O campo do nome não pode ser nulo");
            
            db.Salvar(diretor);
            return diretor;
        }

        public Models.Response.DiretorResponsePorNome SalvarPorNome(Models.Request.DiretorRequest diretorReq)
        {
            Models.Response.DiretorResponsePorNome diretor = db.SalvarPorNome(diretorReq);

            return diretor;

        }


        public List<Models.Response.DiretorResponse> Listar()
        {    
            List<Models.Response.DiretorResponse> lista = db.Listar();
            return lista;
        }

        public void Alterar(Models.TbDiretor diretor)
        {
            db.Alterar(diretor);

        }

        public void Deletar (Models.TbDiretor diretor)
        {
           db.Deletar(diretor);
        }
       
    }
}