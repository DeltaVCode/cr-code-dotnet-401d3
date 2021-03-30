using System;
using PartyTime.Parties;

namespace PartyTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Party Time!");

            Party party = new PoolParty();
            party.Setup();
            Console.WriteLine($"Max Guests: {party.NumberOfGuests}");
            // party.PoolDepth // error because Party doesn't have this property
            party.Teardown();

            // Object initializer to set properties as part of construction
            PoolParty poolParty = new PoolParty
            {
                NumberOfGuests = 12,
                PoolDepth = 7
            };

            poolParty.Setup();
            WritePoolDetails(poolParty);
            poolParty.Teardown();


            BirthdayParty[] bdayParties = new BirthdayParty[]
            {
                new KidBirthdayParty("John") { NumberOfGuests = 10 },
                new BarBirthdayParty { NumberOfGuests = 15 },
                new KidPoolBirthdayParty("Paul", 10) { NumberOfGuests = 20, PoolDepth = 5, LifeJacketsProvided = true },
                new KidPoolBirthdayParty("George", 0) { NumberOfGuests = 2, PoolDepth = 1, LifeJacketsProvided = false },
            };

            for (int i = 0; i < bdayParties.Length; i++)
            {
                BirthdayParty bdayParty = bdayParties[i];

                bdayParty.Setup();
                Console.WriteLine($"Max Guests: {bdayParty.NumberOfGuests}");
                Console.WriteLine($"Gifts? {bdayParty.AcceptGifts}");

                if (bdayParty is IPoolParty bdayPoolParty)
                {
                    WritePoolDetails(bdayPoolParty);
                }

                bdayParty.Teardown();
            }
        }

        private static void WritePoolDetails(IPoolParty poolParty)
        {
            Console.WriteLine($"Pool Depth: {poolParty.PoolDepth}");
            Console.WriteLine($"Life jackets provided? {poolParty.LifeJacketsProvided}");
            Console.WriteLine($"Floaties provided? {poolParty.FloatiesProvided > 0}");
        }
    }
}
