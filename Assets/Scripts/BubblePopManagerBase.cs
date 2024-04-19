using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePopManagerBase : MonoBehaviour
{
    protected Renderer _renderer;
    [SerializeField] protected float _lerpSpeed;
    [SerializeField] protected float _dissolveSpeed;
    protected Coroutine _dissolveCoroutine;

    public enum SphereColor { Blue, Green, Yellow, Red };
    public SphereColor sphereColor;

    protected virtual void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        // Handle collision logic in derived classes
    }

    protected void BubblePop()
    {
        float target = 1;
        if (_dissolveCoroutine != null)
        {
            StopCoroutine(_dissolveCoroutine);
        }
        _dissolveCoroutine = StartCoroutine(CoroutineDissolveShield(target));
    }

    protected IEnumerator CoroutineDissolveShield(float target)
    {
        float start = _renderer.material.GetFloat("_DissolveProperty");
        float lerp = 0;
        while (lerp < 1)
        {
            _renderer.material.SetFloat("_DissolveProperty", Mathf.Lerp(start, target, lerp));
            lerp += Time.deltaTime * _lerpSpeed;
            yield return null;
        }
    }
}


