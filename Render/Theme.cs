using ImGuiNET;
using System.Numerics;

// Themes should be always made compatible with the github version.
// If you want more theme settings, make a pull request and it might get implemented.

namespace SkriptFlow.Render
{
    public class SettingsData
    {
        public float windowBorderSize { get; set; }
        public float windowRounding { get; set; }
        public float frameRounding { get; set; }
        public Vector4 menuBarBg { get; set; }
        public Vector4 windowBg { get; set; }
        public Vector4 frameBg { get; set; }
        public Vector4 frameBgHovered { get; set; }
        public Vector4 frameBgActive { get; set; }
        public Vector4 button { get; set; }
        public Vector4 buttonHovered { get; set; }
        public Vector4 buttonActive { get; set; }
        public Vector4 header { get; set; }
        public Vector4 headerHovered { get; set; }
        public Vector4 headerActive { get; set; }
        public Vector4 textSelectedBg { get; set; }
        public Vector4 titleBg { get; set; }
        public Vector4 titleBgCollapsed { get; set; }
        public Vector4 titleBgActive { get; set; }
        public Vector4 tab { get; set; }
        public Vector4 tabHovered { get; set; }
        public Vector4 tabActive { get; set; }
        public Vector4 tabUnfocused { get; set; }
        public Vector4 tabUnfocusedActive { get; set; }
        public Vector4 resizeGripColor { get; set; }
        public Vector4 resizeGripHoveredColor { get; set; }
        public Vector4 resizeGripActiveColor { get; set; }
        public Vector4 checkMarkColor { get; set; }
        public Vector4 sliderGrabColor { get; set; }
        public Vector4 sliderGrabActiveColor { get; set; }
        public Vector4 scrollbarBgColor { get; set; }
        public Vector4 scrollbarGrabColor { get; set; }
        public Vector4 scrollbarGrabActiveColor { get; set; }
        public Vector4 scrollbarGrabHoveredColor { get; set; }
    }

    class ThemeManager 
    {
        public void ApplySettings(SettingsData settings)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, settings.windowBorderSize);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, settings.windowRounding);
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, settings.frameRounding);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowTitleAlign, 3f);
            ImGui.PushStyleColor(ImGuiCol.MenuBarBg, settings.menuBarBg);
            ImGui.PushStyleColor(ImGuiCol.WindowBg, settings.windowBg);
            ImGui.PushStyleColor(ImGuiCol.FrameBg, settings.frameBg);
            ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, settings.frameBgHovered);
            ImGui.PushStyleColor(ImGuiCol.FrameBgActive, settings.frameBgActive);
            ImGui.PushStyleColor(ImGuiCol.Button, settings.button);
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, settings.buttonHovered);
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, settings.buttonActive);
            ImGui.PushStyleColor(ImGuiCol.Header, settings.header);
            ImGui.PushStyleColor(ImGuiCol.HeaderHovered, settings.headerHovered);
            ImGui.PushStyleColor(ImGuiCol.HeaderActive, settings.headerActive);
            ImGui.PushStyleColor(ImGuiCol.TextSelectedBg, settings.textSelectedBg);
            ImGui.PushStyleColor(ImGuiCol.TitleBg, settings.titleBg);
            ImGui.PushStyleColor(ImGuiCol.TitleBgCollapsed, settings.titleBgCollapsed);
            ImGui.PushStyleColor(ImGuiCol.TitleBgActive, settings.titleBgActive);
            ImGui.PushStyleColor(ImGuiCol.Tab, settings.tab);
            ImGui.PushStyleColor(ImGuiCol.TabHovered, settings.tabHovered);
            ImGui.PushStyleColor(ImGuiCol.TabActive, settings.tabActive);
            ImGui.PushStyleColor(ImGuiCol.TabUnfocused, settings.tabUnfocused);
            ImGui.PushStyleColor(ImGuiCol.TabUnfocusedActive, settings.tabUnfocusedActive);
            ImGui.PushStyleColor(ImGuiCol.ResizeGrip, settings.resizeGripColor);
            ImGui.PushStyleColor(ImGuiCol.ResizeGripHovered, settings.resizeGripHoveredColor);
            ImGui.PushStyleColor(ImGuiCol.ResizeGripActive, settings.resizeGripActiveColor);
            ImGui.PushStyleColor(ImGuiCol.CheckMark, settings.checkMarkColor);
            ImGui.PushStyleColor(ImGuiCol.SliderGrab, settings.sliderGrabColor);
            ImGui.PushStyleColor(ImGuiCol.SliderGrabActive, settings.sliderGrabActiveColor);
            ImGui.PushStyleColor(ImGuiCol.ScrollbarBg, settings.scrollbarBgColor);
            ImGui.PushStyleColor(ImGuiCol.ScrollbarGrab, settings.scrollbarGrabColor);
            ImGui.PushStyleColor(ImGuiCol.ScrollbarGrabActive, settings.scrollbarGrabActiveColor);
            ImGui.PushStyleColor(ImGuiCol.ScrollbarGrabHovered, settings.scrollbarGrabHoveredColor);
        }

        public void ApplyDefaultTheme()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(3f, 2f));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowTitleAlign, 3f);
            ImGui.PushStyleColor(ImGuiCol.MenuBarBg, new Vector4(0.059f, 0.051f, 0.071f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0.059f, 0.051f, 0.071f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(0.102f, 0.090f, 0.122f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, new Vector4(0.239f, 0.231f, 0.290f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.FrameBgActive, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.102f, 0.090f, 0.122f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.239f, 0.231f, 0.290f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.Header, new Vector4(0.279f, 0.279f, 0.279f, 0.500f));
            ImGui.PushStyleColor(ImGuiCol.HeaderHovered, new Vector4(0.494f, 0.494f, 0.494f, 0.518f));
            ImGui.PushStyleColor(ImGuiCol.HeaderActive, new Vector4(0.642f, 0.642f, 0.642f, 0.518f));
            ImGui.PushStyleColor(ImGuiCol.TextSelectedBg, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TitleBg, new Vector4(0.102f, 0.090f, 0.122f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TitleBgCollapsed, new Vector4(0.239f, 0.231f, 0.290f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TitleBgActive, new Vector4(0.071f, 0.071f, 0.090f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.Tab, new Vector4(0.102f, 0.090f, 0.122f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TabHovered, new Vector4(0.239f, 0.231f, 0.290f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TabActive, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TabUnfocused, new Vector4(0.102f, 0.090f, 0.122f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.TabUnfocusedActive, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ResizeGrip, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ResizeGripHovered, new Vector4(0.412f, 0.408f, 0.459f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ResizeGripActive, new Vector4(0.642f, 0.642f, 0.642f, 0.518f));
            ImGui.PushStyleColor(ImGuiCol.CheckMark, new Vector4(1f, 1f, 1f, 1f));
        }
    }
}