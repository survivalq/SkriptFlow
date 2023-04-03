using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using ClickableTransparentOverlay;
using Newtonsoft.Json;
using ImGuiNET;

public class TemplatePlugin
{
    private string exampleText = "Hello, World!";
    public void Main()
    {
        ImGui.Text(exampleText);
    }
}