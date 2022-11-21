using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public Transform knob;
    private Vector2 targetPos;


    void Start()
    {
        targetPos = knob.position;
    }


    void Update()
    {
        knob.position = Vector2.Lerp(knob.position,targetPos,Time.deltaTime * 7);
    }

    void OnTouchStay(Vector2 point)
    {
        targetPos = new Vector2(targetPos.x,point.y);
    }
}
