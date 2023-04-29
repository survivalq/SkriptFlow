using System.Numerics;

namespace SkriptFlow.FlowEngine
{
    internal class ArmorGen
    {
        public (string, string) Generate(string armorType, string armorName, string itemLore, string itemNBT, Vector4 itemColor, int triggerOption, string attachedSkript)
        {
            int r = (int)(itemColor.X * 255f);
            int g = (int)(itemColor.Y * 255f);
            int b = (int)(itemColor.Z * 255f);

            // Convert RGB values to Minecraft color format
            int convertedColor = ((r & 0xFF) << 16) | ((g & 0xFF) << 8) | (b & 0xFF);
            string colorNBT = $"display:{{color:{convertedColor}}}";

            string[] itemLoreList = itemLore.Split('\n');
            string loreText = "";
            if (itemLoreList.Length > 0)
            {
                loreText = $@"""{itemLoreList[0].Trim()}"""; // Add the first lore line without "and" keyword

                for (int i = 1; i < itemLoreList.Length; i++)
                {
                    loreText += $@" and ""{itemLoreList[i].Trim()}"""; // Add the rest of the lore lines with "and" keyword
                }
            }

            string skriptGive = $@"command /skriptflow:
    permission: op
    trigger:
        give player 1 {armorType} helmet with name ""{armorName} Helmet"" {(!string.IsNullOrEmpty(itemLore) ? $"with lore {loreText}" : "")} {((!string.IsNullOrEmpty(itemNBT) && armorType != "leather") ? $@"with nbt compound from ""{{{itemNBT}}}""" : "")} {(armorType == "leather" ? $@"with nbt compound from ""{{display:{{color:{convertedColor}}}{(!string.IsNullOrEmpty(itemNBT) ? $@", {itemNBT}}}" : "}")}""" : "")}
        give player 1 {armorType} chestplate with name ""{armorName} Chestplate"" {(!string.IsNullOrEmpty(itemLore) ? $"with lore {loreText}" : "")} {((!string.IsNullOrEmpty(itemNBT) && armorType != "leather") ? $@"with nbt compound from ""{{{itemNBT}}}""" : "")} {(armorType == "leather" ? $@"with nbt compound from ""{{display:{{color:{convertedColor}}}{(!string.IsNullOrEmpty(itemNBT) ? $@", {itemNBT}}}" : "}")}""" : "")}
        give player 1 {armorType} leggings with name ""{armorName} Leggings"" {(!string.IsNullOrEmpty(itemLore) ? $"with lore {loreText}" : "")} {((!string.IsNullOrEmpty(itemNBT) && armorType != "leather") ? $@"with nbt compound from ""{{{itemNBT}}}""" : "")} {(armorType == "leather" ? $@"with nbt compound from ""{{display:{{color:{convertedColor}}}{(!string.IsNullOrEmpty(itemNBT) ? $@", {itemNBT}}}" : "}")}""" : "")}
        give player 1 {armorType} boots with name ""{armorName} Boots"" {(!string.IsNullOrEmpty(itemLore) ? $"with lore {loreText}" : "")} {((!string.IsNullOrEmpty(itemNBT) && armorType != "leather") ? $@"with nbt compound from ""{{{itemNBT}}}""" : "")} {(armorType == "leather" ? $@"with nbt compound from ""{{display:{{color:{convertedColor}}}{(!string.IsNullOrEmpty(itemNBT) ? $@", {itemNBT}}}" : "}")}""" : "")}";

            string[] compiledSkript = attachedSkript.Split('\n');
			string executeSkript = "";
            
			foreach (string line in compiledSkript)
			{
                if (triggerOption == 0)
                {
				    executeSkript += $"                        {line}\n";
                } else if (triggerOption == 1) {
                    executeSkript += $"                    {line}\n";
                }
			}

            string skriptCode = "";

            if (triggerOption == 0)
            {
                skriptCode = $@"every 1 second:
    loop all players:
        if name of loop-player's helmet is ""{armorName} Helmet"":
            if name of loop-player's chestplate is ""{armorName} Chestplate"":
                if name of loop-player's leggings is ""{armorName} Leggings"":
                    if name of loop-player's boots is ""{armorName} Boots"":
{executeSkript}";

            } else if (triggerOption == 1) {

				skriptCode = $@"on damage:
    if name of attacker's helmet is ""{armorName} Helmet"":
        if name of attacker's chestplate is ""{armorName} Chestplate"":
            if name of attacker's leggings is ""{armorName} Leggings"":
                if name of attacker's boots is ""{armorName} Boots"":
{executeSkript}";
            }

            return (skriptGive, skriptCode);
        }
    }
}