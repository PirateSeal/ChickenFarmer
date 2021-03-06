﻿#region Usings

#region Usings

using System;

#endregion

// ReSharper disable InvertIf

#endregion

namespace ChickenFarmer.Model
{
    public abstract class Market
    {
        protected Market(Farm ctx) { CtxFarm = ctx; }

        public static Farm CtxFarm { get; set; }

        public static void UpgradeBuilding<TBuildingType>(TBuildingType building) where TBuildingType : IBuilding
        {
            FarmOptions.DefaultUpgradePrices.TryGetValue(typeof(TBuildingType), out int cost);
            int lvl = building.Lvl;
            if ( CtxFarm.Money <= cost * lvl || building.Lvl >= FarmOptions.DefaultMaxUpgrade ) return;
            building.Upgrade();
            CtxFarm.Money -= cost * (lvl + 1);
        }

        public static void UpgradeHenhouseRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            IRack upgradedRack = henhouse?.Racks.Find(rack => rack is TRackType) ??
                                 throw new ArgumentNullException("Rack is null", nameof(upgradedRack));
            if ( CtxFarm.Money >= upgradedRack.UpgrageCost )
            {
                CtxFarm.Money -= upgradedRack.UpgrageCost;
                henhouse.UpgradeRack<TRackType>();
            }
        }

        public static void BuyFood<TStorageType>(int amount) where TStorageType : IStorage
        {
            IStorage storage = CtxFarm.Buildings.FindStorage<TStorageType>();

            if ( CtxFarm.Money > storage.Value * amount )
            {
                CtxFarm.Money -= storage.Value * amount;
                storage.Capacity += amount;
            }
            else
            {
                throw new ArgumentException("Invalid type of food given", nameof(TStorageType));
            }
        }

        public static void BuyChicken(int amount, Chicken.Breed breed)
        {
            int toPut = amount;
            foreach ( IBuilding building in CtxFarm.Buildings.BuildingList )
                if ( building is Henhouse henhouse )
                    if ( CtxFarm.Money > FarmOptions.DefaultChickenCost[( int ) breed - 1] )
                        do
                        {
                            if ( toPut <= 0 ) return;
                            henhouse.AddChicken(breed);
                            CtxFarm.Money -= FarmOptions.DefaultChickenCost[( int ) breed - 1];
                            toPut --;
                        } while (!henhouse.IsFull);
        }

        public static void Sellegg()
        {
            CtxFarm.Money += 2 * CtxFarm.Buildings.FindStorage<EggStorage>().
                                 Capacity;
            CtxFarm.Buildings.FindStorage<EggStorage>().
                Capacity = 0;
        }

        public static void BuyRack<TRackType>(Henhouse henhouse) where TRackType : IRack
        {
            if ( typeof(VegetableRack).IsAssignableFrom(typeof(TRackType)) &&
                 CtxFarm.Money > FarmOptions.DefaultVegetableRackPrice )
                henhouse.Racks.Add(new VegetableRack(henhouse));
            else if ( typeof(MeatRack).IsAssignableFrom(typeof(TRackType)) &&
                      CtxFarm.Money > FarmOptions.DefaultMeatRackPrice )
                henhouse.Racks.Add(new MeatRack(henhouse));
        }

        public static void BuyBuilding<TBuildingType>(float xCoord, float yCoord) where TBuildingType : IBuilding
        {
            FarmOptions.DefaultBuildingPrices.TryGetValue(typeof(TBuildingType), out int cost);
            CtxFarm.Buildings.BuildingFactories.TryGetValue(typeof(TBuildingType), out IBuildingFactory factory);
            if ( factory != null && CtxFarm.Money > cost && factory.IsEnabled )
            {
                CtxFarm.Money -= cost;
                CtxFarm.Buildings.Build<TBuildingType>(xCoord, yCoord);
            }
        }
    }
}