using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BibliotecaCLI.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; } 

        public int UsuarioId { get; set; }
        public int LivroId { get; set; }

        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}