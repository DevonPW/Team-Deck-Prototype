using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    [SerializeField] float playerMoveSpeed = 9;

    public Player player;

    [SerializeField] float maxMoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x <= maxMoveSpeed) {
            body.AddForce(Vector2.right * playerMoveSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        //body.velocity = new Vector2(playerMoveSpeed, body.velocity.y);
        //transform.Translate(player.moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x >= 57.54f) {//setting world space position
            transform.position = new Vector3(0, transform.position.y);
        }
    }
}
