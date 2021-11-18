using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Rigidbody2D body;

    public float moveSpeed;

    public float maxMoveSpeed;

    float startPos = -10;

    public SpriteRenderer spriteRendr;

    public Sprite normal;
    public Sprite caught;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x <= maxMoveSpeed) {
            body.AddForce(Vector2.right * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        }

        if (transform.position.x >= 57.54f) {//setting world space position
            transform.position = new Vector3(0, transform.position.y);
        }
    }

    public void caughtSprite()
    {
        spriteRendr.sprite = caught;
    }

    public void normalSprite()
    {
        spriteRendr.sprite = normal;
    }
}
