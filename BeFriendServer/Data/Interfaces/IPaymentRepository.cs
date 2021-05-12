using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IPaymentRepository
    {
        Payment GetById(int id, bool tracked = false);
        List<Payment> GetAll(bool tracked = false);
        void CreatePayment(Payment payment);
        void DeletePayment(Payment payment);
        void UpdatePayment(Payment payment);
    }
}
