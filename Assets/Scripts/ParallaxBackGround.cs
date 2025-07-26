using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    private GameObject cam; // ����������ͷ

    [SerializeField] private float parallaxEffect; // �Ӳ�Ч����ǿ�ȣ����Ʊ����ƶ��ٶ�

    private float xPosition; // �����ĳ�ʼX����
    private float length; // ����Sprite�Ŀ��

    void Start()
    {
        cam = GameObject.Find("Main Camera"); // ���Ҳ���ȡ��Ϊ"Main Camera"����Ϸ����

        length = GetComponent<SpriteRenderer>().bounds.size.x; // ��ȡ����Sprite�Ŀ��
        xPosition = transform.position.x; // ��¼�����ĳ�ʼX����
    }


    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect); // ����������ƶ��ľ��루�����Ӳ�Ч����
        float distanceToMove = cam.transform.position.x * parallaxEffect; // ���㱳����Ҫ�ƶ��ľ���

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y); // ���±�����X���꣬����Y���겻��

        // ��������ƶ�����һ����Χ������xPosition��ʵ������ѭ������
        if (distanceMoved > xPosition + length)
            xPosition = xPosition + length; // ����ѭ��
        else if (distanceMoved < xPosition - length)
            xPosition = xPosition - length; // ����ѭ��
    }
}