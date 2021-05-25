using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviourPunCallbacks
{
    private CanvasSwap roomCanvas;
    public void OnClick_LeaveRoom()
    {       
        PhotonNetwork.LeaveRoom(true);
        roomCanvas._LobbyMenu.Hide();
        roomCanvas._StartMenu.Show();
    }
    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvas = canvases;
    }
}
