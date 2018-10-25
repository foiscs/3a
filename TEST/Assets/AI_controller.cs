using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_controller : MonoBehaviour
{
    public float MoveSpeed;
    public float Resistencia = 10;

    public Vector3 MoveDirection;
    public Transform hips;
    public Animator anim;

    public List<GameObject> LegList;

    Rigidbody rb;
    CapsuleCollider caps;

    private int AIType;
    //1 -> 30%, 5초간 걸어가고 2초간 멈춤 반복, 멈춰있을 때 포즈취함
    //2 -> 30%, 7초동안 앉았다 일어서고 4초간 멈춤 반복, 멈춰있을 때 360도를 천천히 돔
    //3 -> 40%, 2가지 행동을 바꿔가며 함
    public int walkOn;
    private bool walk;


    private void Start()
    {
        int num = Random.Range(0, 10);
        if (num < 3)
            AIType = 1;
        else if (num < 6)
            AIType = 2;
        else
            AIType = 3;

        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();

        StartPattern();
	}

    private void Update()
    {
        MoveDirection = (walkOn * hips.TransformDirection(Vector3.forward)).normalized;
        anim.SetFloat("InputX", walkOn);
        foreach (GameObject obj in LegList)
        {
            obj.GetComponent<legFrontmov>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + MoveDirection * MoveSpeed * Time.deltaTime);
    }


    void StartPattern()
    {
        if (AIType == 1)
        {
            StartCoroutine("AI_Pattern_1");
        }
        else if (AIType == 2)
        {
            StartCoroutine("AI_Pattern_2");
        }
        else
        {
            int num = Random.Range(0, 2);
            if (num == 0)
                StartCoroutine("AI_Pattern_1");
            else
                StartCoroutine("AI_Pattern_2");
        }
    }



    IEnumerator AI_Pattern_1()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), -90f);
            walkOn = 1;
            yield return new WaitForSeconds(5f);
            walkOn = 0;
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator AI_Pattern_2()
    {
        yield return null;
    }
}
