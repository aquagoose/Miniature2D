using Pie;
using Pie.Windowing;

namespace Miniature2D;

public class GameBase : IDisposable
{
    public readonly Window Window;

    public readonly GraphicsDevice GraphicsDevice;

    public GameBase()
    {
        WindowSettings settings = new WindowSettings()
        {
            StartVisible = false
        };
        
        Window = Window.CreateWithGraphicsDevice(settings, out GraphicsDevice);
    }

    public virtual void Initialize() { }

    public virtual void Update() { }

    public virtual void Draw() { }

    public void Run()
    {
        Window.Visible = true;

        Initialize();
        
        while (!Window.ShouldClose)
        {
            Window.ProcessEvents();
            
            Update();
            
            Draw();
            
            GraphicsDevice.Present(1);
        }
    }

    public void Dispose()
    {
        GraphicsDevice.Dispose();
        Window.Dispose();
    }
}