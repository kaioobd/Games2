using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Games2.Models
{
    public class Jogo
    {
        [Display(Name = "Código do Jogo")]
        [Required(ErrorMessage = "O preenchimento do campo código é obrigatório")]
        public Int64 jogoCod { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O preenchimento do campo nome é obrigatório")]
        public string jogoNome { get; set; }

        [Display(Name = "Versão")]
        public string jogoVersao { get; set; }

        [Display(Name = "Desenvolvedores")]
        [Required(ErrorMessage = "O preenchimento do campo desenvolvedor é obrigatório")]
        public string jogoDev { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O preenchimento do campo gênero é obrigatório")]
        public string jogoGenero { get; set; }

        [Display(Name = "Faixa Etaria")]
        [Required(ErrorMessage = "O preenchimento do campo faixa etária é obrigatório")]
        public string jogoFaixaEtaria { get; set; }

        [Display(Name = "Plataforma")]
        [Required(ErrorMessage = "O preenchimento do campo plataforma é obrigatório")]
        public string jogoPlataf { get; set; }

        [Display(Name = "Ano de Lançamento")]
        [Required(ErrorMessage = "O preenchimento do campo ano de lançamento é obrigatório")]
        public Int64 jogoAnoLanc { get; set; }

        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "O preenchimento do campo sinopse é obrigatório")]
        public string jogoSinopse { get; set; }
    }

}