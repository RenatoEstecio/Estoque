using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Estoque.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        [HttpGet]
        public List<Produto> Get()
        {
            return new Arquivo().Lista;
        }

        [HttpGet("{id:int}")]
        public Produto Get(int id)
        {
            return new Arquivo().Get(id);           
        }
      
        [HttpPost]
        public Produto Add(Produto p)
        {
            return new Arquivo().AddProduto(p.Descricao, p.Valor);
        }

        [HttpPatch("{id:int}")]
        public Produto Patch(int id,Produto p)
        {
            return new Arquivo().UpdateProduto(id,p);
        }

        [HttpDelete("{id:int}")]
        public Produto Delete(int id)
        {
            return new Arquivo().RemoveProduto(id);
        }
    }
}