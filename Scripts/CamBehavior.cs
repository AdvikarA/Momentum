using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour
{
    public bool camon = true;  
    public Vector3 offset;
    public float smoothing;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (camon && target.position != null)
        {
            Vector3 targetpos = target.position + offset;
            Vector3 smoothpos = Vector3.Lerp(transform.position, targetpos, smoothing * Time.fixedDeltaTime);
            transform.position = smoothpos;
        }
        
    }
}
