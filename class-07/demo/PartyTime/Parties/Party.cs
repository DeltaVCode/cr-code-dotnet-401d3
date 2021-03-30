using System;

namespace PartyTime.Parties
{
    public abstract class Party
    {
        public int NumberOfGuests { get; set; }

        public abstract void Setup();

        public virtual void Teardown()
        {
            Console.WriteLine("Thank neighbors for their tolerance.");
        }

        // force all Parties to implement ToString()
        // public abstract override string ToString();
    }

    public abstract class BirthdayParty : Party
    {
        public abstract bool AcceptGifts { get; }

        public virtual int ClownCount => 0;

        public override void Setup()
        {
            Console.WriteLine("Invite guests.");
        }
    }

    public class KidBirthdayParty : BirthdayParty
    {
        public KidBirthdayParty(string name)
        {
            NameOfChild = name;
        }

        public override bool AcceptGifts { get { return true; } }

        public string NameOfChild { get; }

        public override void Setup()
        {
            Console.WriteLine($"Ask {NameOfChild} whom they want to invite.");
            base.Setup();
        }
    }

    public class KidPoolBirthdayParty : KidBirthdayParty, IPoolParty
    {
        public KidPoolBirthdayParty(string name, int floatieCount) : base(name)
        {
            FloatiesProvided = floatieCount;
        }

        public decimal PoolDepth { get; set; }

        public int FloatiesProvided { get; private set; }
        public bool LifeJacketsProvided { get; set; }

        public override void Setup()
        {
            base.Setup();
            Console.WriteLine("Clean the pool.");
        }

        public override void Teardown()
        {
            Console.WriteLine("Drain pool; some kid probably peed.");
            base.Teardown();
        }
    }

    public class BarBirthdayParty : BirthdayParty
    {
        public override bool AcceptGifts => false;

        public override void Setup()
        {
            base.Setup();
            Console.WriteLine("Ask someone to be DD");
        }
    }
}
