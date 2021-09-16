using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Games2.Models
{
    public class Funcionario
    {
        [Display (Name = "Código do Funcionário")]
        [Required(ErrorMessage = "O preenchimento do campo código é obrigatório.")]
        public Int64 funcCod { get; set; }

        [Display (Name = "Nome")]
        [Required(ErrorMessage = "O preenchimento do campo código é obrigatório.")]
        public string funcNome { get; set; }

        [Display (Name = "CPF")]
        [Required(ErrorMessage = "O preenchimento do campo CPF é obrigatório.")]
        public string funcCPF { get; set; }

        [Display (Name = "RG")]
        [Required(ErrorMessage = "O preenchimento do campo RG é obrigatório.")]
        public string funcRG { get; set; }


        [Display (Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O preenchimento do campo data nascimento é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime funcDataNasc
        {
            get
            {
                return this.FuncDataNasc.HasValue
                    ? this.FuncDataNasc.Value
                    : DateTime.Now;
            }
            set
            {
                this.FuncDataNasc = value;
            }
        }
        private DateTime? FuncDataNasc = null;

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O preenchimento do campo endereço é obrigatório.")]
        public string funcEndereco { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O preenchimento do campo celular é obrigatório.")]
        public string funcCell { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O preenchimento do campo email é obrigatório.")]
        public string funcEmail { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O preenchimento do campo cargo é obrigatório.")]
        public string funcCargo { get; set; }


    }
}