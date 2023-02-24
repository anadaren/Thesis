using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject office;
    public GameObject bigGuy;
    public GameObject head;
    public GameObject outside;
    public GameObject donutGuy;
    public GameObject donutCanvas;

    public AudioSource ticking;
    public AudioClip endingSound;

    public AudioSource music;

    // Changing Office Materials
    public Material Material1;

    // Changes Dialogue Sets
    public static int currentDialogueSet = 1;

    // Changes Background Color
    public Camera cam;
    public Color color1 = Color.blue;
    public Color color2 = Color.red;


    public 


    // Start is called before the first frame update
    void Start()
    {
        cam.backgroundColor = color1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void eventTwo()
    {
        // Switches Dialogue to Set 2
        currentDialogueSet = 2;

        // Switched sky color
        float t = Mathf.PingPong(Time.time, 5) / 5;
        cam.backgroundColor = Color.Lerp(color1, color2, t);
    }

    public void eventThree()
    {
        // Switches Dialogue to Set 3
        currentDialogueSet = 3;

        // Head
        GameObject fallingHead = Instantiate(head, new Vector3(-17, -10, -5), Quaternion.Euler(new Vector3(0, 0, 90)));
    }

    public void eventFour()
    {
        // Switches Dialogue to Set 4
        currentDialogueSet = 4;

        //switch office materials
        for (int i = 0; i < 9; i++)
        {
            GameObject child = office.transform.GetChild(i).gameObject;
            child.GetComponent<MeshRenderer>().material = Material1;
        }

        // Disables donut man
        donutGuy.SetActive(false);
        donutCanvas.SetActive(true);

        // Stops music
        music.Stop();
    }

    public void endingScene()
    {
        // Sets off end cutscene
        StartCoroutine(pauseForEffect());
        
        // Disable ticking
        ticking.Stop();

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
        outside.SetActive(true);
        office.GetComponent<Animator>().Play("OfficeAnim");
    }

    IEnumerator endCount()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Credits");
    }
}
