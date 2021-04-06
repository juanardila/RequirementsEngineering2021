using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviour, IOnEventCallback
{
    public GameObject userStoryPrefab;
    public Sprite happyEventSprite;
    public Sprite neutralEventSprite;
    public Sprite sadEventSprite;
    public Sprite solutionSprite;
    public Sprite problemSprite;

    private void Start()
    {
        ChanceCardRenderComponent.happySprite = this.happyEventSprite;
        ChanceCardRenderComponent.badSprite = this.sadEventSprite;
        ChanceCardRenderComponent.neutralSprite = this.neutralEventSprite;
        ChanceCardRenderComponent.solutionSprite = this.solutionSprite;
        ChanceCardRenderComponent.problemSprite = this.problemSprite;
        
        PhotonNetwork.AddCallbackTarget(this);
        
        Tuple<int, string, int>[] userStories = FileManager.getInstance().parseUserStories();
        foreach (Tuple<int, string, int> userStoryData in userStories)
        {
            GameObject userStoryGameObject = Instantiate(userStoryPrefab);
            UserStory userStory = userStoryGameObject.GetComponent<UserStory>();
            userStory.initializeGameplay(userStoryData.Item1, userStoryData.Item2, userStoryData.Item3);
        }

        Tuple<int, string, string, int, int>[] events = FileManager.getInstance().parseEvents();
        foreach(Tuple<int, string, string, int, int> entry in events)
        {
            ChanceCard chanceCard = new ChanceCard();
            chanceCard.chanceCardGameplayComponent = new ChanceCardGameplayComponent( entry.Item2,
                entry.Item3, Command.CommandFactory(entry.Item4));
            chanceCard.chanceCardRendererComponent = new ChanceCardRenderComponent(
                ChanceCardRenderComponent.CardType.EVENT,
                entry.Item5, chanceCard.chanceCardGameplayComponent);
            Board.getInstance().chanceDeck.addCard(entry.Item1, chanceCard);
        }
        
        Tuple<int, string, string>[] problems = FileManager.getInstance().parseProblems();
        foreach(Tuple<int, string, string> entry in problems)
        {
            ChanceCard chanceCard = new ChanceCard();
            
            chanceCard.chanceCardGameplayComponent = new ChanceCardGameplayComponent( entry.Item2,
                entry.Item3, Command.CommandFactory(Command.EventCode.PROBLEM));
            
            chanceCard.chanceCardRendererComponent = new ChanceCardRenderComponent(
                ChanceCardRenderComponent.CardType.PROBLEM, chanceCard.chanceCardGameplayComponent );
            Board.getInstance().chanceDeck.addCard(entry.Item1, chanceCard);
        }
        
        Tuple<int, string, string>[] solutions = FileManager.getInstance().parseSolutions();
        foreach(Tuple<int, string, string> entry in solutions)
        {
            ChanceCard chanceCard = new ChanceCard();
            
            chanceCard.chanceCardGameplayComponent = new ChanceCardGameplayComponent( entry.Item2,
                entry.Item3, Command.CommandFactory(Command.EventCode.SOLUTION));
            
            chanceCard.chanceCardRendererComponent = new ChanceCardRenderComponent(
                ChanceCardRenderComponent.CardType.SOLUTION, chanceCard.chanceCardGameplayComponent );
            Board.getInstance().chanceDeck.addCard(entry.Item1, chanceCard);
        }

        
        
        
        Util.Shuffle(Board.getInstance().chanceDeck.getStackOfCards());
    }
    
    
    
    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        object[] data = (object[])photonEvent.CustomData;
        switch (eventCode)
        {
            case UserStoryNetworkingComponent.MOVECARD_CODE:
                UserStoryGameplayComponent.moveToColumn((int)data[0],(string) data[1],(string) data[2] );
                break;
            case SprintNetworkComponent.STARTWORKWITHINITERATION_CODE:
                Sprint.getInstance().getGameplayComponent().advanceToWorkWithInIteration();
                break;
            case IterationNetworkComponent.TURNPLAYED_CODE:
                Iteration.getInstance().getGameplaycomponent().getRound()
                    .finishRemoteTurn((int)data[0], (int) data[1], (int) data[2]);
                break;
            case IterationNetworkComponent.FINISHTURN_CODE:
                Iteration.getInstance().getGameplaycomponent().getRound().endRound();
                break;
            case IterationNetworkComponent.USESOLUTION_CODE:
                UserStoryGameplayComponent.getUserStoryGameplayComponent((int) data[0]).deleteProblem();
                GameObject solution =  Solution.solutions[0];
                Solution.solutions.RemoveAt(0);
                Destroy(solution);
                break;
            case SprintNetworkComponent.STARTPLANNING:
                Sprint.getInstance().getGameplayComponent().advanceToSprintPlanning();
                break;
        }
    }
}
