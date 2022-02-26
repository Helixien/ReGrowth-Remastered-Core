using HarmonyLib;
using Verse;

namespace ReGrowthCore
{
    [StaticConstructorOnStartup]
	internal static class HarmonyInit
	{
		static HarmonyInit()
		{
			new Harmony("Helixien.ReGrowthCore").PatchAll();
        }
    }
}
