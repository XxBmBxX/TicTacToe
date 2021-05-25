﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing playerListings;
    [SerializeField]
    private Transform content;
    private List<PlayerListing> listings = new List<PlayerListing>();
    private CanvasSwap roomCanvases;

    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvases = canvases;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();
    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < listings.Count; i++)
        {
            Destroy(listings[i].gameObject);
        }
        listings.Clear();
    }
    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);         
        }
    }
    private void AddPlayerListing(Player player)
    {
        int index = listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            listings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(playerListings, content);           
            if (listings != null)
            {
                listing.SetPlayerInfo(player);
                listings.Add(listing);
            }
        }
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }
    }
}
