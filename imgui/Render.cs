using ClickableTransparentOverlay;
using ImGuiNET;
using Memory;
using System.Numerics;

namespace imgui
{
    public class RenderClass : Overlay
    {
        private string textInput = "";
        private float floatValue = 0.0f;

        private string GameOffset = "";  //you put your static address here or add a pointer

        //basic example of a pointer for this
        private string pointerExample = "GameAssembly.dll+02E0E240,B8,8,40,48,38,70,80";

        private bool toggleValue = false;
        private string Title = "Starborn";  //put your name here for the menu

        private Mem memory = new Mem();

        private bool attached;
        private string gameName = ""; //put the name of the game here that your attempting to mod

        protected override void Render()
        {
            //here are some things you can do to modify the looks of the ImGui window, this is just leftovers from a mod i made awhile back

            ImGui.PopStyleColor(7);
            ImGui.PopStyleVar(3);
            ImGui.PushStyleColor(ImGuiCol.TitleBg, new Vector4(0.5f, 0.0f, 0.5f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.TitleBgActive, new Vector4(0.5f, 0.0f, 0.5f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0.0f, 0.0f, 0.0f, 0.5f));
            ImGui.SetNextWindowSize(new Vector2(400, 200));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0);
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1f, 1f, 1f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.5f, 0.0f, 0.5f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.6f, 0.1f, 0.6f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0.4f, 0.0f, 0.4f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(0.5f, 0.0f, 0.5f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.TextSelectedBg, new Vector4(0.5f, 0.0f, 0.5f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.SliderGrab, new Vector4(0.3f, 0.0f, 0.3f, 1.0f));
            ImGui.Begin(Title, ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize);

            //here is some basic things for the menu

            if (ImGui.Button("Button"))
            {
            }

            if (ImGui.Checkbox("Toggle", ref toggleValue))
            {
            }

            ImGui.SliderFloat("Slider", ref floatValue, 0.0f, 1.0f);

            if (ImGui.TreeNode("ImGui Features"))
            {
                ImGui.Text("This is a demonstration of ImGui features.");

                ImGui.Separator();

                if (ImGui.Button("Click Me"))
                {
                }

                if (ImGui.Checkbox("Enable Feature", ref toggleValue))
                {
                }

                ImGui.InputTextMultiline("Text Area", ref textInput, 200, new Vector2(200, 100));

                ImGui.SliderFloat("Slider", ref floatValue, 0.0f, 1.0f);

                string[] comboItems = { "Item 1", "Item 2", "Item 3" };
                int selectedItemIndex = 0;
                if (ImGui.Combo("Combo Box", ref selectedItemIndex, comboItems, comboItems.Length))
                {
                }

                if (ImGui.RadioButton("Option 1", toggleValue))
                {
                }
                ImGui.SameLine();
                if (ImGui.RadioButton("Option 2", !toggleValue))
                {
                }

                Vector4 color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                if (ImGui.ColorEdit4("Color", ref color))
                {
                }

                float progress = 0.5f;
                ImGui.ProgressBar(progress, new Vector2(0.0f, 0.0f));

                if (ImGui.TreeNode("Tree Node"))
                {
                    ImGui.TreePop();
                }

                ImGui.TreePop();
            }

            if (ImGui.Button("Attach"))
            {
                int pid = memory.GetProcIdFromName(gameName);
                if (pid > 0)
                {
                    memory.OpenProcess(pid);
                    attached = true;
                }
            }

            if (attached)
            {
                Vector4 greenColor = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
                ImGui.TextColored(greenColor, "ATTACHED TO  :" + memory.GetProcIdFromName(gameName).ToString());
            }
            else
            {
                Vector4 redColor = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                ImGui.TextColored(redColor, "DETACHED");
            }

            ImGui.End();
        }
    }
}