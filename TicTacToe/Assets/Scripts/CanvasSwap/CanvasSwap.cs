using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwap : MonoBehaviour
{
    [SerializeField]
    private StartMenu startMenu;
    public StartMenu _StartMenu { get {return startMenu;} }

    [SerializeField]
    private LobbyMenu lobbyMenu;
    public LobbyMenu _LobbyMenu { get { return lobbyMenu; } }

    private void Awake()
    {
        FirstInitialize();
    }
    private void FirstInitialize()
    {
        _StartMenu.FirstInitialize(this);
        _LobbyMenu.FirstInitialize(this);
    }
}
