/*
 * �÷��̾ ȭ�쿡 ������ ȭ�� ������ ���� ǥ�õǴ� HP �������� ���̴� ���
 * �÷��̾�� ȭ�� �浹�� �����ϰ� UI�� �����ϴ� ��ũ��Ʈ �ۼ�
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI�� ����ϱ⿡ �߰�
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public AudioClip BonusSound;
    public AudioClip HitSound;
    public AudioSource audioSource;

    //���� Ŭ���������� ����ϹǷ� private ��������
    private const float fHpUpItem = 0.1f;       //Hp ���� ������ ���
    private const float fHpDownFire = 0.21f;     //Hp ���� ������ ���(��)
    private const float fHpDownWater = 0.1f;     //Hp ���� ������ ���(��)
    private const float fPlayerHpZero = 0.0f;   //�÷��̾� Hp�� 0�� ���(���� ���� ����)

    /*
     * ���� ��ũ��Ʈ�� ����� HP �������� �����Ϸ��� ���� ��ũ��Ʈ�� HP �������� ��ü�� ������ �� �־�� ��
     * �׷��� ���ؼ� Object ������ �����ؼ� HP Guage Image Object�� ������ ����
     */
    GameObject gHpGauge = null; // ���ӿ�����Ʈ Ÿ������ null�� �ʱ�ȭ

    // Start is called before the first frame update
    void Start()
    {
        /*
         * �� ������Ʈ ���ڿ� �����ϴ� ������Ʈ�� �� �ȿ��� ã�� �־�� �Ѵ�.
         * �� �ȿ��� ������Ʈ�� ã�� �޼ҵ� : Find
         * Find �޼ҵ�� ������Ʈ �̸��� �μ��� �����ϰ�,
         * Find �޼ҵ带 ����� �� �߿��� HP �������� ������Ʈ�� ã�Ƽ� ������Ʈ ������ gHpGauge�� ����
         */
        gHpGauge = GameObject.Find("HpGauge");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ������(��Ʈ)�� ������ ü�¹ٰ� �����ϴ� �޼ҵ�, ArrowController���� ����ϱ� ���� public ��������
    /// </summary>
    public void f_HpBarIncrease()
    {
        gHpGauge.GetComponent<Image>().fillAmount += fHpUpItem; //���(fHpUpItem) ��ŭ Hp ����
        f_BonusSound();
    }

    /// <summary>
    /// ����(ȭ��, ��, �ҵ�)�� ������ ü�¹ٰ� �����ϴ� �޼ҵ�, ArrowController���� ����ϱ� ���� public ��������
    /// </summary>
    public void f_HpBarFireDecrease()
    {
        /*
         * ����Ƽ ������Ʈ�� GameObject��� �� ���ڿ� ���� �ڷ�(���۳�Ʈ)�� �߰��ؼ� ����� Ȯ����
         * ��) ������Ʈ�� ���������� �����̰� �Ϸ��� Rigidbody ���۳�Ʈ �߰�
         * ��) �Ҹ��� ���� �Ϸ��� AudioSource ���۳�Ʈ �߰�
         * ��) ��ü ����� �ø��� �ʹٸ� ��ũ��Ʈ ���۳�Ʈ�� �߰���
         * ���۳�Ʈ ���� ��� : GetComponent<>()
         * GetComponent�� ���� ������Ʈ�� ���� "oo ���۳�Ʈ�� �ּ���"��� ��Ź�ϸ�,
         * ��) AudioSource ���۳�Ʈ�� ���ϸ� �� GetComponent<AudioSource>()
         * ��) Text ���۳�Ʈ�� ���ϸ� �� GetComponent<Text>()
         * ��) ���� ���� ��ũ��Ʈ�� ���۳�Ʈ�� �����̹Ƿ� GetComponent �޼ҵ带 ����ؼ� ���� �� ����
         */
        gHpGauge.GetComponent<Image>().fillAmount -= fHpDownFire; //���(fHpDownFire) ��ŭ Hp ����
        f_HitSound();
        f_NextScene();                  // ä�� 0 �̸� ������ �ҷ����� �޼ҵ�

        /*
        if (gHpGauge.GetComponent<Image>().fillAmount == fPlayerHpZero) //Hp�������� fillAmount�� ��� fPlayerHpZero(0.0f)�� ������
        {
            //���������� ��ȯ
            SceneManager.LoadScene("EndScene");
        }
        */
    }

    public void f_HpBarWaterDecrease()
    {
        gHpGauge.GetComponent<Image>().fillAmount -= fHpDownWater; //���(fHpDownWater) ��ŭ Hp ����
        f_HitSound();
        f_NextScene();                  // ä�� 0 �̸� ������ �ҷ����� �޼ҵ�
    }

    public void f_NextScene()
    {
        if (gHpGauge.GetComponent<Image>().fillAmount == fPlayerHpZero) //Hp�������� fillAmount�� ��� fPlayerHpZero(0.0f)�� ������
        {
            //���������� ��ȯ
            SceneManager.LoadScene("EndScene");
        }
    }

    public void f_BonusSound()
    {
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(BonusSound);
    }

    public void f_HitSound()
    {
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(HitSound);
    }
}