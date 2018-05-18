using UnityEngine;
using System.Collections;

public class HighscoreWahl : GenericWindow {

	public void NormalGameHigh()
    {
        manager.Open(7);
    }

    public void EndlessGameHigh()
    {
        manager.Open(4);
    }

    public void Back()
    {
        manager.Open(0);
    }
}
