using System;

public class MiscEvents 
{
    public event Action OnKeyTakedEvent;

    public void KeyTaked()
    {
        OnKeyTakedEvent?.Invoke();
    }

    public event Action OnTimerLeftEvent;

    public void TimerLeft()
    {
        OnTimerLeftEvent?.Invoke();
    }

    public event Action OnAllCollectKeysCompleteEvent;

    public void AllCollectKeysComplete()
    {
        OnAllCollectKeysCompleteEvent?.Invoke();
    }

    public event Action OnPlayerMoveEvent;

    public void PlayerMoveEvent()
    {
        OnPlayerMoveEvent?.Invoke();
    }
    
    
}
