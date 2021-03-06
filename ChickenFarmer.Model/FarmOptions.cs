#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace ChickenFarmer.Model
{
    public static class FarmOptions
    {
        static FarmOptions()
        {
            DefaultPlayerLife = 10;
            DefaultPlayerMaxSpeed = 0.5f;
            DefaultMoney = 100;
            DefaultHenhouseCapacity = 4;
            DefaultStorageCapacity = 1;
            DefaultHenHouseLimit = 10;
            DefaultMaxUpgrade = 4;
            DefaultLayByMinute = 0;
            DefaultChickenCost = new[] { 10, 20, 30, 40 };

            DefaultHenhouseBuildTime = 20;

            DefaultFoodConsumption = 0.1f;
            DefaultStorageLevel = 0;
            DefaultStorageMaxLevel = 3;

            SeedPrice = 3;
            VegetablePrice = 5;
            MeatPrice = 10;
            EggValue = 2;

            DefaultBuildingPrices = new Dictionary<Type, int>
            {
                { typeof(Henhouse), 20 }, { typeof(SeedStorage), 10 }, { typeof(VegetableStorage), 20 },
                { typeof(MeatStorage), 30 }
            };

            DefaultUpgradePrices = new Dictionary<Type, int>
            {
                { typeof(Henhouse), 10 }, { typeof(SeedStorage), 10 }, { typeof(VegetableStorage), 20 },
                { typeof(MeatStorage), 30 }
            };

            DefaultEggCapacity = 0;
            DefaultEggMaxCapacity = 5000;

            DefaultSeedCapacity = 1000;
            DefaultSeedMaxCapacity = 10000;
            DefaultSeedRackPrice = 10;

            DefaultVegetableCapacity = 0;
            DefaultVegetableMaxCapacity = 10000;
            DefaultVegetableRackPrice = 15;

            DefaultMeatCapacity = 0;
            DefaultMeatMaxCapacity = 10000;
            DefaultMeatRackPrice = 20;
        }

        public static int DefaultVegetableStorageCost { get; set; }

        public static int DefaultMeatStorageCost { get; set; }

        public static int DefaultSeedStorageCost { get; set; }

        public static Dictionary<Type, int> DefaultBuildingPrices { get; }
        public static int DefaultSeedRackPrice { get; }

        public static int DefaultVegetableRackPrice { get; }

        public static int DefaultMeatRackPrice { get; }

        private static int DefaultStorageCapacity { get; }

        public static int DefaultMoney { get; }

        public static int DefaultHenHouseLimit { get; }

        private static int DefaultLayByMinute { get; }

        public static int[] DefaultChickenCost { get; }

        public static int SeedPrice { get; }
        public static int VegetablePrice { get; }
        public static int MeatPrice { get; }

        public static float DefaultFoodConsumption { get; }
        public static int DefaultStorageLevel { get; }
        public static int DefaultStorageMaxLevel { get; }

        public static int DefaultSeedCapacity { get; }
        public static int DefaultSeedMaxCapacity { get; }

        public static int DefaultVegetableCapacity { get; }
        public static int DefaultVegetableMaxCapacity { get; }

        public static int DefaultMeatCapacity { get; }
        public static int DefaultMeatMaxCapacity { get; }

        public static int DefaultEggCapacity { get; }
        public static int DefaultEggMaxCapacity { get; }

        public static int DefaultMaxUpgrade { get; }

        public static int DefaultHenhouseCapacity { get; }

        public static int DefaultHenhouseBuildTime { get; }
        public static int DefaultPlayerLife { get; }
        public static float DefaultPlayerMaxSpeed { get; }
        public static int EggValue { get; }
        public static Dictionary<Type, int> DefaultUpgradePrices { get; }
    }
}