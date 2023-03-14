using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public string NA;
    public GameObject lockedbg;
    public int leveltoload;
    public Animator transition;
    public AudioSource bgmusic;
    public AudioClip woosh;

    // Start is called before the first frame update
    void Start()
    {
        //bgmusic.Play();
        if (Settings.Instance.levels[leveltoload - 1] == true)
        {
            lockedbg.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelected()
    {
        if (Settings.Instance.levels[leveltoload-1] == true)
        {
            StartCoroutine(LoadLevel());
        }
    }
    public void LoadScene()
    {

    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        Debug.Log("triggerddd");
        bgmusic.PlayOneShot(woosh);
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(NA);

    }

}
