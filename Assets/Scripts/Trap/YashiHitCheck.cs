using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YashiHitCheck : MonoBehaviour
{

    private bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHit)
            return;

        if (other.tag != "Player")
            return;

        isHit = true;

        var tarzan = other.gameObject;
        StartCoroutine(Hit(tarzan));
    }

    IEnumerator Hit(GameObject tarzan)
    {
        var tarzanrb = tarzan.GetComponentInParent<Rigidbody>();
        tarzanrb.useGravity = true;
        tarzanrb.AddForce(100, 100, 0);

        Sound.PlaySe("cool");

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(tarzan.GetComponentInParent<GameOverCheck>().GameOver());
    }
   
}
