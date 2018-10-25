using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private DeathRunManager manager;
    private Rigidbody rb;

    public bool touch = false;
    private void Start()
    {
        manager = gameObject.transform.parent.GetComponent<DeathRunManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("lag") && manager.isPlaying && !touch)
        {
            touch = true;
            StartCoroutine(Down());
        }
    }
    IEnumerator Down()
    {
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
    }
}
