using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
    public class Customer
    {
        public Models.Customer GetByName(string name)
        {
            return new Models.Customer(){ Name="Contoso", City="Redmond", State="WA", Phone="425-867-5309"};
        }
    }
}
