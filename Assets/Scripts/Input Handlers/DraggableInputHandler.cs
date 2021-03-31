using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

/**
 * This class handles the dragging logic of an input event
 */
public class DraggableInputHandler
{
    protected static Vector3 prevMousePosition;

    private Vector3 initialDragPosition;

    public enum STATES {
        IDLE,
        SELECTED,
        DRAGGING
    };

    protected STATES state; 
    
    public DraggableInputHandler()
    {
        state = STATES.IDLE;
        initialDragPosition = Vector3.zero;
    }
    
    
    /**
     * Returns de delta between previousMouse position and the current
     * in game units.
     */
    public Vector3 getDelta()
    {
        Vector3 current = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 delta = current - prevMousePosition;
        prevMousePosition = current;
        delta.z = 0; //do not move in z
        return delta;
    }
    
    
    public void onClick()
    {
        state = STATES.SELECTED;
        prevMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    
    /**
     * Changes click states and saves the initial drag position
     */
    public void onClick(Vector3 initialPosition)
    {
        onClick();
        initialDragPosition = initialPosition;
    }

    public void onDrag()
    {
        switch (state)
        {
            case STATES.SELECTED:
                state = STATES.DRAGGING;
                break;
            
        }
            
    }

    public void onRelase()
    {
        switch (state)
        {
            case STATES.DRAGGING:
                state = STATES.IDLE;
                break;
        }
    }
    
    public Vector3 getInitialDragPosition()
    {
        return initialDragPosition;
    }


}
