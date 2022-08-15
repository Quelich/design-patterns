namespace Quelich.StateMachine;

internal class StateMachine
{   
    static void Main(string[] args)
    {
        var context = new Context(new IdleState());
        context.Request();
        context.TransitionTo(context.PlayState);
        context.Request();
        context.TransitionTo(context.PauseState);
        context.Request();
        context.TransitionTo(context.PlayState);
        context.Request();
        context.TransitionTo(context.EndState);
        context.Request();
        context.TransitionTo(context.IdleState);
        context.Request();
    }
}

class Context
{
    // Current game state
    GameState? _state = null;
    public GameState IdleState = new IdleState();
    public GameState PlayState = new PlayState();
    public GameState PauseState = new PauseState();
    public GameState EndState = new EndState();


    public Context(GameState gameState)
    {
        _state = IdleState;
    }

    public void TransitionTo(GameState gameState)
    {
        Console.WriteLine($"Context: Transition to {gameState.GetType().Name}");
        _state = gameState;
        _state.SetContext(this);
    }

    public void Request()
    {
        if (_state == null)
        {
            Console.WriteLine("Null Context");
            return;
        }
        _state.Handle();
    }

}

abstract class GameState
{
    protected Context? _context;

    public void SetContext(Context context)
    {
        _context = context;
    }

    public abstract void Handle();
}

class IdleState : GameState
{
    public override void Handle()
    {
        Console.WriteLine("[IdleState] Showing main menu");
    }
}

class PlayState : GameState
{
    public override void Handle()
    {
        Console.WriteLine("[PlayState] Shooting targets");
    }
}

class PauseState : GameState
{
    public override void Handle()
    {
        Console.WriteLine("[PauseState] showing pause menu");
    }
}

class EndState : GameState
{

    public override void Handle()
    {
        Console.WriteLine("[EndState] showing gameover screen");
    }
}