using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEC2013N11.Av1.Solution.Domain.Entidade
{
    public class Aluno
    {
        public Aluno()
        {
        }

        public Aluno(string Nome, string Sobrenome, string NomeCurso, bool Ativo)
        {
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.NomeCurso = NomeCurso;
            this.Ativo = Ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCurso { get; set; }
        public bool Ativo { get; set; }
    }
}
