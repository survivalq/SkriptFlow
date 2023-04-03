# SkriptFlow
![This is an image](https://media.discordapp.net/attachments/891649862817427531/1092520940224659507/skriptflow_logo.png?width=992&height=415)
> Advance lore/skript generator.

# Overview
SkriptFlow is an open-source automation tool designed to streamline your workflow and save time on building your server. With SkriptFlow, creating new items for your server is made easier and more efficient.

# Installation 💻
Installing SkriptFlow is simple and straightforward. Follow these steps to get started:

1. Ensure that your system supports .NET 7.0 or later. You can download the runtime [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).
2. Download the SkriptFlow build from the [releases page](https://github.com/survivalq/SkriptFlow/releases/tag/Stable).

# Themes 🎨
SkriptFlow comes with a few themes included in the stable build. However, you can also use the included FlowStyle plugin to customize the look and feel of the tool to your liking.

# Plugin Documentation 📖
The SkriptFlow plugin template is a .NET library that can be used to create custom plugins for SkriptFlow. To use the template, follow these steps:

1. Make sure the ClickableTransparentOverlay and Newtonsoft.Json NuGet packages are installed.
2. Copy the template code from [Plugin Examples -> Plugin Template] into a new C# file in your project.
3. Customize the plugin by modifying the code to fit your needs.
4. Define any necessary parameters in the SkriptFlowSDK class. These parameters will be stored in memory but will be lost when the program closes. To store them on disk, use the JsonConvert.SerializeObject() method to serialize the parameters to a JSON string and write them to a file.
5. Implement the Main() method in the SkriptFlowSDK (or whatever you name it) class. This method will be executed 60 times per second (Vsync) and is used for rendering.
6. Build the project to create a DLL file. You can use the following command to build the project:
```C-Sharp
dotnet build -c Release
```
7. Place the DLL file in the plugins folder of your SkriptFlow installation.
8. Enable the plugin in SkriptFlow by clicking on the plugin tab and toggling the switch next to the plugin name.

⚠️ Please note that plugins from untrusted sources may contain malware, so exercise caution when enabling them.
🤔 Any questions how ImGui.NET works should be asked from ChatGPT, it will detail how it works, because the library lacks documentation.
