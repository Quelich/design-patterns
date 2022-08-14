namespace Quelich.StateMachine;
class IdleState : GameState
{
    public override void HandleIdle()
    {
        ShowMenu();
        PlayGame();
    }

    void ShowMenu()
    {
        Console.WriteLine("Showing Menu Screen");
    }

    void PlayGame()
    {
        if (_context == null)
        {
            Console.WriteLine("[Idle.cs] Null context");
            return;
        }
        this._context.TransitionTo(new PlayState());
    }

    public override void HandlePlay()
    {
        throw new NotImplementedException();
    }

    public override void HandlePause()
    {
        throw new NotImplementedException();
    }

    public override void HandleUnpause()
    {
        throw new NotImplementedException();
    }

    public override void HandleEnd()
    {
        throw new NotImplementedException();
    }
}