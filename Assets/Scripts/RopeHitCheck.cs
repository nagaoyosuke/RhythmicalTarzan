using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeHitCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject Tarzan;
    [SerializeField]
    private PlayerStatus status;
    [SerializeField]
    private HingeJoint hingeJoint;
    [SerializeField]
    private TuruShaker turuShaker;

    private Queue<GameObject> LastRope = new Queue<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Rope")
            return;
        if (status.state != PlayerStatus.State.JUMP)
            return;

        status.state = PlayerStatus.State.ROPE;

        if(turuShaker == null)
        {
            print("turumanager is null");
            turuShaker = GameObject.FindWithTag("Manager").GetComponent<TuruShaker>();
        }

        var p = other.transform.parent.gameObject;

        turuShaker.ChangeTarget(p.GetComponentInChildren<Sakittyo>().gameObject);

        LastRope.Enqueue(p);
        //hingeJoint.connectedBody = other.GetComponent<Rigidbody>();
        Tarzan.transform.parent = other.transform;
        SetLastRope(p, "DontRope");
        StartCoroutine(RopeWait());
    }

    void SetLastRope(GameObject Rope, string tag_neme)
    {

        if (Rope == null)
            Rope = LastRope.Dequeue();

        foreach(SphereCollider g in Rope.GetComponentsInChildren<SphereCollider>())
        {
            g.gameObject.tag = tag_neme;
        }
    }

    IEnumerator RopeWait()
    {
        yield return new WaitUntil(() => status.state == PlayerStatus.State.JUMP);
        //hingeJoint.connectedBody = null;
        yield return new WaitUntil(() => status.state == PlayerStatus.State.ROPE);
        SetLastRope(null, "Rope");
    }
}
