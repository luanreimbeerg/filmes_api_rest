using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

namespace filmes_api_rest.Database
{
    public class DiretorDatabase
    {
         public class DiretorController : ControllerBase
    {
        

        public Models.TbDiretor Salvar(Models.TbDiretor diretor)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            ctx.TbDiretor.Add(diretor);
            ctx.SaveChanges();

            return diretor;

        }

        public Models.Response.DiretorResponsePorNome SalvarPorNome(Models.Request.DiretorRequest diretorReq)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            
            Models.TbFilme filme = ctx.TbFilme.First(x => x.NmFilme == diretorReq.NmFilme);
                                                        
            Models.TbDiretor diretor = new Models.TbDiretor();
            diretor.NmDiretor = diretorReq.NmDiretor;
            diretor.DtNascimento = diretorReq.DtNascimento;
            diretor.IdFilme = filme.IdFilme;

            ctx.TbDiretor.Add(diretor);
            ctx.SaveChanges();

            Models.Response.DiretorResponsePorNome resp = new Models.Response.DiretorResponsePorNome();
            resp.IdDiretor = diretor.IdDiretor;
            resp.IdFilme = filme.IdFilme;
            resp.NmDiretor = diretor.NmDiretor;
            resp.NmFilme = filme.NmFilme;
            resp.DtNascimento = diretor.DtNascimento;

            

            return resp;

        }


        public List<Models.Response.DiretorResponse> Listar()
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            List<Models.TbDiretor> lista = ctx.TbDiretor.Include(x => x.IdFilmeNavigation)
                                                        .ToList();

            List<Models.Response.DiretorResponse> response = 
                lista.Select(x => new Models.Response.DiretorResponse{
                    IdDiretor = x.IdDiretor,
                    IdFilme = x.IdFilme,
                    Filme = x.IdFilmeNavigation.NmFilme,
                    Diretor = x.NmDiretor,
                    Genero = x.IdFilmeNavigation.DsGenero,
                    Disponivel = x.IdFilmeNavigation.BtDisponivel
                }).ToList();


            return response;

                
        }

            public void Alterar(Models.TbDiretor diretor)
            {
                Models.apiDBContext ctx = new Models.apiDBContext();

                Models.TbDiretor atual = ctx.TbDiretor.FirstOrDefault(x => x.IdDiretor == diretor.IdDiretor);

                atual.NmDiretor = diretor.NmDiretor;
                atual.DtNascimento = diretor.DtNascimento;
                
                ctx.SaveChanges();

            }

        public void Deletar (Models.TbDiretor diretor)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

             Models.TbDiretor atual = ctx.TbDiretor.First(x => x.IdDiretor == diretor.IdDiretor);

             ctx.Remove(atual);

             ctx.SaveChanges();
        }
    }
    }
}