using System;

namespace Pr2
{
    class Product : IEquatable<Product>
    {
        private string _name;
        private double _price;
        private double _weight;
        private int _maxShelfLife;
        private DateTime? _dateOfManufacture;

        public string Name { get => _name; set => _name = value; }

        public double Price
        {
            set => _price = value;
            get => _price;
        }

        public double Weight
        {
            set => _weight = value;
            get => _weight;
        }

        public int MaxShelfLife { get => _maxShelfLife; set => _maxShelfLife = value; }

        public Product()
        {
            _name = "";
            _price = 0;
            _weight = 0;
            _dateOfManufacture = new DateTime(2020, 10, 4);
        }

        public Product(string name, double price = 0.0, double weight = 0.0, DateTime? dateOfManufacture = null)
        {
            _name = name;
            _price = price;
            _weight = weight;
            _dateOfManufacture = dateOfManufacture;
        }

        public virtual double ChangePrice(int procent)
        {
            double newPrice = _price * procent / 100.0;
            return newPrice;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _price, _weight, _maxShelfLife, _dateOfManufacture);
        }

        public void MyParse(string s)
        {
            var words = s.Split(" ");
            _name = words[0];
            _price = double.Parse(words[1]);
            _weight = double.Parse(words[2]);
            _maxShelfLife = int.Parse(words[3]);
            _dateOfManufacture = Convert.ToDateTime(String.Format("{0:XX.XX.XXXX}", words[4]));
        }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _name == other._name && _price.Equals(other._price) && _weight.Equals(other._weight) && _maxShelfLife == other._maxShelfLife && Nullable.Equals(_dateOfManufacture, other._dateOfManufacture);
        }

        public override string ToString()
        {
            return "Name: " + Name + ". Price: " + Price + ". Weight: " + Weight + ". ShelfLife: " + MaxShelfLife;
        }
    }
}
