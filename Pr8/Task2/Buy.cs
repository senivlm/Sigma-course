namespace Pr2
{
    class Buy
    {
        private int _numberOfProducts;
        private Product[] _products;
        private double _cost;
        private double _weight;

        public Product[] Product => _products;
        public int NumberOfProducts => _numberOfProducts;
        public double Cost
        {
            set
            {
                _cost = value;
            }
            get
            {
                return _cost;
            } 
        }

        public double Weight
        {
            set
            {
                _weight = value;
            }
            get
            {
                return _weight;
            }
        }

        public Buy()
        {
            _products = new Product[NumberOfProducts];
        }

        public Buy(Product[] product, int numberOfProducts, double cost, double weight)
        {
            _products = product;
            _numberOfProducts = numberOfProducts;
            _cost = cost * numberOfProducts;
            _weight = weight * numberOfProducts;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
