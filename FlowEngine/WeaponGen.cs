namespace SkriptFlow.FlowEngine
{
    internal class WeaponGen
    {
        public (string, string) Generate(string itemType, string itemName, string itemLore, string itemNBT, int triggerOption, string attachedSkript)
        {
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
        give player 1 {itemType} with name ""{itemName}"" {(!string.IsNullOrEmpty(loreText) ? $"with lore {loreText}" : "")} {(!string.IsNullOrEmpty(itemNBT) ? $@"with nbt compound from ""{{{itemNBT}}}""" : "")}";


            string[] compiledSkript = attachedSkript.Split('\n');
			string executeSkript = "";
			foreach (string line in compiledSkript)
			{
                if (triggerOption == 0)
                {
				    executeSkript += $"            {line}\n";
                } else if (triggerOption == 1) {
                    executeSkript += $"        {line}\n";
                }
			}

            string skriptCode = "";

            if (triggerOption == 0)
            {
                skriptCode = $@"every 1 second:
    loop all players:
        if loop-player's tool is a {itemType} named ""{itemName}"" {(!string.IsNullOrEmpty(loreText) ? $"with lore {loreText}" : "")}:
{executeSkript}";

            } else if (triggerOption == 1) {

				skriptCode = $@"on damage:
    if attacker's tool is a {itemType} named ""{itemName}"" {(!string.IsNullOrEmpty(loreText) ? $"with lore {loreText}" : "")}:
{executeSkript}";
            }

            return (skriptGive, skriptCode);
        }
    }
}