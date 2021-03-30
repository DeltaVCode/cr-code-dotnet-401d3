using System;

namespace PartyTime.Parties
{
    public class PoolParty : Party
    {
        public decimal PoolDepth { get; set; }

        public override void Setup()
        {
            Console.WriteLine("Clean the pool.");
            Console.WriteLine("Set out some towels.");
        }

        public override void Teardown()
        {
            Console.WriteLine("Put away pool toys.");

            // Don't forget to thank the neighbors
            base.Teardown();
        }

        // public abstract void Whatever(); // Cannot have abstract if type is not abstract
    }
}
