using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("闪烁效果")]
    [SerializeField] private Material hitMat; // 闪烁颜色
    private Material originalMat; // 原始材质

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;

        yield return new WaitForSeconds(.2f);

        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.red)        
            sr.color = Color.red;   
        else     
            sr.color = Color.white;
        
    }

    private void CancelRedBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
