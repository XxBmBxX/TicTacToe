using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class GameLogic : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Sprite cross;
    [SerializeField]
    Sprite nought;
    [SerializeField]
    Sprite blank;
    [SerializeField]
    PhotonView PV;
    [SerializeField]
    private TextMeshProUGUI turnText;
    private Button[] cells;
    string Player;
    string playerTurn = "Cross";
    int turnCounter = 0;
    string[] gameGrid = new string[9]{"none", "none", "none", "none", "none", "none", "none", "none", "none", };

    private void Awake()
    {
        PV.ViewID = 4;
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Player = "Cross";
            turnText.text = "It's your turn.";
        }
        else
        {
            Player = "Nought";
            turnText.text = "It's enemy turn.";
        }
        cells = GetComponentsInChildren<Button>();
    }
    public void OnClick(Button clickedButton)
    {      
        if (Player == playerTurn)
        {
            PV.RPC("SpriteChange", RpcTarget.All, ButtonIndex(clickedButton), Player);
        }    
    }
    public int ButtonIndex(Button clickedButton)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i] == clickedButton)
            {
                return i;
            }          
        }
        return -1;       
    }
    [PunRPC]
    public void SpriteChange(int index, string playerClick)
    {
        if (playerClick == "Cross")
        {
            cells[index].GetComponent<Image>().sprite = cross;
            cells[index].interactable = false;
            playerTurn = "Nought";
            gameGrid[index] = "Cross";
            turnCounter++;
            GameWinnerCheck();
        }
        else
        {
            cells[index].GetComponent<Image>().sprite = nought;
            cells[index].interactable = false;
            playerTurn = "Cross";
            gameGrid[index] = "Nought";
            turnCounter++;
            GameWinnerCheck();
        }
        if (playerTurn == Player)
        {
            turnText.text = "It's your turn.";
        }
        else
        {
            turnText.text = "It's enemy turn.";
        }
    }
    [PunRPC]
    public void AnnounceWinner(string winner)
    {
        if (turnCounter == 9)
        {
            MessageBoxManager.Draw();
        }
        else
        {
            MessageBoxManager.MessageBoxNameWinner(winner);
        }        
        for (int i = 0; i < 9; i++)
        {
            gameGrid[i] = "none";
        }
        foreach (Button buttonClicked in cells)
        {
            buttonClicked.interactable = true;
            buttonClicked.GetComponent<Image>().sprite = blank;
        }
        turnCounter = 0;
    }
    public void GameWinnerCheck()
    {
        if (turnCounter >= 5)
        {
            if (gameGrid[0] == Player && gameGrid[1] == Player && gameGrid[2] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[3] == Player && gameGrid[4] == Player && gameGrid[5] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[6] == Player && gameGrid[7] == Player && gameGrid[8] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[0] == Player && gameGrid[3] == Player && gameGrid[6] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[1] == Player && gameGrid[4] == Player && gameGrid[7] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[2] == Player && gameGrid[5] == Player && gameGrid[8] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[0] == Player && gameGrid[4] == Player && gameGrid[8] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
            else if (gameGrid[6] == Player && gameGrid[4] == Player && gameGrid[2] == Player)
            {
                PV.RPC("AnnounceWinner", RpcTarget.All, Player);
            }
        }
        else if (turnCounter == 9)
        {
            PV.RPC("AnnounceWinner", RpcTarget.All, Player);
        }
    }

    
}
