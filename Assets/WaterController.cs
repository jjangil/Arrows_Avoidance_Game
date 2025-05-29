using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    GameObject gPlayer = null;

    Vector2 vWaterPosition = Vector2.zero;
    Vector2 vPlayerPosition = Vector2.zero;
    Vector2 vDir = Vector2.zero;

    //상수
    private const float fWaterRadius = 0.5f;
    private const float fPlayerRadius = 1.0f;

    //변수
    private float fDistance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        gPlayer = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
        //    Y 좌표에 -0.1f를 지정하면 오브젝트를 조금씩 위에서 아래로 움직인다
        //    프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나온 화살 소멸시키기
        //   화살을 내버려 두면 화면 밖으로 나가게 되고, 눈에 보이지는 않지만 계속 떨어짐
        //   화살이 보이지 않는 곳에서 계속 떨어지면 컴퓨터 역시 계산을 해야하므로 메모리 낭비
        //   메모리가 낭비되지 않도록 화살이 화면 밖으로 나가면 오브젝트를 소멸시켜야 함
        // Destroy 메서드 : 매개변수로 전달한 오브젝트를 삭제
        //   매개변수로 자신(화살 오브젝트)을 가르키는 gameObject 변수를 전달하므로 화살이
        //   화면 밖으로 나가을 때 자기 자신을 소멸시킴
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        vWaterPosition = transform.position;
        vPlayerPosition = gPlayer.transform.position;

        vDir = vWaterPosition - vPlayerPosition;

        fDistance = vDir.magnitude;

        if (fDistance < fWaterRadius + fPlayerRadius)
        {
            GameObject gDir = GameObject.Find("GameDirector");

            gDir.GetComponent<GameDirector>().f_HpBarWaterDecrease();   // 찾아온 gDir을 통해 f_HpBarReduction 메소드 가져오기

            Destroy(gameObject);
        }
    }
}
