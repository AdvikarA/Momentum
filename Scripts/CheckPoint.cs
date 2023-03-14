using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkpoint;
    public ParticleSystem stars;
    public GameObject respawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("AAAEEE");
            stars.transform.position = checkpoint.transform.position;
            respawnpoint.transform.position = checkpoint.transform.position;
            Destroy(checkpoint);
            stars.Play();
        }
    }
}
