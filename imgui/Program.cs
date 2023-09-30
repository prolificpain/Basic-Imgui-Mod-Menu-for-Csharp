using imgui;

namespace starborn
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            RenderClass render = new RenderClass();
            render.Start().Wait();
        }
    }
}