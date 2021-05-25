using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingsMenu roomListingsMenu;
    private CanvasSwap roomCanvases;

    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        roomListingsMenu.FirstInitialize(canvases);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
