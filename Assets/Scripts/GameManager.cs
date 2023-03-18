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
    public Animator bossManAnim;

    public GameObject headUI;
    public GameObject tv;
    public GameObject wallWriting;
    public GameObject wallWriting2;
    public GameObject wallWriting3;
    public GameObject wallWriting4;
    public GameObject wallStuff;

    // Non-Npc Sounds
    public AudioSource ticking;
    public AudioSource music;
    public AudioClip endingSound;

    // Changing Office Materials
    public Material Material1;

    // Changes Dialogue Sets
    public static int currentDialogueSet = 1;

    // Changes Background Color
    public Camera cam;
    public Color color1;
    public Color color2;


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
        //float t = Mathf.PingPong(Time.time, 5) / 5;
        cam.backgroundColor = Color.Lerp(color1, color2, 5);

        // Sets TV to active
        tv.SetActive(true);
    }

    public void eventThree()
    {
        // Switches Dialogue to Set 3
        currentDialogueSet = 3;

        // Head
        GameObject fallingHead = Instantiate(head, new Vector3(-17, -10, -5), Quaternion.Euler(new Vector3(0, 0, 90)));
        headUI.SetActive(true);

        // Takes TV away
        tv.SetActive(false);


        // Wall Writing
        wallWriting.SetActive(true);
    }

    public void eventFour()
    {
        // Switches Dialogue to Set 4
        currentDialogueSet = 4;

        // Switches office materials to dark mode
        for (int i = 0; i < 9; i++)
        {
            GameObject child = office.transform.GetChild(i).gameObject;
            child.GetComponent<MeshRenderer>().material = Material1;
        }

        // Wall Writing
        wallWriting2.SetActive(true);
        wallWriting3.SetActive(true);

        // Disables donut man
        donutGuy.SetActive(false);
        donutCanvas.SetActive(true);

        // Switches BossMan animation
        bossManAnim.Play("Panic");

        // Stops music
        music.Stop();
    }

    public void endingScene()
    {

        // Wall Writing
        wallWriting4.SetActive(true);

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
        wallStuff.SetActive(false);
        office.GetComponent<Animator>().Play("OfficeAnim");
    }

    IEnumerator endCount()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Credits");
    }
}
