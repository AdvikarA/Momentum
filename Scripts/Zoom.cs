using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera m_OrthographicCamera;
    private float targetsize;
    public float smoothing;
    public float bigboi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            targetsize = bigboi; 

        }
        else
        {
            targetsize = 7; 
        }
        float smoothpos = Mathf.Lerp(Camera.main.orthographicSize, targetsize, smoothing * Time.fixedDeltaTime);

        Camera.main.orthographicSize = smoothpos; 
    }
}
