﻿namespace AuctionSystem.Controllers
{
    using AutoMapper;
    using Controllers.Contracts;
    using Data;
    using Models;
    using Models.DTOs;
    using System;
    using System.Linq;

    public class LoginController : ILoginController
    {
        private static LoginController instance;

        private LoginController()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>()
                                        //.ForMember(dest => dest.ZipCountryCity, opt => opt.MapFrom(src => src.Zip.Country + ", " + src.Zip.City))
                                        .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => string.Join(Environment.NewLine, src.Payments.Select(p => p.Type + ", " + p.PaymentTypeCode))))
                                        .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => string.Join(Environment.NewLine, src.Invoices.Select(p => p.ProductId + ", " + p.Product.Name))))
                                        .ForMember(dest => dest.Bids, opt => opt.MapFrom(src => string.Join(Environment.NewLine, src.Bids.Select(b => b.Product.Name + ", " + b.Coins + ", " + b.IsWon + ", " + b.DateOfCreated))));
                cfg.CreateMap<Bid, BidDto>()
                                        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                                        .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
                cfg.CreateMap<Product, ProductDto>()
                                        .ForMember(dest => dest.Bids, opt => opt.MapFrom(src => string.Join(Environment.NewLine, src.Bids.Select(b => b.User.Name + " " + b.Coins + " " + b.DateOfCreated))));
                cfg.CreateMap<Invoice, InvoiceDto>()
                                        .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Name))
                                        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.Name))
                                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                                        .ForMember(dest => dest.DateOfIssued, opt => opt.MapFrom(src => src.Product.EndDate));
                cfg.CreateMap<Payment, PaymentDto>()
                                        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
            });
        }

        public static LoginController Instance()
        {
            if (instance == null)
            {
                instance = new LoginController();
            }

            return instance;
        }

        public bool ValidateLogin(string username, string password)
        {
            using (var db = new AuctionContext())
            {
                // var t = from p in db.Users where p.Username == username select p;
                var enteredUsername = db.Users
                                            .Where(u => u.Username == username)
                                            .Select(u => u.Username);
                var enteredPassword = db.Users
                                            .Where(p => p.Password == password)
                                            .Select(p => p.Password);

                if (enteredUsername.Any() && enteredPassword.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
        }
    }
}