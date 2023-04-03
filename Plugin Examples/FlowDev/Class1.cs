using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using ClickableTransparentOverlay; // Make sure this NuGet package is installed.
using Newtonsoft.Json; // Make sure this NuGet package is installed.
using ImGuiNET;

// Each plugin is also in a tab when their enabled, naming scheme goes by the file name example.dll
public class SkriptFlowSDK
{
    // Parameters must be defined, they will get stored in the memory, 
    // but are lost when program closes, use Json to store on the disk.
    private bool showAlert = false;

    // Main() method is needed, if it does not exist, plugin will not get loaded.
    // This method gets executed 60/s aka Vsync
    public void Main() // This is a render function.
    {
        ImGui.Text("This is a development plugin example!");
        ImGui.Separator();
        
        if (showAlert)
        {
            ImGui.OpenPopup("Alert");
            if (ImGui.BeginPopupModal("Alert", ref showAlert, ImGuiWindowFlags.AlwaysAutoResize))
            {
                ImGui.Text("This is an alert!");
                ImGui.Separator();

                if (ImGui.Button("OK", new Vector2(120, 0)))
                {
                    showAlert = false;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }
        }

        if (ImGui.Button("Show Alert"))
        {
            showAlert = true;
        }
    }
}