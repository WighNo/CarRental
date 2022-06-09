using System;
using CarRental.Model;

namespace CarRental
{
    public static class Session
    {
        public static IUser User { get; private set; }
        public static Type Type { get; private set; }

        public static void Register(IUser user)
        {
            User = user;
            Type = User.GetType();
        }
    }
}