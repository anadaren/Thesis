using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject office;
    public GameObject bigGuy;

    public AudioSource ticking;
    public AudioClip endingSound;

    public AudioSource music;

    public 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void eventTwo()
    {

    }

    public void eventThree()
    {

    }

    public void eventFour()
    {
        
    }

    public void endingScene()
    {
        // Sets off end cutscene
        StartCoroutine(pauseForEffect());
        
        // Disable ticking
        ticking.Stop();
        // FIXME: Put this line in event 4 at some point
        music.Stop();
        // Enable ending sound effects
        ticking.clip = endingSound;
        ticking.Play();
    }

    IEnumerator pauseForEffect()
    {
        yield return new WaitForSeconds(6);

        //Change scene at the end of the cutscene
        StartCoroutine(endCount());

        //Spawns big guy and animates office walls
        GameObject bigBoss = Instantiate(bigGuy, new Vector3(0,2,-60), Quaternion.Euler(new Vector3(0,90,0)));
        office.GetComponent<Animator>().Play("OfficeAnim");
    }

    IEnumerator endCount()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("Credits");
    }
}
