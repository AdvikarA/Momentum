using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public bool cp = true;
    public bool[] levels = new bool[8];

    public static Settings Instance { get; private set; }
    private void Awake()
    {
        for(int i = 0; i < 8; i++)
        {
            levels[i] = false;
        }
        levels[0] = true;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void IsCheckP()
    {
        cp = !cp;
    }
}
