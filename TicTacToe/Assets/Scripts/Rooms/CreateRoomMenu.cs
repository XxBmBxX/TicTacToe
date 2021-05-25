using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using LukeWaffel.BUI;
using System;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField roomName;
    [SerializeField]
    private TMP_InputField nickName;
    private CanvasSwap roomCanvases;
    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvases = canvases;
    }
    public void OnClick_CreateRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.LocalPlayer.NickName != "" && !string.IsNullOrWhiteSpace(roomName.text))
            {
                RoomOptions options = new RoomOptions();
                options.MaxPlayers = 2;
                PhotonNetwork.CreateRoom(roomName.text, options, TypedLobby.Default);
            }
            else
            {
                MessageBoxManager.MessageBoxName();
            }
        }       
        else
        {            
            MessageBoxManager.NotConnected();
        }        
    }
    public override void OnCreatedRoom()
    {
        roomCanvases._LobbyMenu.Show();
        roomCanvases._StartMenu.Hide();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        MessageBoxManager.RoomCreationFail();
    }
}
