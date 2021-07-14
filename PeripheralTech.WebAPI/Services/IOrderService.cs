using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public interface IOrderService
    {
        List<Model.Order> Get(OrderSearchRequest request);
        Model.Order GetUnderReviewOrder(OrderSearchRequest request);
        Model.Order GetApprovedOrder(OrderSearchRequest request);
        Model.Order GetById(int id);
        Model.Order Insert(OrderInsertRequest request);
        Model.Order Update(int id, OrderUpdateRequest request);
    }
}
