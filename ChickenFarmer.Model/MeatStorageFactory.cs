﻿namespace ChickenFarmer.Model
{
    internal class MeatStorageFactory : IStorageFactory
    {
        public IBuilding Create(BuildingCollection ctx, Vector posVector)
        {
            NbrBuilt ++;
            return new MeatStorage(ctx, this, posVector);
        }

        public void OnRemove(IBuilding building) { NbrBuilt --; }
        public int NbrBuilt { get; set; }
        public bool IsEnabled => !NbrBuilt.Equals(1);
        public int DefaultCapacity => FarmOptions.DefaultMeatCapacity;
    }
}