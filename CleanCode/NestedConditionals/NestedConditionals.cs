﻿using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }

        public bool IsGoldCustomer()
        {
            return LoyaltyPoints > 100;
        }
    }

    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            // If reservation already started throw exception
            if (IsCancellationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");

            IsCanceled = true;
        }

        private bool IsCancellationPeriodOver()
        {
            var maxHours = Customer.IsGoldCustomer() ? 24 : 48;
            return LessThan(maxHours);
        }

        private bool LessThan(int maxHours)
        {
            return (From - DateTime.Now).TotalHours < maxHours;
        }
    }
}
