using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.Views.Shop
{
    internal class DetailVM
    {
        public List<Product> RelatedProducts { get; internal set; }
        public Product Product { get; internal set; }
    }
}