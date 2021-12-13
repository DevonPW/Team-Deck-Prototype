using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    [SerializeField] float playerMoveSpeed = 9;

    [SerializeField] float slowDownSpeed = 3;

    [SerializeField] PlayerMoveAnim moveAnim;

    [SerializeField]
    Animator animator;


    public Player player;

    [SerializeField] float maxMoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x <= maxMoveSpeed) {
            body.AddForce(Vector2.right * playerMoveSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        //body.velocity = new Vector2(playerMoveSpeed, body.velocity.y);
        //transform.Translate(player.moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x >= 19.18f * 4) {//setting world space position
            transform.position = new Vector3(transform.position.x - (19.18f * 4), transform.position.y);
        }

        //moveAnim.animLength = 100 / body.velocity.x;
        animator.SetFloat("Speed", body.velocity.x / 5);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Sticky") {
            Debug.Log("Sticky");
            body.AddForce(Vector2.left * slowDownSpeed * Time.deltaTime, ForceMode2D.Force);
        }
    }


}
