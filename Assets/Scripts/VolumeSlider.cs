using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public Transform knob;
    private Vector3 targetPos;


    void Start()
    {
        targetPos = knob.position;
    }


    void Update()
    {
        knob.position = Vector3.Lerp(knob.position,targetPos,Time.deltaTime * 7);
    }

    void OnTouchStay(Vector3 point)
    {
        targetPos = new Vector3(point.x,targetPos.y,targetPos.z);
    }
}
