using UnityEngine;
using Verse;

namespace ReGrowthCore
{
	public class WeatherOverlay_SandstormFog : SkyOverlay
	{
		public WeatherOverlay_SandstormFog()
		{
			worldOverlayMat = null;
			worldOverlayPanSpeed1 = 0.0005f;
			worldOverlayPanSpeed2 = 0.0004f;
			worldPanDir1 = new Vector2(1f, 1f);
			worldPanDir2 = new Vector2(1f, -1f);
		}

		public override void TickOverlay(Map map)
		{
			if (worldOverlayMat == null)
			{
				worldOverlayMat = MaterialPool.MatFrom("Weather/SandstormFogWorldOverlay");
				worldOverlayMat.CopyPropertiesFromMaterial(MatLoader.LoadMat("Weather/FogOverlayWorld"));
				worldOverlayMat.shader = MatLoader.LoadMat("Weather/FogOverlayWorld").shader;
				worldOverlayMat.SetTexture("_MainTex", ContentFinder<Texture2D>.Get("Weather/SandstormFogWorldOverlay"));
				worldOverlayMat.SetTexture("_MainTex2", ContentFinder<Texture2D>.Get("Weather/SandstormFogWorldOverlay"));
			}
			base.TickOverlay(map);
		}
	}
}
