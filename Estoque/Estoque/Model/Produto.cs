using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
    }
}
