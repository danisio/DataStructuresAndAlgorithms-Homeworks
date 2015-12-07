namespace KnapsackProblem
{
    public class Product
    {
        public Product(string name, int weigth, int cost)
        {
            this.Name = name;
            this.Weight = weigth;
            this.Cost = cost;
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Cost { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0,7} | Weight: {1,2} | Cost: {2,2}", this.Name, this.Weight, this.Cost);
        }
    }
}
