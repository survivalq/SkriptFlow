using ClickableTransparentOverlay;
using System.Threading.Tasks;
using ImGuiNET;
using System.Numerics;
using SkriptFlow.Tabs;
using System.Diagnostics;
using System.IO;
using System;
using Newtonsoft.Json;
using SkriptFlow.FlowEngine;

namespace SkriptFlow.Render
{
    internal class FlowOverlay : Overlay
    {
        // Parameters
        private bool isMainWindowActive = true;
        private bool isPluginWindowActive = false;
        private bool isThemeWindowActive = false;
        private string selectedTheme = null;

        // Classes
        ArmorTab armorTab = new ArmorTab();
        WeaponTab weaponTab = new WeaponTab();
        SkriptChestTab skriptChestTab = new SkriptChestTab();
        PluginManager pluginManager = new PluginManager();
        ThemeManager themeManager = new ThemeManager();

        // Enables DPIAwareness
        public FlowOverlay() : base(true) { }

        protected override Task PostInitialized()
        {
            this.VSync = true;
            themeManager.ApplyDefaultTheme();
            ReplaceFont(@"C:\Windows\Fonts\segoeui.ttf", 22, FontGlyphRangeType.English); // TODO: Add the font option to theme settings
            return Task.CompletedTask;
        }

        protected override void Render()
        {
            ImGui.Begin("SkriptFlow", ref isMainWindowActive, ImGuiWindowFlags.MenuBar);

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
                                Logger.Log(LogLevel.INFO, $"Creating folder plugins...");
                                Directory.CreateDirectory(pluginsFolder);
                            }
                        }
                    }

                    if (ImGui.MenuItem("Open Plugins"))
                    {
                        isPluginWindowActive = true;
                    }
                    ImGui.EndMenu();
                }


                if (ImGui.BeginMenu("Themes"))
                {
                    string themesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "themes");
                    if (!Directory.Exists(themesFolder))
                    {
                        Logger.Log(LogLevel.INFO, $"Creating folder themes...");
                        Directory.CreateDirectory(themesFolder);
                    }

                    if (ImGui.MenuItem("Folder"))
                    {
                        Process.Start("explorer.exe", themesFolder);
                    }

                    if (ImGui.MenuItem("Open Themes"))
                    {
                        isThemeWindowActive = true;
                    }
                    ImGui.EndMenu();
                }

                ImGui.EndMenuBar();
            }

            // Plugins Window
            if (isPluginWindowActive)
            {
                ImGui.Begin("Plugins", ref isPluginWindowActive);
                pluginManager.RenderTab();
                ImGui.End();
            }

            // Themes Window
            if (isThemeWindowActive)
            {
                string[] themeFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "themes"), "*.json");
                
                ImGui.Begin("Themes", ref isThemeWindowActive);
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
                        
                        try
                        {
                            string json = File.ReadAllText(selectedThemeFile);
                            SettingsData settings = JsonConvert.DeserializeObject<SettingsData>(json);

                            themeManager.ApplySettings(settings);
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(LogLevel.ERROR, $"{ex}");
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

            if (isMainWindowActive == false)
            {
                this.Close();
            }
        }
    }
}