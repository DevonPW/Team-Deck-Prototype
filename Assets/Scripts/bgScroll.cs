using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-player.scrollSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -19.18) {//setting world space position
            transform.position = new Vector3(0, 0);
        }
    }
}
