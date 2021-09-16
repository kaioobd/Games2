using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Games2.Models
{
    public class Cliente
    {
        [Display (Name = "Código do Cliente")]
        [Required(ErrorMessage = "O preenchimento do campo código é obrigatório.")]
        public Int64 cliCod { get; set; }

        [Display (Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O preenchimento do campo nome é obrigatório.")]
        public string cliNome { get; set; }

        [Display (Name = "CPF")]
        [Required(ErrorMessage = "O preenchimento do campo CPF é obrigatório.")]
        public string cliCPF { get; set; }

        [Display (Name = " Data de Nascimento")]
        [Required(ErrorMessage = "O preenchimento do campo data de nascimento é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime cliDataNasc
        {
            get
            {
                return this.CliDataNasc.HasValue
                    ? this.CliDataNasc.Value
                    : DateTime.Now;
            }

            set
            {
                this.CliDataNasc = value;
            }
        }
        private DateTime? CliDataNasc = null;

        [Display (Name = "Email")]
        [Required(ErrorMessage = "O preenchimento do campo email é obrigatório.")]
        public string cliEmail { get; set; }
       
        [Display (Name = "Celular")]
        [Required(ErrorMessage = "O preenchimento do campo celular é obrigatório.")]
        public string cliCell { get; set; }

        [Display (Name = "Endereço")]
        [Required(ErrorMessage = "O preenchimento do campo endereço é obrigatório.")]
        public string cliEndereco { get; set; }

    }
}