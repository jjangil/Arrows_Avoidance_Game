/*
 * HeartGenerator
 * ��Ʈ �������� �����ϴ� Ŭ����
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGenerator : MonoBehaviour
{
    public GameObject gHeartPrefab;
    GameObject gMove = null;

    //���� ����� ������ ������ ���ڿ� �ǹ̸� �ο��� �������� �ø��� �����̴�.
    //private �������� ���
    private const float fSpan = 2.0f;   //���� ��

    //private �������� ����
    private float fDelta = 0.0f;    //���� ������ ���� ��� �ð� ����
    private int nPositionX = 0;     //�������� ����� X��ǥ ���� ����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fDelta += Time.deltaTime; //��� �ð� ����

        if (fDelta > fSpan) //��� �ð��� ���� �� ������� Ŭ ��� ������ġ ���� ����
        {
            fDelta = 0; //���� �� ��� �ð� �ʱ�ȭ
            gMove = Instantiate(gHeartPrefab);  //Instantiate �޼ҵ带 ���� ��Ʈ �������� ����(�ν��Ͻ�) �Ѵ�.
            nPositionX = Random.Range(-6, 7);   //Random.Range �޼ҵ�� �Ű������� �־��� ������ �������� ���� ������ ��ȯ�Ѵ�.
            gMove.transform.position = new Vector3(nPositionX, 7, 0); //��Ʈ �������� ��ġ�� ���� ��ġ(nPositionX)�� �̵��Ѵ�. 
        }
    }
}

