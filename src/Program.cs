namespace Quelich.StateMachine;

internal class Program
{
    static void Main(string[] args)
    {   
        var context = new Context(new IdleState());
        // Step #1 - context at Idle
        context.RequestIdle();
        // Step #2 - context at Play
        context.RequestPlay();
        // Step #3 - context at Pause
        context.RequestPause();
        // Step #4 - context at Play
        context.RequestUnpause();
        // Step #5 - context at End
        context.RequestEnd();
    }
}