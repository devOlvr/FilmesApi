using System.ComponentModel.DataAnnotations;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string? Nome { get; set; }
}
