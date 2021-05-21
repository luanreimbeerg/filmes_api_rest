using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;


namespace filmes_api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class AtorrController : ControllerBase
    {
        [HttpPost]

        public Models.TbAtor Salvar(Models.TbAtor ator)    
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            ctx.TbAtor.Add(ator);
            ctx.SaveChanges();
            
            return ator;
        }


    }
}