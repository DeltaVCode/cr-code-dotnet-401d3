using System;

namespace PartyTime.Parties
{
    public class PoolParty : Party, IPoolParty
    {
        public decimal PoolDepth { get; set; }

        public int FloatiesProvided => 0;
        public bool LifeJacketsProvided => true;

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

        public void TurnOnHeater()
        {
            Console.WriteLine("The heat is on...");
        }

        // public abstract void Whatever(); // Cannot have abstract if type is not abstract
    }

    public interface IPoolParty
    {
        decimal PoolDepth { get; }

        void TurnOnHeater();

        int FloatiesProvided { get; }

        bool LifeJacketsProvided { get; }
    }
}
