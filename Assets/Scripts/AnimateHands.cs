using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    public Animator handAnimator;

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks input of trigger button
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        // animates trigger press into pinch animation
        handAnimator.SetFloat("Trigger", triggerValue);

        // checks input for grip button
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        // animates grip press into grip animation
        handAnimator.SetFloat("Grip", gripValue);
    }
}
