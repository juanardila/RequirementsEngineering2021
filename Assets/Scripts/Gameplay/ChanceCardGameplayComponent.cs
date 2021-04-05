using System.Runtime.CompilerServices;
using UnityEngine;
public class ChanceCardGameplayComponent
{
    protected Command command;
    private int id;
    private string title;
    private string description;

    public enum EventCode
    {
        ROLL_AGAIN = 1,
        ADD_2_ROLL,
        RESOLVED_CARD,
        ADD_4_ROLL,
        ADD_3_ROLL,
        PLAYER_SKIPS_NEXT,
        REMOVE_PROGRESS_CARD,
        EVERYONE_SKIPS_NEXT,
        ADD_4_ESTIMATION,
        ADD_6_ESTIMATION,
        DRAW_AGAIN,
        //Command for solution and error
        SOLUTION = 998,
        PROBLEM
    };

    public ChanceCardGameplayComponent(string title, string description, Command command)
    {
        this.title = title;
        this.description = description;
        this.command = command;
    }
    
    /**
     * Return 0 when no other card was drawn in this instruction
     * or return the last card drawn if so.
     */
    public int followInstructions()
    {
        return command.execute();
    }

    public string getTitle()
    {
        return title;
    }

}