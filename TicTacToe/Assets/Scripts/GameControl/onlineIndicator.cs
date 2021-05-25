using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;
using LukeWaffel.BUI;

public class onlineIndicator : MonoBehaviourPunCallbacks
{
    public Image connectionImage;
    public Sprite online;
    public Sprite offline;
    public TextMeshProUGUI connectionText;
    public override void OnConnectedToMaster()
    {      
        connectionText.text = "Online";
        connectionImage.sprite = online;
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        connectionText.text = "Offline";
        connectionImage.sprite = offline;
    }   
}



