using UnityEngine;
using System.Collections;
public class Parallaxing : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float smoothing;
    public float test;

    // Use this for initialization
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - smoothing));
        float dist = (cam.transform.position.x * smoothing);
        transform.position = new Vector3(startpos + dist, test, transform.position.z);
        if(temp > startpos + length)
        {
            startpos += length;
           
        }
        else if(temp < startpos - length)
        {
            startpos -= length;
        }
    }
}