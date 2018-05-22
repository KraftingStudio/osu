using UnityEngine;
using System;

   public class Button : IComparable<Button>
{
    public float tlTime;    //timeline time
    public Vector2 position;   //button's position

    public int CompareTo(Button btn)
    {
        if (btn == null)
            return 1;
        else
            return tlTime.CompareTo(btn.tlTime);
    } 
}

public class ButtonsData {  
 
    public Button[] buttons;
    public float mapTime;
    public string mapName;
    public float DTime;     //button despawn time

}

