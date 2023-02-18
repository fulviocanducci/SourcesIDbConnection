using System.ComponentModel.DataAnnotations;
namespace Data
{
   public class People
   {
      public ulong Id { get; set; }

      [Required(ErrorMessage = "Digite o nome")]
      [MaxLength(100, ErrorMessage = "Até 100 caracteres")]
      public string Name { get; set; }
   }
}