using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        //Am pus in modelul Order o referinta catre un obiect de tip Restaurant pentru a putea avea acces la numele
        //restaurantului unde s-a facut order-ul atunci cand o sa gett-ui in UI past orders of an exact client 
        public Restaurant Restaurant { get; } //acces la numele restaurantului
        public Client Client { get; } //acces la Cart-ul clientului si automat la items-ii din el, precum si la pretul total
        public Order(Client client, Restaurant restaurant)
        {
            Restaurant = restaurant;
            Client = client;
        }
    }
}
