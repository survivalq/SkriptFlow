using System;
using System.Linq;
using System.Numerics;
using ImGuiNET;

namespace SkriptFlow.Tabs
{
    internal class SkriptChestTab
    {
        private const int NUM_ROWS = 6;
        private const int NUM_COLS = 9;
        private const int NUM_ITEMS = NUM_ROWS * NUM_COLS;
        private string[] itemNames = new string[NUM_ITEMS];
        private string[] customNames = new string[NUM_ITEMS];
        private int[] itemAmounts = new int[NUM_ITEMS];
        private string[] itemLores = new string[NUM_ITEMS];
        private string guiName = "&b&lSkriptFlow GUI";

        public SkriptChestTab()
        {
            for (int i = 0; i < NUM_ITEMS; i++)
            {
                itemNames[i] = "";
                customNames[i] = "";
                itemLores[i] = "";
                itemAmounts[i] = 1;
            }
        }

        public void RenderTab()
        {
            ImGui.InputText("GUI Name", ref guiName, 128);

            // Generate grid of buttons that simulate a chest GUI
            for (int i = 0; i < NUM_ROWS; i++)
            {
                for (int j = 0; j < NUM_COLS; j++)
                {
                    // Compute index of current item
                    int index = i * NUM_COLS + j;

                    // Begin button
                    ImGui.PushID(index);
                    ImGui.Button($"{itemNames[index]} ({itemAmounts[index]})", new Vector2(48, 48));

                    // Open item selector popup on right-click
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                    {
                        ImGui.OpenPopup("Item Selector");
                    }

                    // Item selector popup
                    if (ImGui.BeginPopup("Item Selector"))
                    {
                        ImGui.InputText("Item Name", ref itemNames[index], 50);
                        ImGui.InputText("Custom Name", ref customNames[index], 128);
                        ImGui.InputTextMultiline("Lore", ref itemLores[index], 2048, new Vector2(400, 150));
                        ImGui.SetNextItemWidth(200);
                        ImGui.InputInt("Amount", ref itemAmounts[index]);

                        if (ImGui.Button("Close"))
                        {
                            ImGui.CloseCurrentPopup();
                        }

                        ImGui.EndPopup();
                    }

                    // End button
                    ImGui.PopID();

                    // Add spacing between buttons
                    if (j < NUM_COLS - 1)
                    {
                        ImGui.SameLine();
                    }
                }
            }

            ImGui.Text("Output Skript:");
            string skriptCode = GenerateSkriptCode();
            ImGui.InputTextMultiline("##ChestGUI", ref skriptCode, 500, new Vector2(750, 200));
        }

        private string GenerateSkriptCode()
        {
            string innerSkriptCode = "";
            string inventorySkriptCode = "";

            for (int i = 0; i < NUM_ITEMS; i++)
            {
                if (!string.IsNullOrEmpty(itemNames[i]))
                {
                    innerSkriptCode += $"set slot {i} of {{_gui}} to {itemAmounts[i]} {itemNames[i]}";
                    if (!string.IsNullOrEmpty(customNames[i]))
                    {
                        innerSkriptCode += @$" with name ""{customNames[i]}""";
                    }

                    if (!string.IsNullOrEmpty(itemLores[i]))
                    {
                        string[] loreLines = itemLores[i].Split('\n', StringSplitOptions.RemoveEmptyEntries);
                        innerSkriptCode += " with lore ";
                        innerSkriptCode += string.Join(" and ", loreLines.Select(line => $"\"{line.Trim()}\""));
                    }
                    innerSkriptCode += "\n        ";
                }
            }

            for (int i = 0; i < NUM_ITEMS; i++)
            {
                if (!string.IsNullOrEmpty(itemNames[i]))
                {
                    inventorySkriptCode += $"if index of event-slot = {i}: # INFO: {customNames[i]}\n            # Your skript here ...";
                    inventorySkriptCode += "\n        ";
                }
            }

            string compiledSkript = @$"command /skriptflowgui:
    permission: skriptflow.gui
    trigger:
        set {{_gui}} to a new chest inventory with 6 row with name ""{guiName}""
        {innerSkriptCode}open {{_gui}} to player
        stop
        
on inventory click:
    if name of event-inventory is ""{guiName}"":
        cancel event
        {inventorySkriptCode}";
            return compiledSkript;
        }
    }
}