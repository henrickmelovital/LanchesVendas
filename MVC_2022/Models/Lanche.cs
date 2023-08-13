﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_2022.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,999")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        public string ImagemThumbnailUrl { get; set; }

        [Display (Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display (Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
