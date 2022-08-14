namespace Quelich.StateMachine;
class PauseState : GameState
{
    public override void HandleEnd() { }

    public override void HandleIdle() { }
    public override void HandlePlay() { }

    public override void HandleUnpause() { }

    public override void HandlePause()
    {   
        ShowPauseScreen();
        UnpauseGame();
    }

    public void UnpauseGame()
    {   
        if (_context == null)
        {
            Console.WriteLine("[Pause.cs] Null context");
            return;
        }
        this._context.TransitionTo(new PlayState());
    }
    void ShowPauseScreen()
    {
        Console.WriteLine("Showing Pause Screen");
    }
}