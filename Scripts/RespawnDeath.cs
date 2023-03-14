using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDeath : MonoBehaviour
{
    public ParticleSystem blood;
    public ParticleSystem stars;
    public AudioSource bgmusic;
    public AudioClip bloodsound;
    public Transform respawnpoint;
    public Transform deathaxis;
    public Transform playa;
    public GameObject Player;
    public GameObject checkpoint;
    public GameObject clone;
    public bool alive = false;
    public bool onetime = true;
    public GameObject MenuSettings;
    public CamBehavior cam;
    public GameObject Checkpoints;
    public bool iscp = true;
    // Start is called before the first frame update
    
    void Start()
    {
        bgmusic.Play();
        Checkpoints.GetComponent<GameObject>();
        alive = true;
        clone = Instantiate(Player, respawnpoint.position, Quaternion.identity);
        cam.target = clone.transform;
        cam.camon = true;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Settings.Instance.cp == false)
        {
            Debug.Log("sssssss");
            Checkpoints.SetActive(false);
        }
        if (alive)
        {
            if ((clone.transform.position.y <= deathaxis.position.y) || (clone.GetComponent<Movement>().enem))
            {
                if (onetime)
                {
                    StartCoroutine(destroyy());
                    onetime = false;

                }

            }


        }
        IEnumerator destroyy()
        {
            blood.transform.position = clone.transform.position;
            yield return new WaitForSeconds(0f);
            bgmusic.PlayOneShot(bloodsound);
            alive = false;
            cam.camon = false;
            Destroy(clone);
            blood.Play();
            Debug.Log("PLAYED");
            yield return new WaitForSeconds(1);
            clone = Instantiate(Player, respawnpoint.position, Quaternion.identity);
            cam.target = clone.transform; //wasnt there before I just added it
            alive = true;
            cam.camon = true;
            onetime = true;
        }
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
