using UnityEngine;
using System.Collections;

public abstract class GameState {

    public delegate void ExecuteState();
    public ExecuteState execDelegate;

    public virtual void Execute()
    {
        if(execDelegate != null)
        {
            execDelegate();
        }
    }
}
