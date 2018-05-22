using UnityEngine;

public class MouseManager : MonoBehaviour {

    public KeyCode key;     //to make a mouse click press mouseButton or key
    private Transform GFX;  //mouseGraphics
    private CircleCollider2D coll;  //collider on mouse pointer
    private bool isPressed = false;
    private int frameCount;

	
    void Awake()
    {
        GFX = transform.GetChild(0);
        coll = GFX.GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        coll.enabled = false;
    }

	void FixedUpdate () {

        //show coursor
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GFX.position = temp;

        //if is clicked then release click (disable collider)
        if (isPressed)
        {
            if(frameCount<3)
            {
                frameCount++;
            }
            else
            {
                coll.enabled = false;
                isPressed = false;
                frameCount = 0;
            }

        }

        //click (enable collider)
        if(!isPressed)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(key))
            {
                coll.enabled = true;
                isPressed = true;
            }
        }
        
        
	}
}
