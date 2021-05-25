using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu playerListingMenu;
    [SerializeField]
    private CreateDestroyGame createDestroyGame;
    private CanvasSwap roomCanvases;

    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvases = canvases;
        playerListingMenu.FirstInitialize(canvases);
        createDestroyGame.FirstInitialize(canvases);

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
