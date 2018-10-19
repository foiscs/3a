using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legBackmov : MonoBehaviour
{
    public HingeJoint legHingeJoint;
    public HingeJoint HingeJoint;
    public Transform objectRotation;

    public bool invert;

    private void OnEnable()
    {
        HingeJoint.useSpring = true;
    }
    private void OnDisable()
    {
        JointSpring js = HingeJoint.spring;
        js.targetPosition = 0;
        HingeJoint.useSpring = false;
    }
    void Update()
    {
        JointSpring Pjs = legHingeJoint.spring;
        JointSpring js = HingeJoint.spring;
        js.targetPosition = objectRotation.localEulerAngles.x;
        if (js.targetPosition > 180) 
        {
            js.targetPosition = js.targetPosition - 360;
        }
        //js.targetPosition = Mathf.Clamp(js.targetPosition, HingeJoint.limits.min + 5, HingeJoint.limits.max - 5);
        if (invert)
        {
            js.targetPosition = js.targetPosition * -1;
        }
        Pjs.targetPosition = Mathf.Clamp(js.targetPosition, -15, 15);
        //js.targetPosition = js.targetPosition;

        legHingeJoint.spring = Pjs;
        HingeJoint.spring = js;
    }
}
