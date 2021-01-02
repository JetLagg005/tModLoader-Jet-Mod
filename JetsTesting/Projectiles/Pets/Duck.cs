using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JetsTesting.Projectiles.Pets
{
	public class Duck : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Duck");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.SuspiciousTentacle);
			aiType = ProjectileID.SuspiciousTentacle; 
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
		    JetPlayer modPlayer = player.GetModPlayer<JetPlayer>();
			if (player.dead) {
				modPlayer.duckLightPet = false;
			}
			if (modPlayer.duckLightPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}