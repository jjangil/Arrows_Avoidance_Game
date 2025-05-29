using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    public GameObject gFirePrefab;
    GameObject gMove = null;

    float fSpan = 1.1f;
    float fDelta = 0.0f;

    int nPositiionX = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fDelta += Time.deltaTime;

        if (fDelta > fSpan)
        {
            fDelta = 0;
            gMove = Instantiate(gFirePrefab);
            nPositiionX = Random.Range(-6, 7);
            gMove.transform.position = new Vector3(nPositiionX, 7, 0);
        }
    }
}
