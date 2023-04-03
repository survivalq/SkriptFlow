using System.Numerics;
using SkriptFlow.FlowEngine;
using ImGuiNET;

namespace SkriptFlow.Tabs
{
    internal class WeaponTab
    {
        private string itemName = "apple";
        private string customName = "";
        private string customNBT = "Unbreakable:1b,HideFlags:4";
        private string itemLore = "&4Leave EMPTY for no lore!\n&e&bYou can use color codes here.";
        private string itemSkript = "# SkriptFlow uses event entities (loop-player/attacker/victim)\n# Skript inside here gets executed with preferred trigger.\n# send \"Hello, World!\" to loop-player\n# send \"You attacked %name of victim%\" to attacker";
        private string outputSkript = "";
        private string outputGive = "";
        private int selectedTriggerOption = 0;
        WeaponGen weaponGen = new WeaponGen();

        public void RenderTab()
        {
            ImGui.InputText("Item Name", ref itemName, 128);

            ImGui.InputText("Custom Name", ref customName, 128);

            ImGui.InputText("Custom NBT", ref customNBT, 128);

            ImGui.Text("Item Lore:");
            if (ImGui.Button("Edit Lore", new Vector2(128, 32)))
            {
                ImGui.OpenPopup("Edit Lore");
            }

            ImGui.SetNextWindowSize(new Vector2(400, 400), ImGuiCond.Appearing);
            if (ImGui.BeginPopupModal("Edit Lore"))
            {
                ImGui.Text("Edit Lore:");
                ImGui.InputTextMultiline("##editLoretInput", ref itemLore, 32768, new Vector2(-1, 310));

                if (ImGui.Button("Exit", new Vector2(64, 24)))
                {
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }

            // Add another multilined input with text above called Custom Skript
            ImGui.Text("Item Skript:");
            if (ImGui.Button("Edit Skript", new Vector2(128, 32)))
            {
                ImGui.OpenPopup("Edit Skript");
            }

            ImGui.SetNextWindowSize(new Vector2(700, 430), ImGuiCond.Appearing);
            if (ImGui.BeginPopupModal("Edit Skript"))
            {
                ImGui.Text("Edit Skript:");
                ImGui.InputTextMultiline("##editSkriptInput", ref itemSkript, 32768, new Vector2(-1, 310));

                string[] triggerList = new string[] { "Passive", "On Damage" };
                if (ImGui.BeginCombo("Trigger event", triggerList[selectedTriggerOption]))
                {
                    for (int i = 0; i < triggerList.Length; i++)
                    {
                        bool isSelected = (selectedTriggerOption == i);
                        if (ImGui.Selectable(triggerList[i], isSelected))
                        {
                            selectedTriggerOption = i;
                        }
                    }
                    ImGui.EndCombo();
                }

                if (ImGui.Button("Exit", new Vector2(64, 24)))
                {
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }

            // Add multilined inputs called "Output Skript" and "Output Give"
            ImGui.Text("Output Skript & Obtain");
            ImGui.InputTextMultiline("##OutputSkript", ref outputSkript, 32768, new Vector2(500, 100));
            ImGui.InputTextMultiline("##OutputGive", ref outputGive, 32768, new Vector2(500, 100));

            (string skriptGive, string skriptCode) = weaponGen.Generate(itemName, customName, itemLore, customNBT, selectedTriggerOption, itemSkript);
            outputGive = skriptGive;
            outputSkript = skriptCode;
        }
    }
}