using System;
using System.ComponentModel.DataAnnotations;

namespace MvcTeste.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Display(Name = "Nome do aluno")]
        public string Nome { get; set; }
        [Display(Name = "Senha do aluno")]
        public string Senha { get; set; }
        [Display(Name = "Data cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [Display(Name = "Esta ativo?")]
        public bool IsAtivo { get; set; }    
        public int IdCurso { get; set; } = 0;
        public Curso Curso { get; set; }
      
    }
}