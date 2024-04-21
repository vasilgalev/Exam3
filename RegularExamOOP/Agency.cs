using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml;

namespace RegularExamOOP
{
    public class Agency
    {
        private List<RealEstate> realEstates;

        public Agency(string name)
        {
            this.Name = name;
            this.realEstates = new List<RealEstate>();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException("Invalid agency name!");
                }
                name = value;
            }
        }
        public void AddRealEstate(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

        public bool SellRealEstate(RealEstate realEstate)
        {
            RealEstate realEstate1 = realEstates.FirstOrDefault(x => x.Address == realEstate.Address && x.Price == realEstate.Price);
            if (realEstate1 != null)
            {
                return realEstates.Remove(realEstate1);
            }
            return false;
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = realEstates.Sum(x => x.Price);
            return totalPrice;
        }

        public RealEstate GetRealEstateWithHighestPrice()
        {
            RealEstate propertyHighestPrice = realEstates.OrderByDescending(x => x.Price).FirstOrDefault();
            return propertyHighestPrice;
        }

        public RealEstate GetRealEstateWithLowestPrice()
        {
            RealEstate propertyLowestPrice = realEstates.OrderBy(x => x.Price).FirstOrDefault();
            return propertyLowestPrice;
        }

        public void RenameAgency(string newName)
        {
            this.Name = newName;
        }

        public void SellAllRealEstates()
        {
            realEstates.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (realEstates.Count > 0)
            {
                sb.AppendLine($"Agency {Name} has {realEstates.Count} real estate/s:");
                foreach (var property in realEstates)
                {
                    sb.AppendLine($"Real Estate on {property.Address} street costs {property.Price:f2}");
                }
                return sb.ToString();
            }
            return $"Agency {Name} has no available real estates.";
        }
    }
}


