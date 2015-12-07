namespace Company
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Company
    {
        private OrderedMultiDictionary<decimal, Article> articles =
          new OrderedMultiDictionary<decimal, Article>(true);

        public OrderedMultiDictionary<decimal, Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }

        public void AddProduct(Article article)
        {
            this.articles[article.Price].Add(article);
        }

        public ICollection<Article> SearchInPriceRange(decimal from, decimal to)
        {
            return this.articles.Range(from, true, to, true).Values;
        }
    }
}
