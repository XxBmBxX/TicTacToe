using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderImageSet : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Image leaderImageObject;
    [SerializeField]
    private Sprite leaderImage;
    [SerializeField]
    private Sprite leaderImageBlank;
    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            leaderImageObject.sprite = leaderImage;
        }
        else
        {
            leaderImageObject.sprite = leaderImageBlank;
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            leaderImageObject.sprite = leaderImage;
        }
        else
        {
            leaderImageObject.sprite = leaderImageBlank;
        }
    }
}
