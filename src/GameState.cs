namespace Quelich.StateMachine;

abstract class GameState
{
    protected Context? _context;

    public void SetContext(Context context)
    {
        this._context = context;
    }

    public abstract void HandleIdle();
    public abstract void HandlePlay();
    public abstract void HandlePause();
    public abstract void HandleUnpause();
    public abstract void HandleEnd();
}