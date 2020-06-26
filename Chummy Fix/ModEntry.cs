using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.GameData.FishPond;

namespace ChummyFix
{
    class ModEntry : Mod
    {
        private ModConfig Config;
        private FishPondReward reward;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<ModConfig>();

            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
            helper.Events.GameLoop.Saving     += OnSaving;
        }

        private void OnSaving(object sender, SavingEventArgs e)
        {
            FixOdds();
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            FixOdds();
        }

        private void FixOdds()
        {
            foreach(var building in Game1.getFarm().buildings)
            {
                //are we dealing with ponds?
                if(building is FishPond pond)
                {
                    int currentPopulation = pond.FishCount;

                    //incase pond is empty on load
                    if(currentPopulation == 0)
                    {
                        break;
                    }

                    //what items can be produced in the pond
                    foreach(var item in pond.GetFishPondData().ProducedItems)
                    {
                        PrintToLog($"Fish: {pond.fishType}, reward ID: {item.ItemID}, chance: {item.Chance}, reqPop: {item.RequiredPopulation}, min: {item.MinQuantity}");

                        if(currentPopulation >= item.RequiredPopulation)
                        {
                            //time to fix the odds
                            switch(item.ItemID)
                            {
                                case 812:
                                    if (item.Chance != (Config.Roe / 100))
                                    {
                                        PrintToLog($"Setting Roe's odds to {Config.Roe}%");
                                        item.Chance = Config.Roe / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void PrintToLog(string message)
        {
            this.Monitor.Log(message, LogLevel.Debug);
        }
    }
}
