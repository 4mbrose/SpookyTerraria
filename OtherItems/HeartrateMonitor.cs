using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace SpookyTerraria.OtherItems
{
	public class HeartrateMonitor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heartrate Monitor");

            DisplayName.AddTranslation(GameCulture.Spanish, "Monitor de pulso cardiaco");
            DisplayName.AddTranslation(GameCulture.French, "Moniteur de fr�quence cardiaque");
            DisplayName.AddTranslation(GameCulture.German, "Herzfrequenz-Messger�t");
            DisplayName.AddTranslation(GameCulture.Italian, "Monitoraggio del battito cardiaco");
            Tooltip.SetDefault("Measures your heartrate\nThe higher your heartrate, the faster you move, but your life regen weakens");

            Tooltip.AddTranslation(GameCulture.Spanish, "Mide tu frecuencia card�aca\nCuanto mayor sea tu frecuencia card�aca, m�s r�pido te mover�s, pero tu regeneraci�n de vida se debilita");
            Tooltip.AddTranslation(GameCulture.French, "Mesure votre rythme cardiaque\nPlus votre rythme cardiaque est �lev�, plus vous bougez vite, mais votre r�g�n�ration de vie s'affaiblit");
            Tooltip.AddTranslation(GameCulture.German, "Misst Ihren Herzschlag\nJe h�her Ihre Herzfrequenz, desto schneller bewegen Sie sich, aber Ihre Lebensregeneration wird schw�cher");
            Tooltip.AddTranslation(GameCulture.Spanish, "Misura il tuo battito cardiaco\nPi� alto � il tuo battito cardiaco, pi� velocemente ti muovi, ma la tua vita si indebolisce");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.Red;
            item.maxStack = 1;
            item.scale = 1f;
        }
        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<SpookyPlayer>().accHeartMonitor = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[Main.myPlayer];
            if (player.GetModPlayer<SpookyPlayer>().heartRate <= 100)
            {
                tooltips.Add(new TooltipLine(mod, "Blah.", "hoot")
                {
                    isModifier = true,
                    text = $"Your BPM: {player.GetModPlayer<SpookyPlayer>().heartRate}"

                });
            }
            if (player.GetModPlayer<SpookyPlayer>().heartRate > 100)
            {
                tooltips.Add(new TooltipLine(mod, "Blah.", "hoot")
                {
                    overrideColor = Color.IndianRed,
                    text = $"Your BPM: {player.GetModPlayer<SpookyPlayer>().heartRate}"

                });
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}