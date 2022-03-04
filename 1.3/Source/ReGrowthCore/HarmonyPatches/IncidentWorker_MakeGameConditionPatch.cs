using HarmonyLib;
using RimWorld;
using System;
using System.Reflection;
using Verse;

namespace ReGrowthCore
{
    [HarmonyPatch(typeof(IncidentWorker_MakeGameCondition), "TryExecuteWorker")]
    public static class IncidentWorker_MakeGameConditionPatch
    {
        public static MethodInfo sendStandardLetterInfo = AccessTools.Method(typeof(IncidentWorker), "SendStandardLetter", 
            new Type[] 
            {
                typeof(TaggedString), typeof(TaggedString), typeof(LetterDef), typeof(IncidentParms), typeof(LookTargets), typeof(NamedArgument[])
            });

        public static bool Prefix(IncidentWorker_MakeGameCondition __instance, IncidentParms parms, ref bool __result)
        {
            if (__instance.def.gameCondition == RGDefOf.Aurora && ReGrowthSettings.MakeAuroraPermanent)
            {
                GameConditionManager gameConditionManager = parms.target.GameConditionManager;
                GameCondition gameCondition = GameConditionMaker.MakeConditionPermanent(__instance.def.gameCondition);
                gameConditionManager.RegisterCondition(gameCondition);
                parms.letterHyperlinkThingDefs = gameCondition.def.letterHyperlinks;
                var test = new NamedArgument[0];
                sendStandardLetterInfo.Invoke(__instance, new object[] { (TaggedString)__instance.def.letterLabel, (TaggedString)gameCondition.LetterText, __instance.def.letterDef, parms, 
                    LookTargets.Invalid, test});
                __result = true;
                return false;
            }
            return true;
        }
    }
}
