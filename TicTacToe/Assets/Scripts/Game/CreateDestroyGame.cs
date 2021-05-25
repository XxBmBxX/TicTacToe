using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateDestroyGame : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    PhotonView PV;
    private CanvasSwap roomCanvas;
    [PunRPC]
    public void StartGame()
    {
        if (GameObject.FindGameObjectWithTag("GameGridPrefab") == null)
        {
            Instantiate(gamePanel,GameObject.FindGameObjectWithTag("StartGame").transform);
        }       
    }
    public void OnClick_LeaveRoom()
    {
        if (GameObject.FindGameObjectWithTag("GameGridPrefab") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("GameGridPrefab"));
        }
        PhotonNetwork.LeaveRoom(true);
        roomCanvas._LobbyMenu.Hide();
        roomCanvas._StartMenu.Show();
    }
    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvas = canvases;
    }
    public void StartGame_OnClick()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                PV.RPC("StartGame", RpcTarget.All);
            }
            else
            {
                MessageBoxManager.LobbyLeader();
            }
        }
        else
        {
            MessageBoxManager.NotEnoughPlayers();
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (GameObject.FindGameObjectWithTag("GameGridPrefab") != null)
        {
            MessageBoxManager.EnemySurrender();
            Destroy(GameObject.FindGameObjectWithTag("GameGridPrefab"));
        } 
    }
}
