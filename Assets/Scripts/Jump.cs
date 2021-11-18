using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float initialJumpStrength = 1;

    [SerializeField] float holdJumpStrength = 1;

    [SerializeField] Rigidbody2D body;

    [SerializeField] float maxTapDuration = 0.07f; //the largest amount of time the button can be pressed for before it begins to be 'held'. About 1/14th of a second (4 frames at 60fps).

    [SerializeField] float maxHoldDuration = 1.0f;//the  largest amount of time the button can be held for it to increase jump height

    float buttonPressTime; //the time the button started being pressed

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {//initial jump force
            body.AddForce(new Vector2(0, 1) * initialJumpStrength, ForceMode2D.Impulse);

            buttonPressTime = Time.time;
        }
        else if (Input.GetButton("Jump")) {//continued hold jump force
            if (Time.time - buttonPressTime > maxTapDuration && Time.time - buttonPressTime <= maxHoldDuration) {
                body.AddForce(new Vector2(0, 1) * holdJumpStrength * Time.deltaTime, ForceMode2D.Force);
            }
        }
    }
        
}
