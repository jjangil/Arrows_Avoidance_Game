using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�÷��̾� ��Ʈ�ѷ� ���ο����� ����ϹǷ� private ���� ������ ���
    private const float fLeftWallXPos = -10.5f;   //���� �� X ��ǥ�� ���
    private const float fRightWallXPos = 10.5f;   //������ �� X ��ǥ�� ���
    private const float fGroundYPos = -3.6f;      //�ٴ� Y ��ǥ�� ���

    private float fXPosRangeLimit = 0.0f;   //X��ǥ�� ���� ���� ����
    private const float fMinXPos = -10.5f;  //X��ǥ�� �ּҰ� ���
    private const float fMaxXPos = 10.5f;   //X��ǥ�� �ִ밪 ���

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //��� 1. Mathf.Clamp() �޼ҵ� ���
        
        // Ű�� �������� �����ϱ� ���ؼ��� Input Ŭ������ GetKeyDown �޼��带 �����
        // �� �޼���� �Ű������� ������ Ű�� ������ ���� true�� �� �� ��ȯ
        // GetKeyDown �޼���� ���ݱ��� ����ϴ� GetMouseButtonDown �޼���� ����ϹǷ� ���� ������ �� ���� ��
        // Ű�� ���� ���� : GetKeyDown()
        // Ű�� �����ٰ� �� ���� : GetKeyUp()
        // ���� ȭ��ǥ Ű�� ������ �� -> GetKeyDown(KeyCode.LeftArrow)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
            // ���� -3 �̹Ƿ� �������� '3' ��ŭ �����δ�.
            transform.Translate(-0.18f, 0, 0);
        }

        // ������ ȭ��ǥ Ű�� ������ �� -> GetKeyDown(KeyCode.RightArrow)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
            // ���� 3 �̹Ƿ� ���������� '3' ��ŭ �����δ�.
            transform.Translate(0.18f, 0, 0);
        }

        //Clamp �޼ҵ带 ����ϸ� �Ű������� ������ �ּ� �ִ밪���� ��ȯ���� ���ѵǼ� return �ȴ�.
        //Clamp �޼ҵ��� ���� : public static float Clamp(float value, float min, float max);
        //�̸� �����Ͽ� X��ǥ���� X��ǥ�� �ּ�, �ִ밪 ������ ����� �ʰ� �����Ͽ� fXPosRangeLimit�� �����Ѵ�.
        fXPosRangeLimit = Mathf.Clamp(transform.position.x, fMinXPos, fMaxXPos);

        //������ ����� ���ѵ� �ּ� �ִ밪 ��ġ�� �ʱ�ȭ
        transform.position = new Vector2(fXPosRangeLimit, fGroundYPos);
        

        //��� 2. if���ǹ� ���

        /*
         * ArrowController ���� ȭ���� ȭ�� ������ ������ �ڱ� �ڽ��� �Ҹ��Ű�� �޼ҵ带 �����Ͽ�
         * �÷��̾��� X��ǥ���� ������ ���� ����� ���� X��ǥ������ �̵��Ѵ�.
         *
        if (transform.position.x < fLeftWallXPos) //����(�÷��̾��� X��ǥ�� < ���� �� X��ǥ��)
        {
            transform.position = new Vector2(fLeftWallXPos, fGroundYPos); //���� �� ��ġ�� �ʱ�ȭ
        }
        else if (transform.position.x > fRightWallXPos) //����(�÷��̾��� X��ǥ�� > ������ �� X��ǥ��)
        {
            transform.position = new Vector2(fRightWallXPos, fGroundYPos); //������ �� ��ġ�� �ʱ�ȭ
        }

        // Ű�� �������� �����ϱ� ���ؼ��� Input Ŭ������ GetKeyDown �޼��带 �����
        // �� �޼���� �Ű������� ������ Ű�� ������ ���� true�� �� �� ��ȯ
        // GetKeyDown �޼���� ���ݱ��� ����ϴ� GetMouseButtonDown �޼���� ����ϹǷ� ���� ������ �� ���� ��
        // Ű�� ���� ���� : GetKeyDown()
        // Ű�� �����ٰ� �� ���� : GetKeyUp()
        // ���� ȭ��ǥ Ű�� ������ �� -> GetKeyDown(KeyCode.LeftArrow)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
            // ���� -3 �̹Ƿ� �������� '3' ��ŭ �����δ�.
            transform.Translate(-0.18f, 0, 0);
        }

        // ������ ȭ��ǥ Ű�� ������ �� -> GetKeyDown(KeyCode.RightArrow)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
            // ���� 3 �̹Ƿ� ���������� '3' ��ŭ �����δ�.
            transform.Translate(0.18f, 0, 0);
        }*/
    }

    public void f_RButtonDown()         // ������ ��ư�� ������ �� �۵��Ǵ� �޼ҵ�
    {
        transform.Translate(1, 0, 0);
    }

    public void f_LButtonDown()         // ���� ��ư�� ������ �� �۵��Ǵ� �޼ҵ�
    {
        transform.Translate(-1, 0, 0);
    }
}
