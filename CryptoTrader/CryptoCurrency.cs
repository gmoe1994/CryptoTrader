using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
