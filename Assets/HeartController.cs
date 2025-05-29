/* 
 * HeartController
 * 플레이어가 하트 아이템을 먹으면 Hp가 증가하는 기능을 하는 클래스
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    GameObject gPlayer = null;

    Vector2 vHeartPosition = Vector2.zero;
    Vector2 vPlayerPosition = Vector2.zero;
    Vector2 vDir = Vector2.zero;

    //따로 상수를 지정한 이유는 숫자에 의미를 부여해 가독성을 늘리기 위함이다.
    //private 접근제한 상수
    private const float fHeartRadius = 0.3f;    //하트 아이템 원의 크기 상수
    private const float fPlayerRadius = 1.0f;   //플레이어 원의 크기 상수

    //private 접근제한 변수
    private float fDistance = 0.0f; //물체간의 거리 변수

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;       //시스템 성능별 편차 방지를 위해 60프레임 고정

        gPlayer = GameObject.Find("player");    //충돌 판정을 위해 플레이어 오브젝트를 찾아 저장
    }

    // Update is called once per frame
    void Update()
    {
        // Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
        //    Y 좌표에 -0.1f를 지정하면 오브젝트를 조금씩 위에서 아래로 움직인다
        //    프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);

        /*
         * 화면 밖으로 나온 화살 소멸시키기
         * 화살을 내버려 두면 화면 밖으로 나가게 되고, 눈에 보이지는 않지만 계속 떨어짐
         * 화살이 보이지 않는 곳에서 계속 떨어지면 컴퓨터 역시 계산을 해야하므로 메모리 낭비
         * 메모리가 낭비되지 않도록 화살이 화면 밖으로 나가면 오브젝트를 소멸시켜야 함
         * Destroy 메서드 : 매개변수로 전달한 오브젝트를 삭제
         * 매개변수로 자신(화살 오브젝트)을 가르키는 gameObject 변수를 전달하므로 화살이
         * 화면 밖으로 나가을 때 자기 자신을 소멸시킴
         */
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        vHeartPosition = transform.position;            //하트 위치 저장
        vPlayerPosition = gPlayer.transform.position;   //플레이어 위치 저장

        vDir = vHeartPosition - vPlayerPosition;

        fDistance = vDir.magnitude; //magnitude 메소드를 사용하여 거리에 반환된 벡터길이 저장

        if (fDistance < fHeartRadius + fPlayerRadius) //물체 두 개의 원 크기 합보다 거리가 작으면 충돌
        {
            GameObject gDir = GameObject.Find("GameDirector"); //선언과 동시에 초기화

            gDir.GetComponent<GameDirector>().f_HpBarIncrease(); //GameDirector 내 Hp증가 메소드 호출

            Destroy(gameObject);
        }
    }
}
