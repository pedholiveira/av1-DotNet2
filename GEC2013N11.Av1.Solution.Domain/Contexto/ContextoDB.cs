using GEC2013N11.Av1.Solution.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEC2013N11.Av1.Solution.Domain.Contexto
{
    public class ContextoDB : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
    }
}
