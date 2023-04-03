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
    }
}