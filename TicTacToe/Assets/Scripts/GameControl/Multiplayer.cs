using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;
using LukeWaffel.BUI;

public class Multiplayer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField nickName;
    [SerializeField]
    private Button connectButton;
    private void Start()
    {
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
       
    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }                    
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.Reconnect();
    }
    public void SetNickName()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (!string.IsNullOrWhiteSpace(nickName.text))
            {
                PhotonNetwork.NickName = nickName.text;
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
}    
