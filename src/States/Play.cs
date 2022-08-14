namespace Quelich.StateMachine;
class PlayState : GameState
{
    public override void HandlePlay()
    {
        ProcessGameplay();
        PauseGame();
    }
    void ProcessGameplay()
    {
        Console.WriteLine("Shooting zombies");
    }
    void PauseGame()
    {
        if (_context == null)
        {
            Console.WriteLine("[Play.cs] Null context");
            return;
        }
        this._context.TransitionTo(new PauseState());
    }

    public override void HandleIdle()
    {
        Console.WriteLine("Returning to Idle");
    }

    public override void HandlePause()
    {
        throw new NotImplementedException();
    }

    public override void HandleUnpause()
    {
         if (_context == null)
        {
            Console.WriteLine("[Play.cs] Null context");
            return;
        }
        this._context.TransitionTo(new EndState());
    }

    public override void HandleEnd()
    {
        throw new NotImplementedException();
    }
}