namespace Quelich.StateMachine;

class Context
{
    // Current game state
    private GameState? _state = null;

    public Context(GameState gameState)
    {
        this.TransitionTo(gameState);
    }

    public void TransitionTo(GameState gameState)
    {
        Console.WriteLine($"Context: Transition to {gameState.GetType().Name}");
        this._state = gameState;
        this._state.SetContext(this);
    }

    public void RequestIdle()
    {
        if (_state == null)
        {
            Console.WriteLine("[Context.cs] Null State");
            return;
        }
        this._state.HandleIdle();
    }

    public void RequestPlay()
    {
        if (_state == null)
        {
            Console.WriteLine("[Context.cs] Null State");
            return;
        }
        this._state.HandlePlay();
    }

    public void RequestPause()
    {
        if (_state == null)
        {
            Console.WriteLine("[Context.cs] Null State");
            return;
        }
        this._state.HandlePause();
    }
    public void RequestUnpause()
    {
        if (_state == null)
        {
            Console.WriteLine("[Context.cs] Null State");
            return;
        }
        this._state.HandleUnpause();
    }

    public void RequestEnd()
    {
        if (_state == null)
        {
            Console.WriteLine("[Context.cs] Null State");
            return;
        }
        this._state.HandleEnd();
    }
}