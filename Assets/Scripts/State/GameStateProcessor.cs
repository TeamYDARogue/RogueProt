using UnityEngine;
using System.Collections;

public class GameStateProcessor {

    private GameState m_state;
    public GameState State
    {
        get { return m_state; }
        set { m_state = value; }
    }

    public void Execute()
    {
        State.Execute();
    }
}
