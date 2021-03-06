﻿namespace AuctionSystem.WcfService.Contracts
{
    using Models;
    using Models.DTOs;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IPaymentService
    {
        [OperationContract(IsOneWay = true)]
        void AddPayment(Payment payment, int userId);

        [OperationContract]
        PaymentDto GetPayment(int paymentId);

        [OperationContract]
        bool DeletePayment(int paymentId);

        [OperationContract]
        bool UpdatePayment(PaymentDto payment);

        //[OperationContract]
        //IList<Payment> GetPaymentsByUser(User user);
    }
}