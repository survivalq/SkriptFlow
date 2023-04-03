using System.Numerics;
using ImGuiNET;
using SkriptFlow.FlowEngine;

namespace SkriptFlow.Tabs
{
    internal class ArmorTab
    {
        private string armorName = "leather";
        private string customName = "";
        private string customNBT = "Unbreakable:1b,HideFlags:4";
        private string itemLore = "&4Leave EMPTY for no lore!\n&e&bYou can use color codes here.";
        private string itemSkript = "# SkriptFlow uses event entities (loop-player/attacker/victim)\n# Skript inside here gets executed with preferred trigger.\n# send \"Hello, World!\" to loop-player\n# send \"You attacked %name of victim%\" to attacker";
        private string outputSkript = "";
        private string outputGive = "";
        private int selectedOption = 0;
        private int selectedTriggerOption = 0;
        private Vector4 color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        ArmorGen armorGen = new ArmorGen();

        public void RenderTab()
        {
            string[] examples = new string[] { "leather", "iron", "gold", "chainmail", "diamond", "netherite" };
            if (ImGui.BeginCombo("Armor Type", examples[selectedOption]))
            {
                for (int i = 0; i < examples.Length; i++)
                {
                    bool isSelected = (selectedOption == i);
                    if (ImGui.Selectable(examples[i], isSelected))
                    {
                        selectedOption = i;
                        armorName = examples[i];
                    }
                }
                ImGui.EndCombo();
            }

            ImGui.SameLine();

            ImGui.ColorEdit4("Armor Color", ref color, ImGuiColorEditFlags.NoInputs);

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
                ImGui.InputTextMultiline("##editLoreInput", ref itemLore, 32768, new Vector2(-1, 310));

                if (ImGui.Button("Exit", new Vector2(64, 24)))
                {
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }

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

                ImGui.Text("Select trigger event:");

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

            ImGui.Text("Output Skript & Obtain");
            ImGui.InputTextMultiline("##OutputSkript", ref outputSkript, 16384, new Vector2(500, 100));
            ImGui.InputTextMultiline("##OutputGive", ref outputGive, 16384, new Vector2(500, 100));

            (string skriptGive, string skriptCode) = armorGen.Generate(armorName, customName, itemLore, customNBT, color, selectedTriggerOption, itemSkript);
            outputGive = skriptGive;
            outputSkript = skriptCode;
        }
    }
}