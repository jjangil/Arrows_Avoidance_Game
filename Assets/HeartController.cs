/* 
 * HeartController
 * �÷��̾ ��Ʈ �������� ������ Hp�� �����ϴ� ����� �ϴ� Ŭ����
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

    //���� ����� ������ ������ ���ڿ� �ǹ̸� �ο��� �������� �ø��� �����̴�.
    //private �������� ���
    private const float fHeartRadius = 0.3f;    //��Ʈ ������ ���� ũ�� ���
    private const float fPlayerRadius = 1.0f;   //�÷��̾� ���� ũ�� ���

    //private �������� ����
    private float fDistance = 0.0f; //��ü���� �Ÿ� ����

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;       //�ý��� ���ɺ� ���� ������ ���� 60������ ����

        gPlayer = GameObject.Find("player");    //�浹 ������ ���� �÷��̾� ������Ʈ�� ã�� ����
    }

    // Update is called once per frame
    void Update()
    {
        // Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
        //    Y ��ǥ�� -0.1f�� �����ϸ� ������Ʈ�� ���ݾ� ������ �Ʒ��� �����δ�
        //    �����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, -0.1f, 0);

        /*
         * ȭ�� ������ ���� ȭ�� �Ҹ��Ű��
         * ȭ���� ������ �θ� ȭ�� ������ ������ �ǰ�, ���� �������� ������ ��� ������
         * ȭ���� ������ �ʴ� ������ ��� �������� ��ǻ�� ���� ����� �ؾ��ϹǷ� �޸� ����
         * �޸𸮰� ������� �ʵ��� ȭ���� ȭ�� ������ ������ ������Ʈ�� �Ҹ���Ѿ� ��
         * Destroy �޼��� : �Ű������� ������ ������Ʈ�� ����
         * �Ű������� �ڽ�(ȭ�� ������Ʈ)�� ����Ű�� gameObject ������ �����ϹǷ� ȭ����
         * ȭ�� ������ ������ �� �ڱ� �ڽ��� �Ҹ��Ŵ
         */
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        vHeartPosition = transform.position;            //��Ʈ ��ġ ����
        vPlayerPosition = gPlayer.transform.position;   //�÷��̾� ��ġ ����

        vDir = vHeartPosition - vPlayerPosition;

        fDistance = vDir.magnitude; //magnitude �޼ҵ带 ����Ͽ� �Ÿ��� ��ȯ�� ���ͱ��� ����

        if (fDistance < fHeartRadius + fPlayerRadius) //��ü �� ���� �� ũ�� �պ��� �Ÿ��� ������ �浹
        {
            GameObject gDir = GameObject.Find("GameDirector"); //����� ���ÿ� �ʱ�ȭ

            gDir.GetComponent<GameDirector>().f_HpBarIncrease(); //GameDirector �� Hp���� �޼ҵ� ȣ��

            Destroy(gameObject);
        }
    }
}
