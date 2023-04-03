using ClickableTransparentOverlay;
using System.Threading.Tasks;
using ImGuiNET;
using System.Numerics;
using SkriptFlow.Tabs;
using System.Diagnostics;
using System.IO;
using System;
using Newtonsoft.Json;
using Pastel;
using System.Drawing;
using SkriptFlow.FlowEngine;
using System.Runtime.InteropServices;

namespace SkriptFlow.Render
{
    internal class FlowOverlay : Overlay
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private bool isOpenWindow = true;
        private bool isOpenWindowPlugin = false;
        private bool isOpenWindowTheme = false;
        private string selectedTheme = null;
        private bool developerConsole = false;

        ArmorTab armorTab = new ArmorTab();
        WeaponTab weaponTab = new WeaponTab();
        SkriptChestTab skriptChestTab = new SkriptChestTab();
        PluginManager pluginManager = new PluginManager();

        protected override Task PostInitialized()
        {
            this.VSync = true;
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 5.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 3.5f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowTitleAlign, 3f);
            ImGui.PushStyleColor(ImGuiCol.MenuBarBg, new Vector4(0f, 0f, 0f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0f, 0f, 0f, 0.9f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(0.13f, 0.33f, 0.38f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.FrameBgActive, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.13f, 0.33f, 0.38f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.Header, new Vector4(0.13f, 0.33f, 0.38f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.HeaderHovered, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.HeaderActive, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.TextSelectedBg, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.TitleBg, new Vector4(0.13f, 0.33f, 0.38f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.TitleBgCollapsed, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.TitleBgActive, new Vector4(0.13f, 0.33f, 0.38f, 0.9f));
            ImGui.PushStyleColor(ImGuiCol.Tab, new Vector4(0.13f, 0.33f, 0.38f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.TabHovered, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.TabActive, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.TabUnfocused, new Vector4(0.13f, 0.33f, 0.38f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.TabUnfocusedActive, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.ResizeGrip, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.ResizeGripHovered, new Vector4(0.13f, 0.33f, 0.38f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.ResizeGripActive, new Vector4(0.13f, 0.33f, 0.38f, 0.8f));
            ImGui.PushStyleColor(ImGuiCol.CheckMark, new Vector4(1f, 1f, 1f, 1f));
            return Task.CompletedTask;
        }

        protected override void Render()
        {
            ImGui.Begin("SkriptFlow", ref isOpenWindow, ImGuiWindowFlags.MenuBar);

            // Menubar for Plugins and Themes
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("Plugins"))
                {
                    if (ImGui.MenuItem("Folder"))
                    {
                        string pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
                        try
                        {
                            Process.Start("explorer.exe", pluginsFolder);
                        }
                        catch 
                        {
                            if (!Directory.Exists(pluginsFolder))
                            {
                                Console.WriteLine($"{Logger.Log("info")} {$"Creating folder plugins...".Pastel(Color.Lime)}");
                                Directory.CreateDirectory(pluginsFolder);
                            }
                        }
                    }

                    if (ImGui.MenuItem("Open Plugins"))
                    {
                        isOpenWindowPlugin = true;
                    }
                    ImGui.EndMenu();
                }


                if (ImGui.BeginMenu("Themes"))
                {
                    string themesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "themes");
                    if (!Directory.Exists(themesFolder))
                    {
                        Console.WriteLine($"{Logger.Log("info")} {$"Creating folder themes...".Pastel(Color.Lime)}");
                        Directory.CreateDirectory(themesFolder);
                    }

                    if (ImGui.MenuItem("Folder"))
                    {
                        Process.Start("explorer.exe", themesFolder);
                    }

                    if (ImGui.MenuItem("Open Themes"))
                    {
                        isOpenWindowTheme = true;
                    }
                    ImGui.EndMenu();
                }

                ImGui.EndMenuBar();
            }

            // Plugins Window
            if (isOpenWindowPlugin)
            {
                ImGui.Begin("Plugins", ref isOpenWindowPlugin);
                pluginManager.RenderTab();
                ImGui.End();
            }

            // Themes Window
            if (isOpenWindowTheme)
            {
                string[] themeFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "themes"), "*.json");
                
                ImGui.Begin("Themes", ref isOpenWindowTheme);
                ImGui.Text("Theme Manager - select and load the theme.");
                ImGui.Separator();
                
                foreach (string themeFile in themeFiles)
                {
                    string fileName = Path.GetFileName(themeFile);

                    bool isSelected = (selectedTheme == fileName);


                    if (ImGui.RadioButton(fileName, isSelected))
                    {
                        selectedTheme = fileName;
                    }
                }

                ImGui.Separator();

                if (ImGui.Button("Load", new Vector2(64, 32)))
                {
                    // Load the selected theme and apply it to the ImGui style
                    if (!string.IsNullOrEmpty(selectedTheme))
                    {
                        string selectedThemeFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "themes", selectedTheme);
                        ThemeManager themeManager = new ThemeManager();
                        
                        try
                        {
                            string json = File.ReadAllText(selectedThemeFile);
                            SettingsData settings = JsonConvert.DeserializeObject<SettingsData>(json);

                            themeManager.ApplySettings(settings);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{Logger.Log("error")} {$"{ex}".Pastel(Color.Red)}");
                        }
                    }
                }
                ImGui.End();
            }

            // Default tabs included by SkriptFlow
            if (ImGui.BeginTabBar("##tabs", ImGuiTabBarFlags.None))
            {
                if (ImGui.BeginTabItem("Armor"))
                {
                    armorTab.RenderTab();
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }

            if (ImGui.BeginTabBar("##tabs", ImGuiTabBarFlags.None))
            {
                if (ImGui.BeginTabItem("Weapon"))
                {
                    weaponTab.RenderTab();
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }

            if (ImGui.BeginTabBar("##tabs", ImGuiTabBarFlags.None))
            {
                if (ImGui.BeginTabItem("Chest GUI"))
                {
                    skriptChestTab.RenderTab();
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }

            // Creates the tabs for plugins, which have been enabled
            foreach (var plugin in pluginManager.pluginMethods)
            {
                string pluginName = Path.GetFileName(plugin.Key);
                if (pluginManager.pluginEnabled[plugin.Key])
                {
                    if (ImGui.BeginTabBar("##tabs", ImGuiTabBarFlags.None))
                    {
                        if (ImGui.BeginTabItem(pluginName))
                        {
                            object pluginInstance = pluginManager.pluginInstances[plugin.Key];
                            plugin.Value.Invoke(pluginInstance, null);
                            ImGui.EndTabItem();
                        }

                        ImGui.EndTabBar();
                    }
                }
            }

            if (isOpenWindow == false)
            {
                this.Close();
            }
        }
    }
}