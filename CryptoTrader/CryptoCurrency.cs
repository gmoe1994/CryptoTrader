using System.ComponentModel.DataAnnotations;

namespace CryptoTrader
{
    public class CryptoCurrency
    {
        [Required]
        [MinLength(3)]
        [MaxLength(6)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Logo { get; set; }

    }
}
