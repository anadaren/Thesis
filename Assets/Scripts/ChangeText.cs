using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text tenTxt;
    public Text sevenTxt;
    public Text fiveTxt;
    public Text twoTxt;

    Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // As time goes down, NPC responses change
        
        if(CountdownTimer.currentTime >= 450)
        {
            // Text is set to option 1
            displayText.text = tenTxt.text;
        } else if(CountdownTimer.currentTime >= 300)
        {
            // Text is set to option 2
            displayText.text = sevenTxt.text;
        } else if(CountdownTimer.currentTime >= 150)
        {
            // Text is set to option 3
            displayText.text = fiveTxt.text;
        } else
        {
            // Text is set to option 4
            displayText.text = twoTxt.text;
        }
    }
}
