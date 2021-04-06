using System.Runtime.CompilerServices;
using UnityEngine;
public class ChanceCardGameplayComponent
{
    protected Command command;
    private int id;
    private string title;
    private string description;



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
   public string getDescription()
    {
        return description;
    }

   public int getId()
   {
       return id;
   }
}