using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public int iLevelToLoad;
    public bool levelUnlocked;
    public int currlevel;
    public string sLevelToLoad;
    public Movement Movement; 
    public bool uitll = false;
    public Animator transition;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ll");
            Settings.Instance.levels[iLevelToLoad-1] = true;
            LoadScene();
        }


    }
    void LoadScene()
    {
        StartCoroutine(LoadLevel());
        
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("LevelSelect");

    }
}
