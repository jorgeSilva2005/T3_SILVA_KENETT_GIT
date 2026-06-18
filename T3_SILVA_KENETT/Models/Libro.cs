using System.ComponentModel.DataAnnotations;

namespace T3_SILVA_KENETT.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "El autor del libro es obligatorio.")]
        public required string Autor { get; set; }

        [Required(ErrorMessage = "El tema del libro es obligatorio.")]
        public required string Tema { get; set; }

        [Required(ErrorMessage = "La editorial del libro es obligatoria.")]
        public required string Editorial { get; set; }

        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "El año de publicación debe estar entre 1900 y 3000.")]
        public int AnioPublicacion { get; set; }

        [Required(ErrorMessage = "La cantidad de páginas es obligatoria.")]
        [Range(10, 1000, ErrorMessage = "Las páginas deben estar entre 10 y 1000.")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "La categoría del libro es obligatoria.")]
        public required string Categoria { get; set; }

        [Required(ErrorMessage = "El material del libro es obligatorio.")]
        public required string Material { get; set; }

        [Required(ErrorMessage = "La cantidad de copias es obligatoria.")]
        [Range(1, 20, ErrorMessage = "Las copias deben estar entre 1 y 20.")]
        public int Copias { get; set; }
    }
}
