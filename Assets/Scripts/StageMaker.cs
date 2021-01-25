using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMaker : MonoBehaviour
{
    public GameObject stagePrefab;
    public Vector3 startPosition;
    public float distanceZ;

    private int makedCount;
    [SerializeField]
    private GameObject lastStage;
    private bool makingStage;

    // Start is called before the first frame update
    void Start()
    {
        Save.ReSet();
    }

    // Update is called once per frame
    void Update()
    {
        if(!makingStage)
            if (Save.GollMeter % 100 == 0)
                MakeStage();
    }

    void MakeStage()
    {
        makingStage = true;
        makedCount++;
        GameObject.Destroy(lastStage);
        lastStage = Instantiate(stagePrefab);
        lastStage.transform.position = startPosition;
        lastStage.transform.position += new Vector3(0, 0, distanceZ * makedCount);

        StartCoroutine(MakedEndWait());
    }

    IEnumerator MakedEndWait()
    {
        var m = Save.GollMeter;
        yield return new WaitUntil(() => m + 50 == Save.GollMeter);
        makingStage = false;
    }
}
