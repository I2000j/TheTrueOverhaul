using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueOverhaul.Common
{
	public class RecCrafts : ModSystem
	{
		public override void AddRecipes()
		{
			if (TrueOverhaul.modConfiguration.RecSystem)
			{
					//Tools

				//Pickaxes
				NewRecipe(3509, 1, 22, 1);
				NewRecipe(3509, 3497, 703, 1);
				NewRecipe(3503, 1, 22, 1);
				NewRecipe(3503, 3497, 703, 1);

				NewRecipe(1, 3515, 21, 1);
				NewRecipe(1, 3491, 705, 1);
				NewRecipe(3497, 3515, 21, 1);
				NewRecipe(3497, 3491, 705, 1);
				
				NewRecipe(3515, 3521, 19, 1);
				NewRecipe(3515, 4059, 3380, 1);
				NewRecipe(3515, 3485, 706, 1);
				NewRecipe(3491, 3521, 19, 1);
				NewRecipe(3491, 4059, 3380, 1);
				NewRecipe(3491, 3485, 706, 1);

				NewRecipeUPD(3521, 86, 103, 57, 2);
				NewRecipeUPD(1917, 86, 103, 57, 2);
				NewRecipeUPD(4059, 86, 103, 57, 2);
				NewRecipeUPD(1320, 86, 103, 57, 2);
				NewRecipeUPD(3485, 86, 103, 57, 2);
				NewRecipeUPD(2341, 86, 103, 57, 2);
				NewRecipeUPD(3521, 1329, 798, 1257, 2);
				NewRecipeUPD(1917, 1329, 798, 1257, 2);
				NewRecipeUPD(4059, 1329, 798, 1257, 2);
				NewRecipeUPD(1320, 1329, 798, 1257, 2);
				NewRecipeUPD(3485, 1329, 798, 1257, 2);
				NewRecipeUPD(2341, 1329, 798, 1257, 2);
				
				NewRecipe(103, 122, 175, 3);
				NewRecipe(798, 122, 175, 3);

				NewRecipe(122, 776, 381, 3);
				NewRecipe(122, 1188, 1184, 3);

				NewRecipe(776, 777, 382, 4);
				NewRecipe(776, 1195, 1191, 4);
				NewRecipe(1188, 777, 382, 4);
				NewRecipe(1188, 1195, 1191, 4);

				NewRecipe(777, 1202, 1198, 4);
				NewRecipe(777, 778, 391, 4);
				NewRecipe(1195, 1202, 1198, 4);
				NewRecipe(1195, 778, 391, 4);

				NewRecipe(778, 1506, 3261, 5);
				NewRecipe(778, 1230, 1006, 5);
				NewRecipeMI(778, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 990, 1225, 4);
				NewRecipe(778, 2176, 1552, 5);
				NewRecipe(1202, 1506, 3261, 5);
				NewRecipe(1202, 1230, 1006, 5);
				NewRecipeMI(1202, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 990, 1225, 54);
				NewRecipe(1202, 2176, 1552, 5);

				NewRecipe(1506, 1294, 1101, 5);
				NewRecipe(1230, 1294, 1101, 5);
				NewRecipe(990, 1294, 1101, 5);
				NewRecipe(2176, 1294, 1101, 5);

				NewRecipeUPD(1294, 3467, 2776, 3456, 6);
				NewRecipeUPD(1294, 3467, 2781, 3457, 6);
				NewRecipeUPD(1294, 3467, 2786, 3458, 6);
				NewRecipeUPD(1294, 3467, 3466, 3459, 6);

				//Axes
				NewRecipe(3506, 10, 22, 1);
				NewRecipe(3506, 3494, 703, 1);
				NewRecipe(3500, 10, 22, 1);
				NewRecipe(3500, 3494, 703, 1);

				NewRecipe(10, 3512, 21, 1);
				NewRecipe(10, 3488, 705, 1);
				NewRecipe(3494, 3512, 21, 1);
				NewRecipe(3494, 3488, 705, 1);

				NewRecipe(3512, 3518, 19, 1);
				NewRecipe(3512, 3482, 706, 1);
				NewRecipe(3488, 3518, 19, 1);
				NewRecipe(3488, 3482, 706, 1);

				NewRecipe(3518, 45, 57, 2);
				NewRecipe(3518, 799, 1257, 2);
				NewRecipe(3482, 45, 57, 2);
				NewRecipe(3482, 799, 1257, 2);

				NewRecipe(45, 217, 175, 3);
				NewRecipe(45, 217, 175, 3);
				NewRecipe(799, 217, 175, 3);
				NewRecipe(799, 217, 175, 3);
				NewRecipe(204, 217, 175, 3);
				NewRecipe(204, 217, 175, 3);

				NewRecipe(217, 991, 381, 3);
				NewRecipe(217, 1222, 1184, 3);

				NewRecipe(991, 1223, 1191, 4);
				NewRecipe(991, 992, 382, 4);
				NewRecipe(1222, 1223, 1191, 4);
				NewRecipe(1222, 992, 382, 4);

				NewRecipe(1223, 993, 391, 4);
				NewRecipe(1223, 1224, 1198, 4);
				NewRecipe(992, 993, 391, 4);
				NewRecipe(992, 1224, 1198, 4);

				NewRecipe(1224, 1507, 3261, 5);
				NewRecipe(1224, 1233, 1006, 5);
				NewRecipeMI(1224, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 990, 1225, 4);
				NewRecipe(1224, 2176, 1552, 5);
				NewRecipe(993, 1507, 3261, 5);
				NewRecipe(993, 1233, 1006, 5);
				NewRecipeMI(993, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 990, 1225, 4);
				NewRecipe(993, 2176, 1552, 5);

				NewRecipe(1507, 1294, 1101, 5);
				NewRecipe(1233, 1294, 1101, 5);
				NewRecipe(990, 1294, 1101, 5);
				NewRecipe(2176, 1294, 1101, 5);

				NewRecipeUPD(1294, 3467, 3523, 3456, 6);
				NewRecipeUPD(1294, 3467, 3524, 3457, 6);
				NewRecipeUPD(1294, 3467, 3522, 3458, 6);
				NewRecipeUPD(1294, 3467, 3525, 3459, 6);

				//Chainsaws

				NewRecipe(2342, 383, 381, 3);
				NewRecipe(2342, 1190, 1184, 3);

				NewRecipe(383, 1197, 1191, 4);
				NewRecipe(383, 384, 382, 4);
				NewRecipe(1190, 1197, 1191, 4);
				NewRecipe(1190, 384, 382, 4);

				NewRecipe(1197, 1204, 1198, 4);
				NewRecipe(1197, 387, 391, 4);
				NewRecipe(384, 1204, 1198, 4);
				NewRecipe(384, 387, 391, 4);

				NewRecipe(1204, 1232, 1006, 5);
				NewRecipeMI(1204, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 579, 1225, 4);
				NewRecipe(387, 1232, 1006, 5);
				NewRecipeMI(387, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 579, 1225, 4);

				//Drills
				NewRecipe(1189, 386, 382, 3);
				NewRecipe(1189, 1196, 1191, 3);
				NewRecipe(385, 386, 382, 3);
				NewRecipe(385, 1196, 1191, 3);

				NewRecipe(1196, 1203, 1198, 4);
				NewRecipe(1196, 388, 391, 4);
				NewRecipe(386, 1203, 1198, 4);
				NewRecipe(386, 388, 391, 4);

				NewRecipe(1203, 1231, 1006, 5);
				NewRecipeMI(1203, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 579, 1225, 4);
				NewRecipe(388, 1231, 1006, 5);
				NewRecipeMI(388, ModContent.ItemType<Items.Materials.MEHSouls>(),1, 579, 1225, 4);

				NewRecipeUPD(1231, 3467, 2774, 3456, 6);
				NewRecipeUPD(1231, 3467, 2779, 3457, 6);
				NewRecipeUPD(1231, 3467, 2784, 3458, 6);
				NewRecipeUPD(1231, 3467, 3464, 3459, 6);
				NewRecipeUPD(579, 3467, 2774, 3456, 6);
				NewRecipeUPD(579, 3467, 2779, 3457, 6);
				NewRecipeUPD(579, 3467, 2784, 3458, 6);
				NewRecipeUPD(579, 3467, 3464, 3459, 6);

				//Hammers
				NewRecipe(196, 3505, 20, 1);
				NewRecipe(657, 3505, 20, 1);
				NewRecipe(2516, 3505, 20, 1);
				NewRecipe(2746, 3505, 20, 1);
				NewRecipe(654, 3505, 20, 1);
				NewRecipe(922, 3505, 20, 1);
				NewRecipe(5283, 3505, 20, 1);
				NewRecipe(660, 3505, 20, 1);
				NewRecipe(196, 3499, 703, 1);
				NewRecipe(657, 3499, 703, 1);
				NewRecipe(2516, 3499, 703, 1);
				NewRecipe(2746, 3499, 703, 1);
				NewRecipe(654, 3499, 703, 1);
				NewRecipe(922, 3499, 703, 1);
				NewRecipe(5283, 3499, 703, 1);
				NewRecipe(660, 3499, 703, 1);

				NewRecipe(3505, 7, 22, 1);
				NewRecipe(3505, 3493, 704, 1);
				NewRecipe(3499, 7, 22, 1);
				NewRecipe(3499, 3493, 704, 1);

				NewRecipe(7, 3511, 21, 1);
				NewRecipe(7, 3487, 705, 1);
				NewRecipe(3493, 3511, 21, 1);
				NewRecipe(3493, 3487, 705, 1);

				NewRecipe(3511, 3481, 706, 1);
				NewRecipe(3511, 3517, 19, 1);
				NewRecipe(3487, 3481, 706, 1);
				NewRecipe(3487, 3517, 19, 1);

				NewRecipe(3481, 797, 1257, 2);
				NewRecipe(3481, 104, 57, 2);
				NewRecipe(3517, 797, 1257, 2);
				NewRecipe(3517, 104, 57, 2);

				NewRecipe(797, 217, 175, 3);
				NewRecipe(104, 217, 175, 3);

				NewRecipe(217, 367, 1225, 4);

				NewRecipe(367, 1234, 1006, 5);
				NewRecipe(367, 1262, 1006, 5);
				NewRecipe(367, 1507, 3261, 5);

				NewRecipeUPD(1234, 3467, 3523, 3456, 6);
				NewRecipeUPD(1234, 3467, 3524, 3457, 6);
				NewRecipeUPD(1234, 3467, 3522, 3458, 6);
				NewRecipeUPD(1234, 3467, 3525, 3459, 6);
				NewRecipeUPD(1262, 3467, 3523, 3456, 6);
				NewRecipeUPD(1262, 3467, 3524, 3457, 6);
				NewRecipeUPD(1262, 3467, 3522, 3458, 6);
				NewRecipeUPD(1262, 3467, 3525, 3459, 6);
				NewRecipeUPD(1507, 3467, 3523, 3456, 6);
				NewRecipeUPD(1507, 3467, 3524, 3457, 6);
				NewRecipeUPD(1507, 3467, 3522, 3458, 6);
				NewRecipeUPD(1507, 3467, 3525, 3459, 6);

				//Painting
				NewRecipe(1071, 1543, 3261, 5);
				NewRecipe(1072, 1544, 3261, 5);
				NewRecipe(1100, 1545, 3261, 5);

				//Hooks
				NewRecipe(84, 1238, 177, 1);
				NewRecipe(84, 1239, 179, 1);
				NewRecipe(84, 4257, 999, 1);
				NewRecipe(84, 1236, 181, 1);
				NewRecipe(84, 1240, 178, 1);
				NewRecipe(84, 1241, 182, 1);
				NewRecipe(84, 1237, 180, 1);

				NewRecipe(1238, 1239, 179, 1);
				NewRecipe(1238, 4257, 999, 1);
				NewRecipe(1238, 1236, 181, 1);
				NewRecipe(1238, 1240, 178, 1);
				NewRecipe(1238, 1241, 182, 1);
				NewRecipe(1238, 1237, 180, 1);
				NewRecipe(1239, 1238, 177, 1);
				NewRecipe(1239, 4257, 999, 1);
				NewRecipe(1239, 1236, 181, 1);
				NewRecipe(1239, 1240, 178, 1);
				NewRecipe(1239, 1241, 182, 1);
				NewRecipe(1239, 1237, 180, 1);
				NewRecipe(4257, 1238, 177, 1);
				NewRecipe(4257, 1239, 179, 1);
				NewRecipe(4257, 1236, 181, 1);
				NewRecipe(4257, 1240, 178, 1);
				NewRecipe(4257, 1241, 182, 1);
				NewRecipe(4257, 1237, 180, 1);
				NewRecipe(1236, 1238, 177, 1);
				NewRecipe(1236, 1239, 179, 1);
				NewRecipe(1236, 4257, 999, 1);
				NewRecipe(1236, 1240, 178, 1);
				NewRecipe(1236, 1241, 182, 1);
				NewRecipe(1236, 1237, 180, 1);
				NewRecipe(1240, 1238, 177, 1);
				NewRecipe(1240, 1239, 179, 1);
				NewRecipe(1240, 4257, 999, 1);
				NewRecipe(1240, 1236, 181, 1);
				NewRecipe(1240, 1241, 182, 1);
				NewRecipe(1240, 1237, 180, 1);
				NewRecipe(1241, 1238, 177, 1);
				NewRecipe(1241, 1239, 179, 1);
				NewRecipe(1241, 4257, 999, 1);
				NewRecipe(1241, 1236, 181, 1);
				NewRecipe(1241, 1240, 178, 1);
				NewRecipe(1241, 1237, 180, 1);
				NewRecipe(1237, 1238, 177, 1);
				NewRecipe(1237, 1239, 179, 1);
				NewRecipe(1237, 4257, 999, 1);
				NewRecipe(1237, 1236, 181, 1);
				NewRecipe(1237, 1240, 178, 1);
				NewRecipe(1237, 1241, 182, 1);

				NewRecipeMI(1238, 210, 3, 185, 331, 1);
				NewRecipeMI(1239, 210, 3, 185, 331, 1);
				NewRecipeMI(4257, 210, 3, 185, 331, 1);
				NewRecipeMI(1236, 210, 3, 185, 331, 1);
				NewRecipeMI(1240, 210, 3, 185, 331, 1);
				NewRecipeMI(1241, 210, 3, 185, 331, 1);
				NewRecipeMI(1237, 210, 3, 185, 331, 1);

				NewRecipeMI(4759, 210, 3, 185, 331, 1);

				NewRecipe(185, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(939, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(1273, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(2585, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(2360, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(1800, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(1915, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(437, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(4980, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(3021, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(3022, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(3023, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(3020, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(2800, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(1829, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);
				NewRecipe(1916, 3572, ModContent.ItemType<Items.Materials.UniverseFragment>(), 6);

				//Fishing Poles
				NewRecipe(2289, 2291, 22, 1);
				NewRecipe(2289, 2291, 704, 1);

				NewRecipe(2291, 2421, 1257, 2);
				NewRecipe(2291, 2293, 57, 2);

					//Weapons

				//Swords
				NewRecipe(24, 3508, 20, 1);
				NewRecipe(2745, 3508, 20, 1);
				NewRecipe(2517, 3508, 20, 1);
				NewRecipe(656, 3508, 20, 1);
				NewRecipe(653, 3508, 20, 1);
				NewRecipe(659, 3508, 20, 1);
				NewRecipe(921, 3508, 20, 1);
				NewRecipe(5284, 3508, 20, 1);
				NewRecipe(24, 3502, 703, 1);
				NewRecipe(2745, 3502, 703, 1);
				NewRecipe(2517, 3502, 703, 1);
				NewRecipe(656, 3502, 703, 1);
				NewRecipe(653, 3502, 703, 1);
				NewRecipe(659, 3502, 703, 1);
				NewRecipe(921, 3502, 703, 1);
				NewRecipe(5284, 3502, 703, 1);

				NewRecipe(3508, 4, 22, 1);
				NewRecipe(3508, 3496, 704, 1);
				NewRecipe(3502, 4, 22, 1);
				NewRecipe(3502, 3496, 704, 1);

				NewRecipe(4, 3514, 21, 1);
				NewRecipe(4, 3490, 705, 1);
				NewRecipe(3496, 3514, 21, 1);
				NewRecipe(3496, 3490, 705, 1);

				NewRecipe(3514, 3484, 706, 1);
				NewRecipe(3514, 3520, 19, 1);
				NewRecipe(3490, 3484, 706, 1);
				NewRecipe(3490, 3520, 19, 1);

				NewRecipe(198, 200, 179, 1);
				NewRecipe(198, 4258, 999, 1);
				NewRecipe(198, 201, 181, 1);
				NewRecipe(198, 199, 178, 1);
				NewRecipe(198, 202, 182, 1);
				NewRecipe(198, 203, 180, 1);
				NewRecipe(200, 198, 177, 1);
				NewRecipe(200, 4258, 999, 1);
				NewRecipe(200, 201, 181, 1);
				NewRecipe(200, 199, 178, 1);
				NewRecipe(200, 202, 182, 1);
				NewRecipe(200, 203, 180, 1);
				NewRecipe(4258, 198, 177, 1);
				NewRecipe(4258, 200, 179, 1);
				NewRecipe(4258, 201, 181, 1);
				NewRecipe(4258, 199, 178, 1);
				NewRecipe(4258, 202, 182, 1);
				NewRecipe(4258, 203, 180, 1);
				NewRecipe(201, 198, 177, 1);
				NewRecipe(201, 200, 179, 1);
				NewRecipe(201, 4258, 999, 1);
				NewRecipe(201, 199, 178, 1);
				NewRecipe(201, 202, 182, 1);
				NewRecipe(201, 203, 180, 1);
				NewRecipe(199, 198, 177, 1);
				NewRecipe(199, 200, 179, 1);
				NewRecipe(199, 4258, 999, 1);
				NewRecipe(199, 201, 181, 1);
				NewRecipe(199, 202, 182, 1);
				NewRecipe(199, 203, 180, 1);
				NewRecipe(202, 198, 177, 1);
				NewRecipe(202, 200, 179, 1);
				NewRecipe(202, 4258, 999, 1);
				NewRecipe(202, 201, 181, 1);
				NewRecipe(202, 199, 178, 1);
				NewRecipe(202, 203, 180, 1);
				NewRecipe(203, 198, 177, 1);
				NewRecipe(203, 200, 179, 1);
				NewRecipe(203, 4258, 999, 1);
				NewRecipe(203, 201, 181, 1);
				NewRecipe(203, 199, 178, 1);
				NewRecipe(203, 202, 182, 1);

				NewRecipe(3764, 3766, 179, 2);
				NewRecipe(3764, 4258, 999, 2);
				NewRecipe(3764, 3767, 181, 2);
				NewRecipe(3764, 3765, 178, 2);
				NewRecipe(3764, 3768, 182, 2);
				NewRecipe(3764, 3769, 180, 2);
				NewRecipe(3766, 3764, 177, 2);
				NewRecipe(3766, 4258, 999, 2);
				NewRecipe(3766, 3767, 181, 2);
				NewRecipe(3766, 3765, 178, 2);
				NewRecipe(3766, 3768, 182, 2);
				NewRecipe(3766, 3769, 180, 2);
				NewRecipe(4258, 3764, 177, 2);
				NewRecipe(4258, 3766, 179, 2);
				NewRecipe(4258, 3767, 181, 2);
				NewRecipe(4258, 3765, 178, 2);
				NewRecipe(4258, 3768, 182, 2);
				NewRecipe(4258, 3769, 180, 2);
				NewRecipe(3767, 3764, 177, 2);
				NewRecipe(3767, 3766, 179, 2);
				NewRecipe(3767, 4258, 999, 2);
				NewRecipe(3767, 3765, 178, 2);
				NewRecipe(3767, 3768, 182, 2);
				NewRecipe(3767, 3769, 180, 2);
				NewRecipe(3765, 3764, 177, 2);
				NewRecipe(3765, 3766, 179, 2);
				NewRecipe(3765, 4258, 999, 2);
				NewRecipe(3765, 3767, 181, 2);
				NewRecipe(3765, 3768, 182, 2);
				NewRecipe(3765, 3769, 180, 2);
				NewRecipe(3768, 3764, 177, 2);
				NewRecipe(3768, 3766, 179, 2);
				NewRecipe(3768, 4258, 999, 2);
				NewRecipe(3768, 3767, 181, 2);
				NewRecipe(3768, 3765, 178, 2);
				NewRecipe(3768, 3769, 180, 2);
				NewRecipe(3769, 3764, 177, 2);
				NewRecipe(3769, 3766, 179, 2);
				NewRecipe(3769, 4258, 999, 2);
				NewRecipe(3769, 3767, 181, 2);
				NewRecipe(3769, 3765, 178, 2);
				NewRecipe(3769, 3768, 182, 2);

				NewRecipe(121, 1185, 1184, 2);
				NewRecipe(121, 483, 381, 2);

				NewRecipe(1185, 484, 382, 3);
				NewRecipe(1185, 1192, 1191, 3);
				NewRecipe(483, 484, 382, 3);
				NewRecipe(483, 1192, 1191, 3);

				NewRecipe(484, 1199, 1198, 4);
				NewRecipe(484, 482, 391, 4);
				NewRecipe(1192, 1199, 1198, 4);
				NewRecipe(1192, 482, 391, 4);

				NewRecipe(482, 368, 1225, 4);
				NewRecipe(1199, 368, 1225, 4);

				NewRecipe(368, 1227, 1006, 5);
				NewRecipeUPD(368, 331, 1226, 1006, 5);

				NewRecipe(1227, 3063, 3467, 6);
				NewRecipe(1226, 3063, 3467, 6);
				NewRecipeUPD(1227, 75, 3065, 3467, 6);
				NewRecipeUPD(1226, 75, 3065, 3467, 6);

				//Spears
				NewRecipe(280, 802, 1257, 2);
				NewRecipe(280, 274, 57, 2);

				NewRecipe(802, 537, 381, 3);
				NewRecipe(802, 1186, 1184, 3);
				NewRecipe(274, 537, 381, 3);
				NewRecipe(274, 1186, 1184, 3);

				NewRecipe(537, 390, 382, 3);
				NewRecipe(537, 1193, 1191, 3);
				NewRecipe(1186, 390, 382, 3);
				NewRecipe(1186, 1193, 1191, 3);

				NewRecipe(390, 406, 391, 4);
				NewRecipe(390, 1200, 1198, 4);
				NewRecipe(1193, 406, 391, 4);
				NewRecipe(1193, 1200, 1198, 4);

				NewRecipe(1200, 550, 1225, 4);
				NewRecipe(406, 550, 1225, 4);

				NewRecipe(550, 1228, 1006, 5);

				//Flails
				NewRecipeUPD(5011, 1329, 801, 1257, 2);
				NewRecipeUPD(5011, 86, 162, 57, 2);

				//Bows
				NewRecipe(39, 3504, 20, 1);
				NewRecipe(2747, 3504, 20, 1);
				NewRecipe(2515, 3504, 20, 1);
				NewRecipe(658, 3504, 20, 1);
				NewRecipe(655, 3504, 20, 1);
				NewRecipe(923, 3504, 20, 1);
				NewRecipe(661, 3504, 20, 1);
				NewRecipe(5282, 3504, 20, 1);
				NewRecipe(39, 3498, 703, 1);
				NewRecipe(2747, 3498, 703, 1);
				NewRecipe(2515, 3498, 703, 1);
				NewRecipe(658, 3498, 703, 1);
				NewRecipe(655, 3498, 703, 1);
				NewRecipe(923, 3498, 703, 1);
				NewRecipe(661, 3498, 703, 1);
				NewRecipe(5282, 3498, 703, 1);

				NewRecipe(3504, 99, 22, 1);
				NewRecipe(3504, 3492, 704, 1);
				NewRecipe(3498, 99, 22, 1);
				NewRecipe(3498, 3492, 704, 1);

				NewRecipe(99, 3510, 21, 1);
				NewRecipe(99, 3486, 705, 1);
				NewRecipe(3492, 3510, 21, 1);
				NewRecipe(3492, 3486, 705, 1);

				NewRecipe(3510, 3480, 706, 1);
				NewRecipe(3510, 3516, 19, 1);
				NewRecipe(3486, 3480, 706, 1);
				NewRecipe(3486, 3516, 19, 1);

				NewRecipe(3516, 44, 57, 2);
				NewRecipe(3516, 796, 1257, 2);
				NewRecipe(3480, 44, 57, 2);
				NewRecipe(3480, 796, 1257, 2);
				
				NewRecipe(44, 120, 175, 3);
				NewRecipe(796, 120, 175, 3);
				NewRecipe(4381, 120, 175, 3);

				NewRecipe(3019, 3029, 1225, 4);
				NewRecipe(2888, 3029, 1225, 4);
				NewRecipe(120, 3029, 1225, 4);
				NewRecipe(3854, 3029, 1225, 4);

				NewRecipe(3029, 2223, 1552, 5);

				NewRecipe(2223, 3540, 3456, 5);

				//Guns
				NewRecipe(95, 2269, 21, 1);

				NewRecipe(95, 96, 57, 2);
				NewRecipe(95, 800, 1257, 2);

				NewRecipe(964, 534, 381, 3);
				NewRecipe(964, 534, 1184, 3);

				//Repeaters
				NewRecipe(435, 436, 382, 3);
				NewRecipe(435, 1194, 1191, 3);
				NewRecipe(1187, 436, 382, 3);
				NewRecipe(1187, 1194, 1191, 3);

				NewRecipe(436, 481, 391, 4);
				NewRecipe(436, 1201, 1198, 4);
				NewRecipe(1194, 481, 391, 4);
				NewRecipe(1194, 1201, 1198, 4);

				NewRecipe(1201, 578, 1225, 4);
				NewRecipe(481, 578, 1225, 4);

				NewRecipe(578, 1229, 1006, 5);

				//Armor NOT Included (Because Too Disbalance)
			}
		}

		public static void NewRecipe(int TW, int item, int bar, int tier)
		{
			int randBars = Main.rand.Next(5,12);
			if (TrueOverhaul.modConfiguration.FriendlyM)
			{
				randBars = 8;
			}
			Recipe recipe = Recipe.Create(item);
			recipe.AddIngredient(TW, 1);
			recipe.AddIngredient(bar, randBars);
			if (tier == 1)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK1>(),1);
			}
			if (tier == 2)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK2>(),1);
			}
			if (tier == 3)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK3>(),1);
			}
			if (tier == 4)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK4>(),1);
			}
			if (tier == 5)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK5>(),1);
			}
			if (tier == 6)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK6>(),1);
			}
			recipe.AddTile<Tiles.RTable>();
			recipe.Register();
		}

		public static void NewRecipeUPD(int TW, int additive, int item, int bar, int tier)
		{
			int randBars = Main.rand.Next(5,12);
			if (TrueOverhaul.modConfiguration.FriendlyM)
			{
				randBars = 8;
			}
			int additiveNUM = Main.rand.Next(10,25);
			if (TrueOverhaul.modConfiguration.FriendlyM)
			{
				additiveNUM = 15;
			}
			Recipe recipe = Recipe.Create(item);
			recipe.AddIngredient(TW, 1);
			recipe.AddIngredient(additive, additiveNUM);
			recipe.AddIngredient(bar, randBars);
			if (tier == 1)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK1>(),1);
			}
			if (tier == 2)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK2>(),1);
			}
			if (tier == 3)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK3>(),1);
			}
			if (tier == 4)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK4>(),1);
			}
			if (tier == 5)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK5>(),1);
			}
			if (tier == 6)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK6>(),1);
			}
			recipe.AddTile<Tiles.RTable>();
			recipe.Register();
		}

		public static void NewRecipeMI(int TW, int additive, int additiveNUM, int item, int bar, int tier)
		{
			int randBars = Main.rand.Next(5,12);
			if (TrueOverhaul.modConfiguration.FriendlyM)
			{
				randBars = 8;
			}
			Recipe recipe = Recipe.Create(item);
			recipe.AddIngredient(TW, 1);
			recipe.AddIngredient(additive, additiveNUM);
			recipe.AddIngredient(bar, randBars);
			if (tier == 1)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK1>(),1);
			}
			if (tier == 2)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK2>(),1);
			}
			if (tier == 3)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK3>(),1);
			}
			if (tier == 4)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK4>(),1);
			}
			if (tier == 5)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK5>(),1);
			}
			if (tier == 6)
			{
				recipe.AddIngredient(ModContent.ItemType<Items.Materials.UPK6>(),1);
			}
			recipe.AddTile<Tiles.RTable>();
			recipe.Register();
		}
	}
}