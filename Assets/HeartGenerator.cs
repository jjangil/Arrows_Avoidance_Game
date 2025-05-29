/*
 * HeartGenerator
 * 하트 프리팹을 생성하는 클래스
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGenerator : MonoBehaviour
{
    public GameObject gHeartPrefab;
    GameObject gMove = null;

    //따로 상수를 지정한 이유는 숫자에 의미를 부여해 가독성을 늘리기 위함이다.
    //private 접근제한 상수
    private const float fSpan = 2.0f;   //생성 빈도

    //private 접근제한 변수
    private float fDelta = 0.0f;    //랜덤 생성을 위한 경과 시간 변수
    private int nPositionX = 0;     //랜덤으로 산출된 X좌표 저장 변수

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fDelta += Time.deltaTime; //경과 시간 저장

        if (fDelta > fSpan) //경과 시간이 생성 빈도 상수보다 클 경우 랜덤위치 생성 실행
        {
            fDelta = 0; //생성 후 경과 시간 초기화
            gMove = Instantiate(gHeartPrefab);  //Instantiate 메소드를 통해 하트 프리팹을 생성(인스턴스) 한다.
            nPositionX = Random.Range(-6, 7);   //Random.Range 메소드로 매개변수로 주어진 정수내 범위에서 랜덤 정수를 반환한다.
            gMove.transform.position = new Vector3(nPositionX, 7, 0); //하트 프리팹의 위치를 랜덤 위치(nPositionX)로 이동한다. 
        }
    }
}

