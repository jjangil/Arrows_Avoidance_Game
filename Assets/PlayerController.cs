using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //플레이어 컨트롤러 내부에서만 사용하므로 private 접근 지정자 사용
    private const float fLeftWallXPos = -10.5f;   //왼쪽 벽 X 좌표값 상수
    private const float fRightWallXPos = 10.5f;   //오른쪽 벽 X 좌표값 상수
    private const float fGroundYPos = -3.6f;      //바닥 Y 좌표값 상수

    private float fXPosRangeLimit = 0.0f;   //X좌표값 범위 제한 변수
    private const float fMinXPos = -10.5f;  //X좌표의 최소값 상수
    private const float fMaxXPos = 10.5f;   //X좌표의 최대값 상수

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //방법 1. Mathf.Clamp() 메소드 사용
        
        // 키가 눌렀는지 검출하기 위해서는 Input 클래스의 GetKeyDown 메서드를 사용함
        // 이 메서드는 매개변수로 전달한 키가 눌리는 순간 true를 한 번 반환
        // GetKeyDown 메서드는 지금까지 사용하던 GetMouseButtonDown 메서드와 비슷하므로 쉽게 이해할 수 있을 것
        // 키를 누른 순간 : GetKeyDown()
        // 키를 누르다가 뗀 순간 : GetKeyUp()
        // 왼쪽 화살표 키가 눌렀을 때 -> GetKeyDown(KeyCode.LeftArrow)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
            // 값이 -3 이므로 왼쪽으로 '3' 만큼 움직인다.
            transform.Translate(-0.18f, 0, 0);
        }

        // 오른쪽 화살표 키가 눌렀을 때 -> GetKeyDown(KeyCode.RightArrow)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
            // 값이 3 이므로 오른쪽으로 '3' 만큼 움직인다.
            transform.Translate(0.18f, 0, 0);
        }

        //Clamp 메소드를 사용하면 매개변수로 지정된 최소 최대값으로 반환값이 제한되서 return 된다.
        //Clamp 메소드의 원형 : public static float Clamp(float value, float min, float max);
        //이를 응용하여 X좌표값이 X좌표의 최소, 최대값 범위를 벗어나지 않게 제한하여 fXPosRangeLimit에 저장한다.
        fXPosRangeLimit = Mathf.Clamp(transform.position.x, fMinXPos, fMaxXPos);

        //범위를 벗어나면 제한된 최소 최대값 위치로 초기화
        transform.position = new Vector2(fXPosRangeLimit, fGroundYPos);
        

        //방법 2. if조건문 사용

        /*
         * ArrowController 내부 화살이 화면 밖으로 나가면 자기 자신을 소멸시키는 메소드를 참조하여
         * 플레이어의 X좌표값이 지정된 값을 벗어나면 벽의 X좌표값으로 이동한다.
         *
        if (transform.position.x < fLeftWallXPos) //만약(플레이어의 X좌표값 < 왼쪽 벽 X좌표값)
        {
            transform.position = new Vector2(fLeftWallXPos, fGroundYPos); //왼쪽 벽 위치로 초기화
        }
        else if (transform.position.x > fRightWallXPos) //만약(플레이어의 X좌표값 > 오른쪽 벽 X좌표값)
        {
            transform.position = new Vector2(fRightWallXPos, fGroundYPos); //오른쪽 벽 위치로 초기화
        }

        // 키가 눌렀는지 검출하기 위해서는 Input 클래스의 GetKeyDown 메서드를 사용함
        // 이 메서드는 매개변수로 전달한 키가 눌리는 순간 true를 한 번 반환
        // GetKeyDown 메서드는 지금까지 사용하던 GetMouseButtonDown 메서드와 비슷하므로 쉽게 이해할 수 있을 것
        // 키를 누른 순간 : GetKeyDown()
        // 키를 누르다가 뗀 순간 : GetKeyUp()
        // 왼쪽 화살표 키가 눌렀을 때 -> GetKeyDown(KeyCode.LeftArrow)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
            // 값이 -3 이므로 왼쪽으로 '3' 만큼 움직인다.
            transform.Translate(-0.18f, 0, 0);
        }

        // 오른쪽 화살표 키가 눌렀을 때 -> GetKeyDown(KeyCode.RightArrow)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Translate 메서드 : 오브젝트를 현재 좌표에서 인수 값만큼 이동시키는 메서드
            // 값이 3 이므로 오른쪽으로 '3' 만큼 움직인다.
            transform.Translate(0.18f, 0, 0);
        }*/
    }

    public void f_RButtonDown()         // 오른쪽 버튼을 눌렀을 시 작동되는 메소드
    {
        transform.Translate(1, 0, 0);
    }

    public void f_LButtonDown()         // 왼쪽 버튼을 눌렀을 시 작동되는 메소드
    {
        transform.Translate(-1, 0, 0);
    }
}
