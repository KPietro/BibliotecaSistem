using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSistem.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string NumeroSerial { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public decimal Paginas { get; set; } = 0;
        public bool Disponivel { get; set; } = true;
    }
}
