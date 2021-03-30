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

            if (this is IPoolParty poolParty)
            {
                poolParty.TurnOnHeater();
            }
        }
    }

    public class KidBirthdayParty : BirthdayParty, IHasCookout
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

        public virtual string[] Foods => new[] { "Burgers", "Hot Dogs" };

        public void AnnounceFoodIsReady()
        {
            Console.WriteLine("Come and get it!");
        }
    }

    public interface IHasCookout
    {
        string[] Foods { get; }

        void AnnounceFoodIsReady();
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

        public override string[] Foods => new[] { "Veggie Burgers" };

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

        public void TurnOnHeater()
        {
            Console.WriteLine("Come on baby light my fire");
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
