using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

public class PlayerGameplay
{
    private static Player myself = PhotonNetwork.LocalPlayer;
    public static UserStoryGameplayComponent workedOnStory;

    public static void startDailyWork()
    {
        if (Iteration.getInstance().getGameplaycomponent().
            getCurrentPlayer().Equals(myself))
        {
            LinkedList<StoryNode> storiesInProgress = Board.getInstance().onProgress.GetComponent<Column>()
                .getGameplayComponent().getStories();
            foreach (StoryNode storyNode in storiesInProgress)
            {
                storyNode.userStoryGameplayComponent.setAvailableToWork();
            }
        }
    }

    public static void finishDailyWork()
    {
        LinkedList<StoryNode> storiesInProgress = Board.getInstance().onProgress.GetComponent<Column>()
            .getGameplayComponent().getStories();
        foreach (StoryNode storyNode in storiesInProgress)
        {
            storyNode.userStoryGameplayComponent.setUnAvailableToWork();
        }
    }

    public static bool playerHasSelectedStory()
    {
        return workedOnStory != null;
    }
}
