using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    GameObject gPlayer = null;

    Vector2 vWaterPosition = Vector2.zero;
    Vector2 vPlayerPosition = Vector2.zero;
    Vector2 vDir = Vector2.zero;

    //���
    private const float fWaterRadius = 0.5f;
    private const float fPlayerRadius = 1.0f;

    //����
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
        // Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
        //    Y ��ǥ�� -0.1f�� �����ϸ� ������Ʈ�� ���ݾ� ������ �Ʒ��� �����δ�
        //    �����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, -0.1f, 0);

        // ȭ�� ������ ���� ȭ�� �Ҹ��Ű��
        //   ȭ���� ������ �θ� ȭ�� ������ ������ �ǰ�, ���� �������� ������ ��� ������
        //   ȭ���� ������ �ʴ� ������ ��� �������� ��ǻ�� ���� ����� �ؾ��ϹǷ� �޸� ����
        //   �޸𸮰� ������� �ʵ��� ȭ���� ȭ�� ������ ������ ������Ʈ�� �Ҹ���Ѿ� ��
        // Destroy �޼��� : �Ű������� ������ ������Ʈ�� ����
        //   �Ű������� �ڽ�(ȭ�� ������Ʈ)�� ����Ű�� gameObject ������ �����ϹǷ� ȭ����
        //   ȭ�� ������ ������ �� �ڱ� �ڽ��� �Ҹ��Ŵ
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

            gDir.GetComponent<GameDirector>().f_HpBarWaterDecrease();   // ã�ƿ� gDir�� ���� f_HpBarReduction �޼ҵ� ��������

            Destroy(gameObject);
        }
    }
}
