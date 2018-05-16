using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public float DTime;     //time for the surrounding circle to dissapear
    private float timer;
    public float[] levels;	//how accurate was the press of the button
    public Color color;     //circle's color

    private SpriteRenderer circ; //circle on the gray button
    private CircleRenderer circGFX;

    private float step;

    public ScoreManager SM;

    void Awake()
    {
        circ = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        circGFX = transform.GetChild(1).GetComponent<CircleRenderer>();
        step = 0.8f / (DTime * 60f);    //desired effect/(effect time * 60 frames per second (since it's in the Update))
    }

    void Initiate()
    {
        circ.color = color;
        circGFX.r = 1.5f;
        circGFX.CreatePoints();
        circGFX.ChangeColor(color);
        timer = DTime;
    }

    void OnEnable()
    {
        Initiate();
    }

	// Use this for initialization
	void Start () {
        Initiate();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer>0)
        {
            timer -= Time.deltaTime;
            circGFX.r -= step;
            circGFX.CreatePoints();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Pointer")
        {
            float temp = timer;
            if (temp > levels[0]*DTime)
                SM.LoseMulti();
            else if (temp > levels[1]*DTime)
                SM.AddScore(1);
            else if (temp > levels[2]*DTime)
                SM.AddScore(2);
            else
                SM.AddScore(3);

            gameObject.SetActive(false);
        }
    }
}
