using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiranha : MonoBehaviour
{
    [SerializeField]
    private GameObject fish;
    [SerializeField]
    private float dy;
    [SerializeField]
    private float time;
    [SerializeField]
    private float movetime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0){
            StartCoroutine(Movefish());
        }
    }

    IEnumerator Movefish(){
        movetime -= Time.deltaTime;
        if (movetime >= 0)
        {
            fish.transform.position += new Vector3(0, dy, 0);
        }else if(movetime <= 0){
            fish.transform.position += new Vector3(0, -1 * dy, 0);
        }
        if(movetime <= -1){
            movetime = 1;
        }
        yield return new WaitForFixedUpdate();

    }
}
