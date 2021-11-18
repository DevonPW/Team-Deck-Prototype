using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Slide")) {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        if (Input.GetButtonUp("Slide")) {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
