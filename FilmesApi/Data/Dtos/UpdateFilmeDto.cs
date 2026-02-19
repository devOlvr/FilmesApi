using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateFilmeDto
        {
            [Required(ErrorMessage = "O título é obrigatório")]
            [StringLength(60, ErrorMessage = "O titulo não pode exceder mais de 60 caracteres")]
            public string Titulo { get; set; }

            [Required(ErrorMessage = "O gênero é obrigatório")]
            public string Genero { get; set; }

            [Required(ErrorMessage = "O tempo de duração é obrigatório")]
            [Range(70, 600, ErrorMessage = "A duração deve estar entre 70 e 600 minutos.")]
            public int Duracao { get; set; }

        }
}

