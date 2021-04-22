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
    }
}
