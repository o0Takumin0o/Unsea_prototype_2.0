using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlphaFading : MonoBehaviour
{
    SpriteRenderer Sprite;
    public Collector collector;
    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Color c = Sprite.material.color;
        c.a = 0f;
        Sprite.material.color = c;
    }
    public void Update()
    {
        if (collector.mainPoint == 3)
        {
            StartFading();
        }
    }

    IEnumerable FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = Sprite.material.color;
            c.a = f;
            Sprite.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void StartFading()
    {
        StartCoroutine("FadeIn");
    }

}
