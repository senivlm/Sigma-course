using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Pr7
{

    public class Component
    {
        public string Name { get; set; }

        public double? Weight { get; set; }
    }

    public class Menu : IEquatable<Menu>
    {
        public List<string> _names;

        public List<Component> _components;

        public Menu(string name = "", string filePath = "D:\\Courses\\Sigma\\Pr7\\Pr7\\Menu.txt")
        {
            _names = new List<string>();
            _components = new List<Component>();
            ReadFromFile(filePath);
        }

        public void ReadFromFile(string filePath)
        {
            var readText = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    readText.Add(reader.ReadLine());
                }
            }

            foreach (var textLine in readText)
            {
                var values = textLine.Split(" ");
                if (values.Length == 1)
                {
                    _names.Add(values[0]);
                }
                else
                {
                    var component = new Component()
                    {
                        Name = values[0],
                        Weight = Convert.ToDouble(values[1].Replace('.', ','))
                    };
                    _components.Add(component);
                }
            }
        }

        public override string ToString()
        {
            var str = "";
            for (var i = 0; i < _names.Capacity - 1; i++)
            {
                str += "Name: " + _names[i] + "\n";

                for (var j = 0; j < _components.Capacity - 1; j++)
                {
                    str += "Component's name: " + _components[j].Name + ". It's weight: " + _components[j].Weight +
                           "\n";
                }

            }
            return str;
        }

        public bool Equals(Menu other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_components, other._components) && Equals(_names, other._names);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Menu)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_components, _names);
        }
    }
}
