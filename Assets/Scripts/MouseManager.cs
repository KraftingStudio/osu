using UnityEngine;

public class MouseManager : MonoBehaviour {

    public KeyCode key;     //to make a mouse click press mouseButton or key
    private Transform GFX;  //mouseGraphics
	
    void Awake()
    {
        GFX = transform.GetChild(0);
    }


	// Update is called once per frame
	void Update () {

        //show coursor
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GFX.position = temp;

        //register click
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(key))
        {
            print("CLICK");
        }
	}
}
