using RimWorld;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using VFECore;

namespace ReGrowthCore
{
	public class WeatherOverlay_Hail : WeatherOverlay_Custom
	{
		public int nextDamageTick;
		public WeatherOverlay_Hail()
		{

		}

		public override void TickOverlay(Map map)
		{
			base.TickOverlay(map);
			if (!ReGrowthSettings.DisableHailDamage && map.weatherManager.CurWeatherPerceived == RGDefOf.RG_Hail)
            {
				if (nextDamageTick == 0)
				{
					nextDamageTick = Find.TickManager.TicksGame + Rand.RangeInclusive(300, 600);
				}

				if (Find.TickManager.TicksGame > nextDamageTick)
				{
					DoDamage(map);
					nextDamageTick = Find.TickManager.TicksGame + Rand.RangeInclusive(300, 600);
				}
			}
		}

		public void DoDamage(Map map)
        {
			var victimCandidates = map.mapPawns.AllPawns.Where(x => !x.RaceProps.IsMechanoid && x.Spawned && !x.Position.Roofed(map));
			var victims = RandomlySelectedItems(victimCandidates, (int)(victimCandidates.Count() / 10f)).ToList();
			for (int num = victims.Count - 1; num >= 0; num--)
            {
				var damageInfo = new DamageInfo(DamageDefOf.Blunt, Rand.Range(0.1f, 0.5f));
				victims[num].TakeDamage(damageInfo);
            }
		}

		public static IEnumerable<Pawn> RandomlySelectedItems(IEnumerable<Pawn> sequence, int count)
		{
			return sequence.InRandomOrder().Take(count);
		}
	}
}
