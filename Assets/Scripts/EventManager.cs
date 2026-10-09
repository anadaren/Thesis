using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    [Header("Office Set")]
    public GameObject office;
    public GameObject bigGuy;
    public GameObject head;
    public GameObject outside;
    public GameObject donutGuy;
    public GameObject donutCanvas;
    public Animator bossManAnim;

    [Header("Event Objects")]
    public GameObject headUI;
    public GameObject tv;
    public GameObject wallWriting1;
    public GameObject wallWriting2;
    public GameObject wallWriting3;
    public GameObject wallWriting4;
    public GameObject wallStuff;

    [Header("Audio")]
    // Non-Npc Sounds
    public AudioSource ticking;
    public AudioSource music;
    public AudioClip endingSound;


    [Header("Materials")]
    // Changing Office Materials
    public Material Material1;

    // Changes Background Color
    public Camera cam;
    public Color color1;
    public Color color2;


    // Changes Dialogue Sets
    public static int currentDialogueSet = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cam.backgroundColor = color1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EventTwo()
    {
        // Switches Dialogue to Set 2
        currentDialogueSet = 2;

        // Switched sky color
        // TODO: transition isn't smooth
        cam.backgroundColor = Color.Lerp(color1, color2, 50);

        // Sets TV to active
        tv.SetActive(true);
    }

    public void EventThree()
    {
        // Switches Dialogue to Set 3
        currentDialogueSet = 3;

        // Head
        GameObject fallingHead = Instantiate(head, new Vector3(-17, -10, -5), Quaternion.Euler(new Vector3(0, 0, 90)));
        headUI.SetActive(true);

        // Takes TV away
        tv.SetActive(false);

        // Wall Writing
        wallWriting1.SetActive(true);
    }

    public void EventFour()
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

    public void EndingScene()
    {

        // Wall Writing
        wallWriting4.SetActive(true);

        // Sets off end cutscene
        StartCoroutine(PauseForEffect());
        
        // Disable ticking
        ticking.Stop();

        // Enable ending sound effects
        ticking.clip = endingSound;
        ticking.Play();
    }

    IEnumerator PauseForEffect()
    {
        yield return new WaitForSeconds(6);

        //Change scene at the end of the cutscene
        StartCoroutine(EndCount());

        //Spawns big guy and animates office walls
        GameObject bigBoss = Instantiate(bigGuy, new Vector3(0,2,-60), Quaternion.Euler(new Vector3(0,90,0)));
        outside.SetActive(true);
        wallStuff.SetActive(false);
        office.GetComponent<Animator>().Play("OfficeAnim");
    }

    IEnumerator EndCount()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("Credits");
    }
}
