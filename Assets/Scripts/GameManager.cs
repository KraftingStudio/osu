using UnityEngine;

public class GameManager : MonoBehaviour {

    public TextUpdater TimerText;

    ButtonsData data = new ButtonsData();

    public Transform ButtonsPool;
    private Transform[] ButtonObjects;

    private float[] timeStamps;  //public for testing, needs sorting in the future

    public float tlTime; //timeline time
    private float timer;

    private int it;     //iterator of all buttons
    private int size;   //number of buttons

    void Awake()
    {
        size = ButtonsPool.childCount;
        ButtonObjects = new Transform[size];
        for(int i =0; i<size; i++)
        {
            ButtonObjects[i] = ButtonsPool.GetChild(i);
        }
        foreach(Transform butt in ButtonObjects)
        {
            if(butt.gameObject.activeSelf)
            {
                butt.gameObject.SetActive(false);
            }
        }

        data.buttons = new Button[10];
        for(int i=0; i<10; i++)
        {
            data.buttons[i] = new Button();
            data.buttons[i].position = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));   //random for testing
            data.DTime = 2f;
            data.buttons[i].tlTime = i;
        }

        timeStamps = new float[data.buttons.Length];

        for(int i=0; i<data.buttons.Length; i++)
        {
            timeStamps[i] = data.buttons[i].tlTime;
        }
    }

    void Update()
    {
        if(timer<tlTime)
        {
            timer += Time.deltaTime;
            TimerText.UpdateText(timer.ToString("0.00"));
        }

        //temporary solution
        if(it<data.buttons.Length)
        {
            if (timer > timeStamps[it])
            {
                PlaceButton();
                it++;
            }
        }
        
    }

    Transform FindButton()
    {
        foreach (Transform butt in ButtonObjects)
        {
            if (!butt.gameObject.activeSelf)
            {
                return butt;
            }
        }

        return null;
    }

    void PlaceButton()
    {
        Transform temp = FindButton();
        if(temp!=null)
        {
            //get the buttons position here from the list
            //temp.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f)) ;   //random for testing
            temp.GetComponent<ButtonScript>().DTime = data.DTime;
            temp.position = data.buttons[it].position;
            //consider changing z value slightly to avoid overlapping
            temp.gameObject.SetActive(true);
        }
        else
        {
            print("NO BUTTONS AVAILABLE");
        }
    }
	
}
