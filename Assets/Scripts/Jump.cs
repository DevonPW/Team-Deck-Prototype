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

    [SerializeField] AudioSource audioSrc;

    //[SerializeField] AudioSource audioSrc;

    Collider2D pCollider;

    float buttonPressTime; //the time the button started being pressed

    bool isGrounded = true;

    float Width, Height;

    // Start is called before the first frame update
    void Start()
    {
        pCollider = gameObject.GetComponent<Collider2D>();

        Width = pCollider.bounds.size.x;
        Height = pCollider.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true) {//initial jump force
            body.AddForce(new Vector2(0, 1) * initialJumpStrength, ForceMode2D.Impulse);

            buttonPressTime = Time.time;

            audioSrc.Play();

            //isGrounded = false;
        }
        else if (Input.GetButton("Jump")) {//continued hold jump force
            if (Time.time - buttonPressTime > maxTapDuration && Time.time - buttonPressTime <= maxHoldDuration) {
                body.AddForce(new Vector2(0, 1) * holdJumpStrength * Time.deltaTime, ForceMode2D.Force);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trigger Exit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");

        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Platform") {
            if (transform.position.x + Width <= collision.gameObject.transform.position.x) {
                Debug.Log("Side Hit");
            }
            else {
                isGrounded = true;
            }
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");

        if (collision.gameObject.tag == "Platform") {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }

}
