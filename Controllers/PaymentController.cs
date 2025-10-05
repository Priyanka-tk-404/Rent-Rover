using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carrental1.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/
        public ActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public ActionResult ProcessPayment(string paymentMode)
        {
            // Process payment logic
            // Depending on your payment gateway, you need to initiate payment
            string transactionId = "TXN123456"; // You will get this from the payment gateway
            string paymentStatus = "Pending"; // Update based on response from gateway
            
            // Save the transaction details in your database here
            
            return RedirectToAction("PaymentStatus", new { transactionId = transactionId });
        }

        // This action will show payment status
        public ActionResult PaymentStatus(string transactionId)
        {
            // Retrieve payment status based on transaction ID
            // Show payment details and status
            var paymentDetails = new
            {
                TransactionId = transactionId,
                Status = "Success", // This should come from your database
                PaymentMethod = "UPI" // Or "RuPay", etc.
            };

            return View(paymentDetails);
        }
    }
}