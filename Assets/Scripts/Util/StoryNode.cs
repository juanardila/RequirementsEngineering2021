using UnityEngine;

public class StoryNode
{
    public int id;
    public UserStoryGameplayComponent userStoryGameplayComponent;
    public Transform userStoryTransform;
    
    public static bool operator==(StoryNode storyNode, StoryNode other)
    {
        return storyNode.id == other.id;
    }

    public static bool operator !=(StoryNode storyNode, StoryNode other)
    {
        return !(storyNode == other);
    }

    public StoryNode(int id, UserStoryGameplayComponent userStoryGameplayComponent, Transform userStoryTransform)
    {
        this.id = id;
        this.userStoryTransform = userStoryTransform;
        this.userStoryGameplayComponent = userStoryGameplayComponent;
    }

    public StoryNode(int id)
    {
        this.id = id;
    }
}