using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    GameObject StartMenuCanvas;
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.Name +" "+ roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
    }

    public void JoinLobby_OnLick()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.LocalPlayer.NickName != "")
            {
                PhotonNetwork.JoinRoom(RoomInfo.Name);
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
