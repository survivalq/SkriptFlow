# Plugin Documentation 📖
The SkriptFlow plugin template is a .NET library that can be used to create custom plugins for SkriptFlow. To use the template, follow these steps:

1. 🚨 Make sure the ClickableTransparentOverlay and Newtonsoft.Json NuGet packages are installed.

2. Copy the this template code into a new C# classlib file in your project.
- Create Project
```
dotnet new classlib -f net7
```
- Template Code:
```cs
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
```
3. Customize the plugin by modifying the code to fit your needs.

4. Define any necessary parameters in the TemplatePlugin class. These parameters will be stored in memory but will be lost when the program closes. To store them on disk, use the JsonConvert.SerializeObject() method to serialize the parameters to a JSON string and write them to a file.

- Example of saving.
```cs
public class TemplatePlugin
{
    private string exampleText = "Hello, World!";
    private string configFilePath;

    public TemplatePlugin()
    {
        // Create a folder for the plugin's data
        string pluginFolderPath = Path.Combine(Environment.CurrentDirectory, "plugins/TemplatePlugin");
        Directory.CreateDirectory(pluginFolderPath);

        // Set the path for the config file
        configFilePath = Path.Combine(pluginFolderPath, "config.json");
    }

    public void Main()
    {
        // Load the config data from the file, or create a new config object if the file doesn't exist
        ConfigData config = LoadConfigData() ?? new ConfigData();

        ImGui.Text(config.ExampleText);

        config.ExampleText = "Hello, ImGui!";

        SaveConfigData(config);
    }

    private ConfigData LoadConfigData()
    {
        // Load the config data from the file, or return null if the file doesn't exist
        if (File.Exists(configFilePath))
        {
            string json = File.ReadAllText(configFilePath);
            return JsonConvert.DeserializeObject<ConfigData>(json);
        }
        else
        {
            return null;
        }
    }

    private void SaveConfigData(ConfigData config)
    {
        // Serialize the config object to JSON format and save it to the file
        string json = JsonConvert.SerializeObject(config);
        File.WriteAllText(configFilePath, json);
    }
}

public class ConfigData
{
    public string ExampleText { get; set; } = "Hello, World!";
}
```

5. Implement the Main() method in the TemplatePlugin (or whatever you name it) class. This method will be executed 60 times per second (Vsync) and is used for rendering.

6. Build the project to create a DLL file. You can use the following command to build the project:
```cs
dotnet build
```

7. Place the DLL and PDB files in the plugins folder of your SkriptFlow installation.

8. Enable the plugin in SkriptFlow by clicking on the plugin tab and toggling the switch next to the plugin name.

⚠️ Please note that plugins from untrusted sources may contain malware, so exercise caution when enabling them.
🤔 Any questions how ImGui.NET works should be asked from ChatGPT, it will detail how it works, because the library lacks documentation.