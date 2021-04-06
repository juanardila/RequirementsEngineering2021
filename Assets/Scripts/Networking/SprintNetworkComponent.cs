using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class SprintNetworkComponent
{
    public const byte STARTWORKWITHINITERATION_CODE = 2;
    public const byte STARTPLANNING = 6;
    
    public SprintNetworkComponent()
    {}

    public void sendAdvanceToWorkInIteration()
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(STARTWORKWITHINITERATION_CODE, null, raiseEventOptions, SendOptions.SendReliable);
    }

    public static void sendStartPlanning()
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(STARTPLANNING, null, raiseEventOptions, SendOptions.SendReliable);
    }
}
