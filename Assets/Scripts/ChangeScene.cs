﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void Change(string name)
    {
        SceneManager.LoadScene(name);
    }
}
