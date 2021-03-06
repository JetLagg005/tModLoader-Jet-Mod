using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JetsTesting.Items
{
	public class Duck : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Duck");
			Tooltip.SetDefault("I like ducks, do you like ducks? i do");
		}

		public override void SetDefaults() {
			item.damage = 0;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.Duck>();
			item.width = 16;
			item.height = 30;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 5, 50, 0);
			item.buffType = ModContent.BuffType<Buffs.Duck>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Firefly, 10);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}