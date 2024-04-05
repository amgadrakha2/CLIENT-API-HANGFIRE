using ClientApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientApp.Dto
{
    public class Result
    {
        public  string code { get; set; } =string.Empty;
        public  string description { get; set; } = string.Empty;
        public  string asset_class { get; set; } = string.Empty;
        public  string locale { get; set; } = string.Empty;
    }
}
