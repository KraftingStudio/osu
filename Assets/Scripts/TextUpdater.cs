using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public string beforeText, afterText;
    private Text txt;

    void Awake()
    {
        txt = GetComponent<Text>();
    }

	public void UpdateText(string value)
    {
        txt.text = beforeText + value + afterText;
    }
}
