using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float MoveSpeed;
    public float Resistencia = 10;

    public Vector3 MoveDirection;
    public Transform hips;
    public Animator anim;

    public List<GameObject> LegList;

    Rigidbody rb;
    CapsuleCollider caps;

    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Resistencia)
        {
            caps.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            anim.SetBool("die", true);
        }
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        anim.SetFloat("InputX", v);

        if (v < 0)
        {
            for (int i = 0; i < LegList.Count; i++)
            {
                LegList[i].GetComponent<legFrontmov>().enabled = false;
            }
        }
        else if (v > 0)
        {
            for (int i = 0; i < LegList.Count; i++)
            {
                LegList[i].GetComponent<legFrontmov>().enabled = true;
            }
        }
        MoveDirection = (v * hips.TransformDirection(Vector3.forward)).normalized;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + MoveDirection * MoveSpeed * Time.deltaTime);
    }
}
