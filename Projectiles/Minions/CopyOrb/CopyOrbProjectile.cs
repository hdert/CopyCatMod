using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CopyCatMod.Projectiles.Minions.CopyOrb
{
    public class CopyOrbProjectile : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copy Orb");
            // Denotes that this projectile is a pet or minion
            Main.projPet[projectile.type] = true;
            // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            // Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
			//projectile.arrow = true;
			projectile.width = 32;
			projectile.height = 32;
            projectile.tileCollide = false;
			//projectile.aiStyle = 1;
			projectile.friendly = true;
			//projectile.ranged = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
			//aiType = ProjectileID.WoodenArrowFriendly;
        }

		// Additional hooks/methods here.
        public override bool? CanCutTiles() {
            return false;
        }

        public override bool MinionContactDamage() {
            return true;
        }
        public override void AI() {
            Player player = Main.player[projectile.owner];

            #region active check
            // This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active) {
				player.ClearBuff(BuffType<CopyOrbBuff>());
			}
			if (player.HasBuff(BuffType<CopyOrbBuff>())) {
				projectile.timeLeft = 2;
			}
            #endregion

            #region general behavior
            //put three tiles above player while idle
            Vector2 idlePosition = player.Center;
            idlePosition.Y -= 48f;

            //put into idle minion que behind player
            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
            idlePosition.X += minionPositionOffsetX;

            //teleport to player over long distances
            Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();
            if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
                projectile.position = idlePosition;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }
            //todo "overlap stuff"
            #endregion

            #region find target
            // Starting search distance
            float distanceFromTarget = 700f;
            Vector2 targetCenter = projectile.position;
            bool foundTarget = false;

            if (!foundTarget) {
                for (int i = 0; i < Main.maxNPCs; i++) {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy()) {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                        //bool abovePlayer = player.Center.Y > npc.Center.Y;
                        bool closeThroughWall = between < 100f;
                        if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }
            projectile.friendly = foundTarget;
            #endregion

            #region movement
            float speed = 8f;
            float inertia = 20f;

            if (foundTarget) {
                if (distanceFromTarget > 40f) {
                    Vector2 direction = targetCenter -projectile.Center;
                    direction.Normalize();
                    direction *= speed;
                    projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
                }
            }
            else {
                if (distanceToIdlePosition > 600f) {
                    speed = 12f;
                    inertia = 60f;
                }
                else {
                    speed = 4f;
                    inertia = 80f;
                }
                if (distanceToIdlePosition > 20f) {
                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                }
                else if (projectile.velocity == Vector2.Zero) {
                    projectile.velocity.X = -0.15f;
                    projectile.velocity.Y = -0.15f;
                }
            }
            #endregion

            #region animation and visuals
            projectile.rotation = projectile.velocity.X * 0.05f;

            Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 1f);
            #endregion
        }
    }
}