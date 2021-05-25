using LukeWaffel.BUI;
public static class MessageBoxManager
{
    public static void MessageBoxName()
    {
        UIBox warningBox = new UIBox("MsgBox", "WinnerBox");
        warningBox.header = "Oooops!";
        warningBox.body = "Please insert a name first!";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void MessageBoxNameWinner(string player)
    {
        UIBox warningBox = new UIBox("winnerBox", "WinnerBox");
        warningBox.header = "We have a winner!";
        warningBox.body = player + " won!";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void Draw()
    {
        UIBox warningBox = new UIBox("draw", "WinnerBox");
        warningBox.header = "WOW";
        warningBox.body = "It's a draw!";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void LobbyLeader()
    {
        UIBox warningBox = new UIBox("LobbyLeader", "WinnerBox");
        warningBox.header = "Oh, noo!";
        warningBox.body = "You are not in charge here!";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void NotEnoughPlayers()
    {
        UIBox warningBox = new UIBox("NoPlayers", "WinnerBox");
        warningBox.header = "Oooops!";
        warningBox.body = "There are not enough players yet!";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void RoomCreationFail()
    {
        UIBox warningBox = new UIBox("RoomFailed", "WinnerBox");
        warningBox.header = "Oooops!";
        warningBox.body = "Looks like something went wrong!";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void EnemySurrender()
    {
        UIBox warningBox = new UIBox("FF15", "WinnerBox");
        warningBox.header = "Nice, or not?!";
        warningBox.body = "Looks like your enemy surrendered before your intelligence. Or he just lost connection...";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void NotConnected()
    {
        UIBox warningBox = new UIBox("FF15", "WinnerBox");
        warningBox.header = "Oooops!";
        warningBox.body = "Looks like you are not connected to the server.";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void ConnectionLost()
    {
        UIBox warningBox = new UIBox("ConnectionLost", "WinnerBox");
        warningBox.header = "Oooops!";
        warningBox.body = "Connection lost... Reconnecting...";
        warningBox.buttons.Add(new UIButton("", CloseButtenPressed, "CustomBTN"));
        BUI.Instance.AddToQueue(warningBox);
    }
    public static void CloseBox(string boxname)
    {
        BUI.Instance.CloseBox(boxname);
    }
    public static void CloseButtenPressed(UIBox boxinfo, UIButton btninfo)
    {
        CloseBox(boxinfo.id);
    }
}
