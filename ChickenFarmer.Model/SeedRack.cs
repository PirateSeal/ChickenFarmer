﻿namespace ChickenFarmer.Model
{
    public class SeedRack : IRack
    {
        public SeedRack(Henhouse ctx)
        {
            CtxHenhouse = ctx;
            Capacity = 0;
            Lvl = 1;
        }

        public Henhouse CtxHenhouse { get; set; }
        public int Capacity { get; set; }

        public int MaxCapacity
        {
            get => 500;
            set { }
        }

        public int Lvl { get; set; }
        public int UpgrageCost => FarmOptions.DefaultSeedRackPrice * Lvl;

        public int Fill(int amount)
        {
            int remain = 0;
            if ( Capacity + amount <= MaxCapacity && amount <= CtxHenhouse.CtxCollection.FindStorage<SeedStorage>().
                     Capacity )
            {
                CtxHenhouse.CtxCollection.FindStorage<SeedStorage>().
                    Capacity -= amount;
                Capacity += amount;
            }
            else if ( Capacity + amount > MaxCapacity )
            {
                CtxHenhouse.CtxCollection.FindStorage<SeedStorage>().
                    Capacity -= amount;
                Capacity = MaxCapacity;
                remain = Capacity + amount - MaxCapacity;
            }

            return remain;
        }

        public void Upgrade() { Lvl ++; }
    }
}