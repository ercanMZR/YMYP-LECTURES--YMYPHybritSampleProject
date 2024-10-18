using System.ComponentModel.DataAnnotations;

namespace YMYPHybritSampleProject.Model.Services.Dto
{
    public record AddProductRequest(string Name, decimal Price, int Stock);

    /*public record class AddProductRequest
    {
        

        [Required(ErrorMessage = "İsim alanı gereklidir.")] //required kullanmak  istiyorsak propertyleri nullable yapmamız gerekir.
        public string Name { get; init; } = default!;

        [Range(1,double.MaxValue,ErrorMessage ="Fiyat alanı 0' dan büyük olmalıdır.")]
        public decimal Price { get; init; }

        [Range(1, int.MaxValue, ErrorMessage = "Fiyat alanı 0'dan büyük olmalıdır.")]
        public int Stock {  get; init; }
}*/
}
