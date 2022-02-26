using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ReGrowthCore
{
    //public class AncientGraveExtensions : DefModExtension
    //{
    //    public List<PawnKindDef> pawnKindDefsToSpawnInside;
    //}
	//public class Building_AncientGraveFull : Building_Casket
    //{
    //    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    //    {
    //        base.SpawnSetup(map, respawningAfterLoad);
    //        try
    //        {
    //            if (!respawningAfterLoad)
    //            {
    //                var options = this.def.GetModExtension<AncientGraveExtensions>();
    //                if (options?.pawnKindDefsToSpawnInside != null && options.pawnKindDefsToSpawnInside.Any(x => x != null))
    //                {
    //                    LongEventHandler.ExecuteWhenFinished(() =>
    //                    {
    //                        var pawnKind = options.pawnKindDefsToSpawnInside.Where(x => x != null).RandomElement();
    //                        var buriedPawn = PawnGenerator.GeneratePawn(pawnKind);
    //                        buriedPawn.Kill(null);
    //                        buriedPawn.Corpse.Age = Rand.RangeInclusive(50, 300) * GenDate.DaysPerYear * GenDate.TicksPerDay;
    //                        var compRottable = buriedPawn.Corpse.GetComp<CompRottable>();
    //                        compRottable.RotProgress = compRottable.PropsRot.TicksToDessicated + 100000;
    //                        this.innerContainer.TryAddOrTransfer(buriedPawn.Corpse);
    //                    });
    //                }
    //            }
    //        }
    //        catch { };
    //    }
    //
    //    public override void EjectContents()
    //    {
    //        base.EjectContents();
	//		this.Destroy(DestroyMode.Deconstruct);
    //    }
    //}
}
