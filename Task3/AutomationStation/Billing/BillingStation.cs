using System;
using System.Collections.Generic;
using System.Linq;
using AutomationStation.Models;

namespace AutomationStation.Billing
{
    public class BillingStation
    {
        private readonly List<BillingSubscriber> _billingSubscribers;

        public BillingStation(List<BillingSubscriber> billingSubscribers)
        {
            _billingSubscribers = billingSubscribers;
        }

        public void NewCallInfo(CallInfo callInfo)
        {
            var subscriber = FindSubscriber(callInfo.Source);
            subscriber.AddCallInfo(callInfo);
        }

        private BillingSubscriber FindSubscriber(PhoneNumber number)
        {
            return _billingSubscribers.FirstOrDefault(subscriber => subscriber.Number == number);
        }
    }
}