﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
