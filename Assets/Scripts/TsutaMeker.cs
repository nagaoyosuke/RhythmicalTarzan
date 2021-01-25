using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsutaMeker : MonoBehaviour
{
    public GameObject tsutaPrefab;
    public Vector3 startPosition;
    public float distanceZ;

    private int makedCount;
    private Queue<GameObject> lastTsutas = new Queue<GameObject>();
    private bool makingTsuta;

    [SerializeField]
    private GameObject[] StartMakedTsutas;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in StartMakedTsutas)
        {
            lastTsutas.Enqueue(g);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!makingTsuta)
            if (Save.GollMeter % 10 == 0)
                if(Save.GollMeter > 20)
                    MakeTsuta();
    }

    void MakeTsuta()
    {
        makingTsuta = true;
        makedCount++;
        GameObject.Destroy(lastTsutas.Dequeue());
        var lastTsuta = Instantiate(tsutaPrefab);
        lastTsuta.transform.position = startPosition;
        print((float)makedCount * 0.1f);
        //lastTsuta.transform.position += new Vector3(0, 0, (distanceZ * makedCount) + ((float)makedCount * makedCount * 0.05f));
        lastTsuta.transform.position += new Vector3(0, 0, (distanceZ * makedCount));

        lastTsutas.Enqueue(lastTsuta);

        StartCoroutine(MakedEndWait());
    }

    IEnumerator MakedEndWait()
    {
        var m = Save.GollMeter;
        yield return new WaitUntil(() => m + 5 == Save.GollMeter);
        makingTsuta = false;
    }
}
