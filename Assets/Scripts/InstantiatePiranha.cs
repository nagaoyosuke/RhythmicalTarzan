using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePiranha : MonoBehaviour
{
    [SerializeField]
    private GameObject fish;
    [SerializeField]
    private int fishcount;

    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(-2.0f, 3.0f);
        z = Random.Range(0.0f, 100.0f);
        if (fishcount > 0)
        {
            Instantiate(fish, new Vector3(x, -2.0f, z), Quaternion.identity);
            fishcount--;
        }

    }
}
