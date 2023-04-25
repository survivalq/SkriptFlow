using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SkriptFlow.FlowEngine;
using ImGuiNET;
using Pastel;
using System.Drawing;

// Check the documentation to make plugins yourself, it gives details on how basic structure should be.

namespace SkriptFlow.Tabs
{
    internal class PluginManager
    {
        private List<Assembly> loadedAssemblies = new List<Assembly>();
        public Dictionary<string, object> pluginInstances = new Dictionary<string, object>();
        public Dictionary<string, MethodInfo> pluginMethods = new Dictionary<string, MethodInfo>();
        public Dictionary<string, bool> pluginEnabled = new Dictionary<string, bool>();

        public PluginManager()
        {
            LoadPlugins();
            SetDefaultStates();
        }

        private void SetDefaultStates()
        {
            foreach (var plugin in pluginMethods)
            {
                pluginEnabled[plugin.Key] = false;
            }
        }

        public void RenderTab() // Executes the Main() method in each plugin, else will throw error.
        {
            ImGui.Text("Plugin Manager - tick the plugin to enable it.");
            ImGui.Separator();
            foreach (var plugin in pluginMethods)
            {
                string pluginName = Path.GetFileName(plugin.Key);
                bool isEnabled = pluginEnabled[plugin.Key];
                ImGui.Checkbox(pluginName, ref isEnabled);
                pluginEnabled[plugin.Key] = isEnabled;
            }
        }

        private void LoadPlugins()
        {
            string pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            if (!Directory.Exists(pluginsFolder))
            {
                Directory.CreateDirectory(pluginsFolder);
            }

            // Load all DLL files in the plugins folder
            var dllFiles = Directory.GetFiles(pluginsFolder, "*.dll");
            foreach (var dllFile in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    loadedAssemblies.Add(assembly);

                    // Get the plugin type
                    Type pluginType = assembly.GetTypes().FirstOrDefault(t => t.GetMethod("Main") != null);

                    // Create an instance of the plugin class
                    object pluginInstance = Activator.CreateInstance(pluginType);

                    // Get the Main method of the plugin
                    MethodInfo renderTabMethod = pluginType.GetMethod("Main");

                    // Add the plugin and its Main method to the dictionaries
                    pluginMethods.Add(Path.GetFileNameWithoutExtension(dllFile), renderTabMethod);
                    pluginInstances.Add(Path.GetFileNameWithoutExtension(dllFile), pluginInstance);
                }
                catch (Exception ex)
                {
                    Logger.Log(LogLevel.ERROR, $"Error loading plugin {dllFile}: {ex.Message}");
                }
            }
        }

    }
}
