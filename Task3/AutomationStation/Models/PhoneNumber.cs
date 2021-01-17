using System;

namespace AutomationStation.Models
{
    [Serializable]
    public class PhoneNumber
    {
        private readonly string _phoneNumber;
        public string Number => _phoneNumber;

        public PhoneNumber(string number)
        {
            _phoneNumber = number;
        }
        private PhoneNumber()
        {}

        public override string ToString()
        {
            return _phoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == typeof(PhoneNumber))
            {
                return _phoneNumber == ((PhoneNumber) obj)._phoneNumber;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _phoneNumber.GetHashCode();
        }

        public static bool operator ==(PhoneNumber p1, PhoneNumber p2)
        {
            return p1 != null && p2!=null && p1.Equals(p2);
        }

        public static bool operator !=(PhoneNumber p1, PhoneNumber p2)
        {
            return !(p1 == p2);
        }
    }
}