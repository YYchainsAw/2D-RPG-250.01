using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    private GameObject cam; // 引用主摄像头

    [SerializeField] private float parallaxEffect; // 视差效果的强度，控制背景移动速度

    private float xPosition; // 背景的初始X坐标
    private float length; // 背景Sprite的宽度

    void Start()
    {
        cam = GameObject.Find("Main Camera"); // 查找并获取名为"Main Camera"的游戏对象

        length = GetComponent<SpriteRenderer>().bounds.size.x; // 获取背景Sprite的宽度
        xPosition = transform.position.x; // 记录背景的初始X坐标
    }


    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect); // 计算摄像机移动的距离（考虑视差效果）
        float distanceToMove = cam.transform.position.x * parallaxEffect; // 计算背景需要移动的距离

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y); // 更新背景的X坐标，保持Y坐标不变

        // 如果背景移动超出一定范围，调整xPosition以实现无限循环背景
        if (distanceMoved > xPosition + length)
            xPosition = xPosition + length; // 向右循环
        else if (distanceMoved < xPosition - length)
            xPosition = xPosition - length; // 向左循环
    }
}