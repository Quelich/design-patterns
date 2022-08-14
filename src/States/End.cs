namespace Quelich.StateMachine;
class EndState : GameState
{

    public override void HandleEnd()
    {
        ShowGameoverScreen();
        EndGame();
    }

    void ShowGameoverScreen()
    {
        Console.WriteLine("Showing gameover screen");
    }
    void EndGame()
    {
        if (_context == null)
        {
            Console.WriteLine("[Pause.cs] Null context");
            return;
        }
        this._context.TransitionTo(new IdleState());
    }

    public override void HandleIdle()
    {
        throw new NotImplementedException();
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
}