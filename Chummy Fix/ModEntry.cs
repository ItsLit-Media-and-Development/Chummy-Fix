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
                                case 66:
                                    if (item.Chance != (Config.Amethyst / 100))
                                    {
                                        PrintToLog($"Setting Amethyst's odds to {Config.Amethyst}%");

                                        item.Chance = (float)Config.Amethyst / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 72:
                                    if (item.Chance != (Config.Diamond / 100))
                                    {
                                        PrintToLog($"Setting Diamon's odds to {Config.Diamond}%");

                                        item.Chance = (float)Config.Diamond / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 80:
                                    if (item.Chance != (Config.Quartz / 100))
                                    {
                                        PrintToLog($"Setting Quartz's odds to {Config.Quartz}%");

                                        item.Chance = (float)Config.Quartz / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 84:
                                    if (item.Chance != (Config.Frozen_Tear / 100))
                                    {
                                        PrintToLog($"Setting Frozen Tear's odds to {Config.Frozen_Tear}%");

                                        item.Chance = (float)Config.Frozen_Tear / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 152:
                                    if (item.Chance != (Config.Seaweed / 100))
                                    {
                                        PrintToLog($"Setting Seaweed's odds to {Config.Seaweed}%");

                                        item.Chance = (float)Config.Seaweed / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 153:
                                    if (item.Chance != (Config.Green_Algae / 100))
                                    {
                                        PrintToLog($"Setting Green_Algae's odds to {Config.Green_Algae}%");

                                        item.Chance = (float)Config.Green_Algae / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 157:
                                    if (item.Chance != (Config.White_Algae / 100))
                                    {
                                        PrintToLog($"Setting White_Algae's odds to {Config.White_Algae}%");

                                        item.Chance = (float)Config.White_Algae / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 166:
                                    if (item.Chance != (Config.Treasure_Chest / 100))
                                    {
                                        PrintToLog($"Setting Treasure_Chest's odds to {Config.Treasure_Chest}%");

                                        item.Chance = (float)Config.Treasure_Chest / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 168:
                                    if (item.Chance != (Config.Trash / 100))
                                    {
                                        PrintToLog($"Setting Trash's odds to {Config.Trash}%");

                                        item.Chance = (float)Config.Trash / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 169:
                                    if (item.Chance != (Config.Driftwood / 100))
                                    {
                                        PrintToLog($"Setting Driftwood's odds to {Config.Driftwood}%");

                                        item.Chance = (float)Config.Driftwood / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 170:
                                    if (item.Chance != (Config.Broken_Glasses / 100))
                                    {
                                        PrintToLog($"Setting Broken_Glasses's odds to {Config.Broken_Glasses}%");

                                        item.Chance = (float)Config.Broken_Glasses / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 171:
                                    if (item.Chance != (Config.Broken_CD / 100))
                                    {
                                        PrintToLog($"Setting Broken_CD's odds to {Config.Broken_CD}%");

                                        item.Chance = (float)Config.Broken_CD / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 172:
                                    if (item.Chance != (Config.Soggy_Newspaper / 100))
                                    {
                                        PrintToLog($"Setting Soggy_Newspaper's odds to {Config.Soggy_Newspaper}%");

                                        item.Chance = (float)Config.Soggy_Newspaper / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 226:
                                    if (item.Chance != (Config.Spicy_Eeel / 100))
                                    {
                                        PrintToLog($"Setting Spicy_Eeel's odds to {Config.Spicy_Eeel}%");

                                        item.Chance = (float)Config.Spicy_Eeel / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 305:
                                    if (item.Chance != (Config.Void_Egg / 100))
                                    {
                                        PrintToLog($"Setting Void_Egg's odds to {Config.Void_Egg}%");

                                        item.Chance = (float)Config.Void_Egg / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 309:
                                    if (item.Chance != (Config.Acorn / 100))
                                    {
                                        PrintToLog($"Setting Acorn's odds to {Config.Acorn}%");

                                        item.Chance = (float)Config.Acorn / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 310:
                                    if (item.Chance != (Config.Maple_Seed / 100))
                                    {
                                        PrintToLog($"Setting Maple_Seed's odds to {Config.Maple_Seed}%");

                                        item.Chance = (float)Config.Maple_Seed / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 311:
                                    if (item.Chance != (Config.Pine_Cone / 100))
                                    {
                                        PrintToLog($"Setting Pine_Cone's odds to {Config.Pine_Cone}%");

                                        item.Chance = (float)Config.Pine_Cone / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 338:
                                    if (item.Chance != (Config.Refined_Quartz / 100))
                                    {
                                        PrintToLog($"Setting Refined_Quartz's odds to {Config.Refined_Quartz}%");

                                        item.Chance = (float)Config.Refined_Quartz / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 378:
                                    if (item.Chance != (Config.Copper_Ore / 100))
                                    {
                                        PrintToLog($"Setting Copper_Ore's odds to {Config.Copper_Ore}%");

                                        item.Chance = (float)Config.Copper_Ore / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 380:
                                    if (item.Chance != (Config.Iron_Ore / 100))
                                    {
                                        PrintToLog($"Setting Iron_Ore's odds to {Config.Iron_Ore}%");

                                        item.Chance = (float)Config.Iron_Ore / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 384:
                                    if (item.Chance != (Config.Gold_Ore / 100))
                                    {
                                        PrintToLog($"Setting Gold_Ore's odds to {Config.Gold_Ore}%");

                                        item.Chance = (float)Config.Gold_Ore / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 386:
                                    if (item.Chance != (Config.Iridium_Ore / 100))
                                    {
                                        PrintToLog($"Setting Iridium_Ore's odds to {Config.Iridium_Ore}%");

                                        item.Chance = (float)Config.Iridium_Ore / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 388:
                                    if (item.Chance != (Config.Wood / 100))
                                    {
                                        PrintToLog($"Setting Wood's odds to {Config.Wood}%");

                                        item.Chance = (float)Config.Wood / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 390:
                                    if (item.Chance != (Config.Stone / 100))
                                    {
                                        PrintToLog($"Setting Stone's odds to {Config.Stone}%");

                                        item.Chance = (float)Config.Stone / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 392:
                                    if (item.Chance != (Config.Nautilus_Shell / 100))
                                    {
                                        PrintToLog($"Setting Nautilus_Shell's odds to {Config.Nautilus_Shell}%");

                                        item.Chance = (float)Config.Nautilus_Shell / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 394:
                                    if (item.Chance != (Config.Rainbow_Shell / 100))
                                    {
                                        PrintToLog($"Setting Rainbow_Shell's odds to {Config.Rainbow_Shell}%");

                                        item.Chance = (float)Config.Rainbow_Shell / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 397:
                                    if (item.Chance != (Config.Sea_Urchin / 100))
                                    {
                                        PrintToLog($"Setting Sea_Urchin's odds to {Config.Sea_Urchin}%");

                                        item.Chance = (float)Config.Sea_Urchin / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 457:
                                    if (item.Chance != (Config.Pale_Broth / 100))
                                    {
                                        PrintToLog($"Setting Pale_Broth's odds to {Config.Pale_Broth}%");

                                        item.Chance = (float)Config.Pale_Broth / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 535:
                                    if (item.Chance != (Config.Geode / 100))
                                    {
                                        PrintToLog($"Setting Geode's odds to {Config.Geode}%");

                                        item.Chance = (float)Config.Geode / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 536:
                                    if (item.Chance != (Config.Frozen_Geode / 100))
                                    {
                                        PrintToLog($"Setting Frozen_Geode's odds to {Config.Frozen_Geode}%");

                                        item.Chance = (float)Config.Frozen_Geode / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 537:
                                    if (item.Chance != (Config.Magma_Geode / 100))
                                    {
                                        PrintToLog($"Setting Magma_Geode's odds to {Config.Magma_Geode}%");

                                        item.Chance = (float)Config.Magma_Geode / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 543:
                                    if (item.Chance != (Config.Dolomite / 100))
                                    {
                                        PrintToLog($"Setting Dolomite's odds to {Config.Dolomite}%");

                                        item.Chance = (float)Config.Dolomite / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 571:
                                    if (item.Chance != (Config.Limestone / 100))
                                    {
                                        PrintToLog($"Setting Limestone's odds to {Config.Limestone}%");

                                        item.Chance = (float)Config.Limestone / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 680:
                                    if (item.Chance != (Config.Rain_Totem / 100))
                                    {
                                        PrintToLog($"Setting Rain_Totem's odds to {Config.Rain_Totem}%");

                                        item.Chance = (float)Config.Rain_Totem / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 684:
                                    if (item.Chance != (Config.Bug_Meat / 100))
                                    {
                                        PrintToLog($"Setting Bug_Meat's odds to {Config.Bug_Meat}%");

                                        item.Chance = (float)Config.Bug_Meat / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 688:
                                    if (item.Chance != (Config.Farm_Totem / 100))
                                    {
                                        PrintToLog($"Setting Farm_Totem's odds to {Config.Farm_Totem}%");

                                        item.Chance = (float)Config.Farm_Totem / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 689:
                                    if (item.Chance != (Config.Mountains_Totem / 100))
                                    {
                                        PrintToLog($"Setting Mountains_Totem's odds to {Config.Mountains_Totem}%");

                                        item.Chance = (float)Config.Mountains_Totem / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 690:
                                    if (item.Chance != (Config.Beach_Totem / 100))
                                    {
                                        PrintToLog($"Setting Beachs_Totem's odds to {Config.Beach_Totem}%");

                                        item.Chance = (float)Config.Beach_Totem / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 709:
                                    if (item.Chance != (Config.Hardwood / 100))
                                    {
                                        PrintToLog($"Setting Hardwood's odds to {Config.Hardwood}%");

                                        item.Chance = (float)Config.Hardwood / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 749:
                                    if (item.Chance != (Config.Omni_Geode / 100))
                                    {
                                        PrintToLog($"Setting Omni_Geode's odds to {Config.Omni_Geode}%");

                                        item.Chance = (float)Config.Omni_Geode / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 766:
                                    if (item.Chance != (Config.Slime / 100))
                                    {
                                        PrintToLog($"Setting Slime's odds to {Config.Slime}%");

                                        item.Chance = (float)Config.Slime / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 768:
                                    if (item.Chance != (Config.Solar_Essence / 100))
                                    {
                                        PrintToLog($"Setting Solar_Essence's odds to {Config.Solar_Essence}%");

                                        item.Chance = (float)Config.Solar_Essence / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 769:
                                    if (item.Chance != (Config.Void_Essence / 100))
                                    {
                                        PrintToLog($"Setting Void_Essence's odds to {Config.Void_Essence}%");

                                        item.Chance = (float)Config.Void_Essence / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 770:
                                    if (item.Chance != (Config.Mixed_Seeds / 100))
                                    {
                                        PrintToLog($"Setting Mixed_Seeds's odds to {Config.Mixed_Seeds}%");

                                        item.Chance = (float)Config.Mixed_Seeds / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 797:
                                    if (item.Chance != (Config.Pearl / 100))
                                    {
                                        PrintToLog($"Setting Pearl's odds to {Config.Pearl}%");

                                        item.Chance = (float)Config.Pearl / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 802:
                                    if (item.Chance != (Config.Cactus_Seeds / 100))
                                    {
                                        PrintToLog($"Setting Cactus_Seeds's odds to {Config.Cactus_Seeds}%");

                                        item.Chance = (float)Config.Cactus_Seeds / 100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 812:
                                    if (item.Chance != (Config.Roe / 100))
                                    {
                                        PrintToLog($"Setting Roe's odds to {Config.Roe}%");

                                        item.Chance = (float) Config.Roe /100;
                                        pond.GetFishPondData().SpawnTime = 0;
                                    }
                                    break;
                                case 814:
                                    if (item.Chance != (Config.Squid_Ink / 100))
                                    {
                                        PrintToLog($"Setting Squid_Ink's odds to {Config.Squid_Ink}%");

                                        item.Chance = (float)Config.Squid_Ink / 100;
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
            if (!Config.SuppressLog)
            {
                this.Monitor.Log(message, LogLevel.Debug);
            }
        }
    }
}
