using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheese : MonoBehaviour
{
    public float boostForce = 1;

    public bool permanent = false;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D pBody = collider.gameObject.GetComponent<Rigidbody2D>();

        //pBody.AddForce(Vector2.right * boostForce,ForceMode2D.Impulse);

        pBody.velocity = new Vector2(pBody.velocity.x + boostForce, pBody.velocity.y);

        if (permanent == false){
            Destroy(gameObject);
         }
    }
}
