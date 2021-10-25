using System;

namespace Pr2
{
    class Product : IEquatable<Product>
    {
        public DateTime? _dateOfManufacture;

        public string Name { get; set; }

        public double Price { set; get; }

        public double Weight { set; get; }

        public int MaxShelfLife { get; set; }

        public Product()
        {
            Name = "";
            Price = 0;
            Weight = 0;
            _dateOfManufacture = new DateTime(2020, 10, 4);
        }

        public Product(string name, double price = 0.0, double weight = 0.0, int maxShelfLife = 0, DateTime? dateOfManufacture = null)
        {
            Name = name;
            Price = price;
            Weight = weight;
            MaxShelfLife = maxShelfLife;
            _dateOfManufacture = dateOfManufacture;
        }

        public virtual double ChangePrice(int procent)
        {
            double newPrice = Price * procent / 100.0;
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
            return HashCode.Combine(Name, Price, Weight, MaxShelfLife, _dateOfManufacture);
        }

        public void MyParse(string s)
        {
            var words = s.Split(" ");
            Name = words[0];
            Price = double.Parse(words[1]);
            Weight = double.Parse(words[2]);
            MaxShelfLife = int.Parse(words[3]);
            _dateOfManufacture = Convert.ToDateTime($"{words[4]:XX.XX.XXXX}");
        }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Price.Equals(other.Price) && Weight.Equals(other.Weight) && MaxShelfLife == other.MaxShelfLife && Nullable.Equals(_dateOfManufacture, other._dateOfManufacture);
        }

        public override string ToString()
        {
            return "Name: " + Name + ". Price: " + Price + ". Weight: " + Weight + ". ShelfLife: " + MaxShelfLife;
        }
    }
}
