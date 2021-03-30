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

            PoolParty poolParty = new PoolParty();
            poolParty.Setup();
            poolParty.PoolDepth = 7;
            Console.WriteLine($"Pool Depth: {poolParty.PoolDepth}");
            poolParty.Teardown();


            BirthdayParty[] bdayParties = new BirthdayParty[]
            {
                new KidBirthdayParty("John") { NumberOfGuests = 10 },
                new BarBirthdayParty { NumberOfGuests = 15 },
                new KidBirthdayParty("Paul") { NumberOfGuests = 20 },
            };

            for (int i = 0; i < bdayParties.Length; i++)
            {
                BirthdayParty bdayParty = bdayParties[i];

                bdayParty.Setup();
                Console.WriteLine($"Max Guests: {bdayParty.NumberOfGuests}");
                Console.WriteLine($"Gifts? {bdayParty.AcceptGifts}");

                bdayParty.Teardown();
            }
        }
    }
}
