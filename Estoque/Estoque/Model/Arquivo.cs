using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Estoque.Model
{
    public class Arquivo
    {
        public List<Produto> Lista { get; }

        public Arquivo()
        {
            try { Lista = JsonConvert.DeserializeObject<List<Produto>>(Load()); } 
            catch { Lista = new List<Produto>(); }
        }
        public Produto AddProduto(string descricao, decimal valor)
        {
            var p = new Produto();
            p.Id = Lista.Count() == 0 ? 1 : Lista.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            p.Descricao = descricao;
            p.Valor = valor;
            p.DataCadastro = DateTime.Now;
            p.SerialNumber = Random(20);
            Lista.Add(p);
            Write();
            return p;
        }

        public Produto UpdateProduto(int id,Produto prod)
        {
            var p = Get(id);
            p.Descricao = prod.Descricao;
            p.Valor = prod.Valor;
            Write();
            return p;
        }

        public Produto RemoveProduto(int id)
        {
            var p = Get(id);
            Lista.Remove(p);
            Write();
            return p;
        }

        public Produto Get(int id)
        {
            return Lista.Where(x => x.Id == id).FirstOrDefault();
        }

        void Write()
        {
            File.WriteAllText("Arquivo.json", JsonConvert.SerializeObject(Lista,Formatting.Indented));
        }
        string Load()
        {
            return File.ReadAllText("Arquivo.json");
        }
        
        static string Random(int length)
        {
            string vet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            var aux = string.Empty;

            for (int i = length; i > 0; i--)
                aux+= vet[new Random().Next(vet.Length)];

            return aux;
        }
    }
}
