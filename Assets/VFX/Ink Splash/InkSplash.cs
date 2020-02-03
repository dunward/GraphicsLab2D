using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSplash : MonoBehaviour
{
    [SerializeField]
    private Material material;

    [SerializeField]
    private AnimationCurve curve;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Animate());
        }
    }

    private IEnumerator Animate()
    {
        float t = 0;
        while(curve.Evaluate(t) < 1f)
        {
            t += Time.deltaTime;
            material.SetFloat("_Delta", curve.Evaluate(t));
            yield return null;
        }
    }
}