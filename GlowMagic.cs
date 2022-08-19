using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.DataStructures;
using ReLogic.Content;

// I love you orchid mod

namespace earthmod
{
	public delegate void GlowMagicDelegate (ref PlayerDrawSet drawInfo);
	public sealed class HeldItemLayer : PlayerDrawLayer
	{
		private static readonly Dictionary<int, GlowMagicDelegate> drawMethodsByItemType = new();

		public static void RegisterDrawMethod(int itemType, GlowMagicDelegate drawMethod)
		{
			if (drawMethod == null) return;

			drawMethodsByItemType.Add(itemType, drawMethod);
		}

		// ...

		public override void Unload()
			=> drawMethodsByItemType.Clear();

		public override Position GetDefaultPosition()
			=> new AfterParent(Terraria.DataStructures.PlayerDrawLayers.HeldItem);

		public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
		{
			var player = drawInfo.drawPlayer;
			var item = drawInfo.heldItem;
			var usingItem = player.itemAnimation > 0 && item.useStyle != ItemUseStyleID.None;
			var holdingSuitableItem = item.holdStyle != 0 && !player.pulley;

			if (!player.CanVisuallyHoldItem(item))
			{
				holdingSuitableItem = false;
			}

			var flags = false;
			flags |= drawInfo.shadow != 0f;
			flags |= player.JustDroppedAnItem;
			flags |= player.frozen;
			flags |= !(usingItem || holdingSuitableItem);
			flags |= item.type <= ItemID.None;
			flags |= player.dead;
			flags |= item.noUseGraphic;
			flags |= player.wet && item.noWet;
			flags |= player.happyFunTorchTime;
			flags |= player.happyFunTorchTime && player.HeldItem.createTile == TileID.Torches && player.itemAnimation == 0;

			return !flags;
		}

		protected override void Draw(ref PlayerDrawSet drawInfo)
		{
			var player = drawInfo.drawPlayer;
			var item = player.HeldItem;
			var itemType = item.type;

			if (!drawMethodsByItemType.ContainsKey(item.type)) return;

			drawMethodsByItemType[itemType].Invoke(ref drawInfo);
		}
	}
	public static class GlowMagic
	{
		public static void DrawSimpleItemGlowmaskInWorld(this SpriteBatch spriteBatch, Item item, Color color, float rotation, float scale)
		{
			if (TryGetItemGlowTexture(item, out Texture2D glowTexture))
			{
				DrawSimpleItemGlowmaskInWorld(spriteBatch, item, glowTexture, color, rotation, scale);
			}
		}

		public static void DrawSimpleItemGlowmaskInWorld(this SpriteBatch spriteBatch, Item item, Texture2D texture, Color color, float rotation, float scale)
		{
			spriteBatch.Draw(texture, item.position - Main.screenPosition + item.Size * 0.5f, null, color, rotation, item.Size * 0.5f, scale, SpriteEffects.None, 0f);
		}
		public static void DrawSimpleItemGlowmaskOnPlayer(ref PlayerDrawSet drawInfo)
		{
			if (TryGetItemGlowTexture(drawInfo.heldItem, out Texture2D glowTexture))
			{
				DrawSimpleItemGlowmaskOnPlayer(ref drawInfo, glowTexture);
			}
		}

		public static void DrawSimpleItemGlowmaskOnPlayer(ref PlayerDrawSet drawInfo, Texture2D glowTexture, Color? color = null)
		{
			var player = drawInfo.drawPlayer;
			var item = player.HeldItem;
			var useStyle = item.useStyle;
			var position = new Vector2((int)(drawInfo.ItemLocation.X - Main.screenPosition.X), (int)(drawInfo.ItemLocation.Y - Main.screenPosition.Y));
			var sourceRect = new Rectangle(0, 0, glowTexture.Width, glowTexture.Height);
			var adjustedItemScale = player.GetAdjustedItemScale(item);
			color ??= new Color(240, 240, 240);

			switch (useStyle)
			{
				case ItemUseStyleID.Shoot:
					{
						DrawData data;

						if (Item.staff[item.type])
						{
							var num9 = player.itemRotation + 0.785f * player.direction;
							var num10 = 0f;
							var num11 = 0f;
							var originStaff = new Vector2(0f, glowTexture.Height);

							if (player.gravDir == -1f)
							{
								if (player.direction == -1)
								{
									num9 += 1.57f;
									originStaff = new Vector2(glowTexture.Width, 0f);
									num10 -= glowTexture.Width;
								}
								else
								{
									num9 -= 1.57f;
									originStaff = Vector2.Zero;
								}
							}
							else if (player.direction == -1)
							{
								originStaff = new Vector2(glowTexture.Width, glowTexture.Height);
								num10 -= glowTexture.Width;
							}

							ItemLoader.HoldoutOrigin(drawInfo.drawPlayer, ref originStaff);

							position = new Vector2((int)(drawInfo.ItemLocation.X - Main.screenPosition.X + originStaff.X + num10), (int)(drawInfo.ItemLocation.Y - Main.screenPosition.Y + num11));
							data = new DrawData(glowTexture, position, sourceRect, color.Value, num9, originStaff, adjustedItemScale, drawInfo.itemEffect, 0);
							drawInfo.DrawDataCache.Add(data);

							break;
						}

						var vector5 = new Vector2(glowTexture.Width / 2, glowTexture.Height / 2);
						var vector6 = Main.DrawPlayerItemPos(player.gravDir, item.type);
						var num12 = (int)vector6.X;
						vector5.Y = vector6.Y;
						var origin = new Vector2(-(int)vector6.X, glowTexture.Height / 2);

						if (player.direction == -1)
						{
							origin = new Vector2(glowTexture.Width + num12, glowTexture.Height / 2);
						}

						position = new Vector2((int)(drawInfo.ItemLocation.X - Main.screenPosition.X + vector5.X), (int)(drawInfo.ItemLocation.Y - Main.screenPosition.Y + vector5.Y));
						data = new DrawData(glowTexture, position, sourceRect, color.Value, player.itemRotation, origin, adjustedItemScale, drawInfo.itemEffect, 0);
						drawInfo.DrawDataCache.Add(data);
					}
					break;
				default:
					{
						var origin = new Vector2(player.direction == -1 ? glowTexture.Width : 0, player.gravDir == -1 ? 0 : glowTexture.Height);
						var data = new DrawData(glowTexture, position, sourceRect, color.Value, player.itemRotation, origin, adjustedItemScale, drawInfo.itemEffect, 0);
						drawInfo.DrawDataCache.Add(data);
					}
					break;
			}
		}
		private static bool TryGetItemGlowTexture(Item item, out Texture2D texture)
		{
			if (item.ModItem != null)
			{
				if (ModContent.RequestIfExists<Texture2D>(item.ModItem.Texture + "_Glowmask", out Asset<Texture2D> asset))
				{
					texture = asset.Value;
					return true;
				}

				texture = null;
				return false;
			}

			texture = TextureAssets.GlowMask[item.glowMask].Value;
			return texture is not null;
		}
		public static void DrawProjectileGlowmask(Projectile projectile, SpriteBatch spriteBatch, Texture2D texture, Color color, float offsetX = 0, float offsetY = 0)
		{
			spriteBatch.Draw(texture, projectile.position - Main.screenPosition + projectile.Size * 0.5f + new Vector2(offsetX, offsetY), null, color, projectile.rotation, texture.Size() * 0.5f, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
		}
	}
}