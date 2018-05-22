using UnityEngine;
using System.Collections.Generic;

public class GameEditor : MonoBehaviour {

    private ButtonsData map = new ButtonsData();
    public TextUpdater timerTxt;
    public TextUpdater mapNameTxt;
    public Transform EditorButtonsPool;
    private Transform[] EBtns;
    private Transform Ebtn;
    private List<Button> btns = new List<Button>();
    private Button cbtn;
    private float timer;
    private float length;
    private bool isAdding=false;

    #region Initialization
    //reference to dummy buttons
    void Awake()
    {
        EBtns = new Transform[EditorButtonsPool.childCount];
        for(int i=0; i<EditorButtonsPool.childCount; i++)
        {
            EBtns[i] = EditorButtonsPool.GetChild(i);
            EBtns[i].gameObject.SetActive(false);
        }
    }

    //name of the map
    public void SetName(string name)
    {
        map.mapName = name;
    }

    //total length of the map
    public void SetLength(string _length)
    {
        float temp;
        float.TryParse(_length, out temp);
        length = temp;
        map.mapTime = temp;
    }

    public void SetDTime(string _DTime)
    {
        float temp;
        float.TryParse(_DTime, out temp);
        map.DTime = temp;
    }

    //called with the press of the OK button
    public void StartEditor()
    {
        timerTxt.UpdateText(timer.ToString("0.00"));
        mapNameTxt.UpdateText(map.mapName);
    }

    #endregion

    private Transform FindEButton()
    {
        foreach (Transform t in EBtns)
        {
            if (!t.gameObject.activeSelf) return t;
        }
        return null;
    }

    //scale changes with the slider
    public void TimeScaleChange(float scale)
    {
        timer = scale * length;
        timerTxt.UpdateText(timer.ToString("0.000"));

        foreach (Transform t in EBtns)
        {
            t.gameObject.SetActive(false);
        }

        foreach (Button b in btns)
        {
            Transform temp = FindEButton();
            if (b.tlTime < timer && b.tlTime > timer - map.DTime)
            {
                temp.gameObject.SetActive(true);
                temp.position = b.position;
            }
            else
            {
                temp.gameObject.SetActive(false);
            }
        }
    }

    //called when the button "add" is pressed
    public void AddButton()
    {
        if(!isAdding)
        {
            isAdding = true;
            cbtn = new Button();
            cbtn.tlTime = timer;
            btns.Add(cbtn);
            btns.Sort();    //buttons should be sorted by the 
                            //time they appear in since
                            //game manager works that way

            Ebtn = FindEButton();
            if (Ebtn != null)
                Ebtn.gameObject.SetActive(true);
            else
                print("NO BUTTON FOUND\nDid you forget to fill the buttons pool?");
        }

    }

    public void Save()
    {

    }

    void Update()
    {
        if(isAdding)
        {
            //converting to world coords, in front of camera
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos = new Vector3(pos.x, pos.y, 0f);

            Ebtn.position = pos;
            if(Input.GetMouseButtonDown(0))
            {
                cbtn.position = pos;
                isAdding = false;
            }
        }

    }
}
