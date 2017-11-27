﻿namespace AuctionSystem.WcfService
{
    using AutoMapper;
    using Contracts;
    using Controllers;
    using Models;
    using Models.DTOs;
    using System.Collections.Generic;

    public class PaymentService : IPaymentService
    {
        public void AddPayment(Payment payment, int userId)
        {
            PaymentController.Instance().AddPayment(payment, userId);
        }

        public PaymentDto GetPayment(int paymentId)
        {
            var payment = PaymentController.Instance().GetPayment(paymentId);

            return MapDbPaymentToPaymentDto(payment);
        }

        public PaymentDto MapDbPaymentToPaymentDto(Payment payment)
        {
            return Mapper.Map<PaymentDto>(payment);
        }

        public bool DeletePayment(Payment payment)
        {
            return PaymentController.Instance().DeletePayment(payment);
        }

        public bool UpdatePayment(Payment payment)
        {
            return PaymentController.Instance().UpdatePayment(payment);
        }

        public IList<Payment> GetPaymentsByUser(User user)
        {
            return PaymentController.Instance().GetPaymentsByUser(user);
        }
    }
}
