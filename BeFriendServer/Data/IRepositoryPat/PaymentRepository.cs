using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class PaymentRepository :RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(befrienddbContext context)
            :base(context)
        {

        }

        public void CreatePayment(Payment payment)
        {
            Create(payment);
        }

        public void DeletePayment(Payment payment)
        {
            Delete(payment);
        }

        public List<Payment> GetAll(bool tracked = false)
        {
            return FindAll(tracked).ToList();
        }

        public Payment GetById(int id, bool tracked = false)
        {
            return FindByCondition(x => x.PaymentId == id, tracked).FirstOrDefault();
        }

        public void UpdatePayment(Payment payment)
        {
            Update(payment);
        }
    }
}
