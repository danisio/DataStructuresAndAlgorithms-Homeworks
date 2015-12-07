namespace Company
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(string title, string vendor, decimal price, decimal barcode)
        {
            this.Title = title;
            this.Vendor = vendor;
            this.Price = price;
            this.Barcode = barcode;
        }

        public string Title { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public decimal Barcode { get; set; }

        public int CompareTo(Article other)
        {
            return (int)(this.Price - other.Price);
        }
    }
}
