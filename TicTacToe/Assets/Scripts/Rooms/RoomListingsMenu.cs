using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListing roomListings;
    [SerializeField]
    private Transform content;
    private List<RoomListing> listings = new List<RoomListing>();
    private CanvasSwap roomCanvases;
    public void FirstInitialize(CanvasSwap canvases)
    {
        roomCanvases = canvases;
    }
    public override void OnJoinedRoom()
    {
        roomCanvases._LobbyMenu.Show();
        roomCanvases._StartMenu.Hide();
        content.DestroyChildren();
        listings.Clear();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = Instantiate(roomListings, content);
                    if (listings != null)
                    {
                        listing.SetRoomInfo(info);
                        listings.Add(listing);
                    }
                }             
            }      
        }
    }
}
