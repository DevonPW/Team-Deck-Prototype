using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnim : MonoBehaviour
{
    [SerializeField]
    Vector3 minScale, maxScale;

    [SerializeField]
    AnimationCurve curve;

    public float animLength;

    float startTime = 0;

    float timePercent = 1;

    sbyte invert = -1;// 1 = play forwards, -1 = play backwards

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timePercent >= 1) {
            invert *= -1;//switch sign
            startTime = Time.time;
        }

        timePercent = (Time.time - startTime) / animLength;

        if(invert == 1) {
            transform.localScale = Vector3.Lerp(minScale, maxScale, curve.Evaluate(timePercent));
        }
        else {//play animation backwards
            transform.localScale = Vector3.Lerp(minScale, maxScale, curve.Evaluate(1 - timePercent));
        }


    }
}
