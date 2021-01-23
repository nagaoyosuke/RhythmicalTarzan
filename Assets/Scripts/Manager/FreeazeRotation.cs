using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeazeRotation : MonoBehaviour
{

    void Update()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
