using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour {

    public int digits;
    private int multi = 1;
    private int score = 0;

    public TextUpdater scoreTxt;
    public TextUpdater multiTxt;

    void Start()
    {
        UpdateScoreText();
    }

	public void AddScore(int level)
    {
        //there are 3 levels of score in osu!
        // 50 points for the worst one
        // 100 points for a bad click
        // and 300 points for a good click
        switch(level)
        {
            case 1:
                score += 50 * multi;
                break;
            case 2:
                score += 100 * multi;
                break;
            case 3:
                score += 300 * multi;
                break;
        }
        //the multiplayer rises with each good click
        multi++;
        UpdateScoreText();

    }

    //if you miss one click you lose the multiplayer
    public void LoseMulti()
    {
        multi = 1;
    }
	
    void UpdateScoreText()
    {
        string temp="";
        int tempScore = score;
        while(tempScore>0)
        {
            temp += tempScore % 10;
            tempScore /= 10;
        }

        int n = temp.Length;
        for(int i=0; i<digits - n; i++)
        {
            temp += '0';
        }

        scoreTxt.UpdateText(Reverse(temp));
        multiTxt.UpdateText(multi + "");
    }

    string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
