using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legFrontmov : MonoBehaviour
{

    public HingeJoint hj;
    public Transform objetivo;
    public bool invertido;


    void Start()
    {

    }
    private void OnEnable()
    {
        if (this.transform.GetChild(0).GetComponent<legBackmov>())
            this.transform.GetChild(0).GetComponent<legBackmov>().enabled = false;
    }
    private void OnDisable()
    {
        JointSpring js = hj.spring;
        js.targetPosition = 0;
        Debug.Log("in");
        if (this.transform.GetChild(0).GetComponent<legBackmov>())
            this.transform.GetChild(0).GetComponent<legBackmov>().enabled = true;
    }
    void Update()
    {
        JointSpring js = hj.spring;
        js.targetPosition = objetivo.localEulerAngles.x;
        if (js.targetPosition > 180)
            js.targetPosition = js.targetPosition - 360;
        js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);
        if (invertido)
        {
            js.targetPosition = js.targetPosition * -1;
        }
        hj.spring = js;
    }
}
