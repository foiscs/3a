using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public enum HAND
    {
        LEFT,
        RIGHT
    }
    public HAND handSide;
    public GameObject handCenter;
    public float Distance;

    private GameObject MainCamera;
    private Rigidbody Rigid;

    private void Start()
    {
        MainCamera = Camera.main.gameObject;
        Rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (handSide == HAND.LEFT)
        {
            if (Input.GetMouseButton(0))
            {
                Rigid.velocity = MainCamera.transform.forward;
                //transform.localPosition = Vector3.MoveTowards(transform.position, handCenter.transform.localPosition + (MainCamera.transform.forward * Distance), 5 * Time.deltaTime);//MainCamera.transform.forward * 5;
                //Debug.DrawRay(transform.position, handCenter.transform.localPosition + (MainCamera.transform.forward * Distance), Color.red);
            }
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                Rigid.velocity = MainCamera.transform.forward;
                //transform.position = Vector3.MoveTowards(transform.position, handCenter.transform.position + (MainCamera.transform.forward * Distance), 5 * Time.deltaTime);//MainCamera.transform.forward * 5;
                //Debug.DrawRay(transform.position, handCenter.transform.position + (MainCamera.transform.forward * Distance), Color.red);
            }
        }

    }
}
