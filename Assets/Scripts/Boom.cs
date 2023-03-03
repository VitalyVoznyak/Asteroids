using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        StartCoroutine(Fade());
       // 
    }
    public IEnumerator Fade () // плавное утихание взрыва
    {
        for (float a = 1; a > 0; a -= 0.02f)
        {
            spriteRenderer.color = new Color(1,1,1,a); //плавное изчезновение

            transform.localScale = new Vector3 (       //плавное уменьшение
                transform.localScale.x + 0.001f, 
                transform.localScale.y + 0.001f, 
                transform.localScale.z + 0.001f);

            yield return new WaitForSeconds(0.02f);
        }
        Destroy(this.gameObject);
    }
    
}
