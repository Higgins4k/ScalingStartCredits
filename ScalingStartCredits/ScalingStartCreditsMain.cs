using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalingStartCredits
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ScalingStartCreditsMain : BaseUnityPlugin
    {
        public const string modGUID = "zg.scalingstartingcredits";
        public const string modName = "Scaling Start Credits";
        public const string modVersion = "1.0.5";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static ScalingStartCreditsMain Instance;
        internal ManualLogSource pnt;
        public ConfigEntry<int> configCreditIncrement;
        public ConfigEntry<int> configPlayerCountThreshold;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            BindConfiguration();

            pnt = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            pnt.LogInfo("Scaling Start Credits Enabled");
            pnt.LogInfo("Credit to sunnobunno for the original mod");
            harmony.PatchAll();
        }

        private void BindConfiguration()
        {
            configCreditIncrement = Config.Bind("General",
                "Credit Increment",
                15,
                "The amount of credits per player added to the starting group credits");

            configPlayerCountThreshold = Config.Bind("General",
                "Player Threshold",
                4,
                "The number of players required in the lobby before credits are added per new player.");

        }


    }
    }
