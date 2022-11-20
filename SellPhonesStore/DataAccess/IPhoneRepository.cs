using SellPhonesStore.Entities;
using System.Collections.Generic;

namespace SellPhonesStore.DataAccess
{
    public interface IPhoneRepository
    {
        long SavePhone(Phone phone);
        long SaveCustomer(Customer customer);
        long SaveOrder(CustomerOrder order);
        long SaveOrderedPhone(OrdereredPhone orderPhone, long orderId);
        List<CustomerOrder> GetCustomerOrders(long customerId);
        List<CustomerOrder> GetAllCustomerOrders();
         
    }
}
