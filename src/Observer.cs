namespace Quelich.Observer;


internal class Observer
{
    static void Main(string[] args)
    {
        var startButtonClickEvent = new StartButtonClickEvent();
        var gameManagerAsObserver = new GameManager();
        var uiManagerAsObserver = new UIManager();

        startButtonClickEvent.AddListener(gameManagerAsObserver);
        startButtonClickEvent.AddListener(uiManagerAsObserver);


        startButtonClickEvent.OnStartButtonClicked();
        startButtonClickEvent.OnStartButtonClicked();

        startButtonClickEvent.RemoveListener(uiManagerAsObserver);

        startButtonClickEvent.OnStartButtonClicked();
    }
}


public interface IButtonClickObserver
{
    void Update(IButtonClick buttonClick);
}

public interface IButtonClick
{
    // Attach an observer to the subject.
    void AddListener(IButtonClickObserver observer);

    // Detach an observer from the subject.
    void RemoveListener(IButtonClickObserver observer);

    // Notify all observers about an event.
    void NotifyListeners();
}


public class StartButtonClickEvent : IButtonClick
{
    public int State { get; set; } = -0;
    List<IButtonClickObserver> _buttonClickObservers = new List<IButtonClickObserver>();
    public void AddListener(IButtonClickObserver observer)
    {
        Console.WriteLine("[StartButtonClickEvent] added a new listener");
        _buttonClickObservers.Add(observer);
    }

    public void RemoveListener(IButtonClickObserver observer)
    {
        _buttonClickObservers.Remove(observer);
        Console.WriteLine("[StartButtonClickEvent] removed a listener");
    }

    public void NotifyListeners()
    {
        Console.WriteLine("[StartButtonClickEvent] Notifying listeners");

        foreach (var observer in _buttonClickObservers)
        {
            observer.Update(this);
        }
    }

    public void OnStartButtonClicked()
    {
        Console.WriteLine("[StartButtonClickEvent] Clicked on start button. Waiting for response..");
        State = new Random().Next(0, 2); // yes or no
        Thread.Sleep(10);
        var res = State == 0 ? "TRUE" : "FALSE";
        Console.WriteLine($"[StartButtonClickEvent] Start button response: {res}");
        NotifyListeners();
    }
}

class UIManager : IButtonClickObserver
{
    public void Update(IButtonClick buttonClick)
    {
        if (buttonClick == null)
            return;
        
        if ((buttonClick as StartButtonClickEvent)!.State == 1)
        {
            Console.WriteLine("[UIManager] Navigating to the game");
        }
    }
}

class GameManager : IButtonClickObserver
{
    public void Update(IButtonClick buttonClick)
    {
        if (buttonClick == null)
            return;

        if ((buttonClick as StartButtonClickEvent)!.State == 0)
        {
            Console.WriteLine("[UIManager] Navigation cancelled");
        }
    }
}