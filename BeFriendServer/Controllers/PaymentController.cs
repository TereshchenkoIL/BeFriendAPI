using AutoMapper;
using BeFriendServer.Data;
using BeFriendServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public PaymentController(IRepositoryManager manager, IMapper mapper,  IWebHostEnvironment appEnvironment)
        {
            _repository = manager;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }



        // GET api/payment/checkPremium/{num}
        [HttpGet("checkPremium/{num}")]
        public IActionResult CheckPremium(string num)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            Payment payment = _repository.Payments.GetAll().Where(x => x.TelephoneNumber == num).OrderByDescending(x => x.EndDate).FirstOrDefault();
            if(payment == null)
            {
                return Ok(false);
            }
            return Ok(true);
            
        }

        // GET api/payment/getPremium/{num}
        [HttpGet("getPremium/{num}")]
        public IActionResult GetPremium(string num)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            Payment payment = _repository.Payments.GetAll().Where(x => x.TelephoneNumber == num).OrderByDescending(x => x.EndDate).FirstOrDefault();
           
            return Ok(payment);

        }

        // POST api/payment/create
        [HttpPost("api/payment/create")]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            User user = _repository.Users.GetByNumber(payment.TelephoneNumber);
            if (user == null) return NotFound();

            _repository.Payments.CreatePayment(payment);
            _repository.Save();
            return Ok(NoContent());
        }

        // DELETE api/payment/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            Payment payment = _repository.Payments.GetById(id, true);
            if (payment == null) return NotFound();

            _repository.Payments.DeletePayment(payment);
            _repository.Save();
            return Ok(NoContent());
        }

    }
}
