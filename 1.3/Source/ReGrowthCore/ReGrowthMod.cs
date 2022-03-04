using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ReGrowthCore
{
    class ReGrowthMod : Mod
    {
        public static ReGrowthSettings settings;
        public ReGrowthMod(ModContentPack pack) : base(pack)
        {
            settings = GetSettings<ReGrowthSettings>();
            new Harmony("Helixien.ReGrowthCore").PatchAll();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            settings.DoSettingsWindowContents(inRect);
        }

        // Return the name of the mod in the settings tab in game
        public override string SettingsCategory()
        {
            return "ReGrowth Core";
        }

        public override void WriteSettings()
        {
            base.WriteSettings();

        }
    }
}
