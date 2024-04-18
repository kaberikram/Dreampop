using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblePopped : MonoBehaviour
{
    Renderer _renderer;
    [SerializeField] float _LerpSpeed;
    [SerializeField] float _DisolveSpeed;
    Coroutine _disolveCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BubblePop();
        }
    }

      public void BubblePop()
    {
        float target = 1;
        if (_disolveCoroutine != null)
        {
            StopCoroutine(_disolveCoroutine);
        }
        _disolveCoroutine = StartCoroutine(Coroutine_DisolveShield(target));
    }

        IEnumerator Coroutine_DisolveShield(float target)
    {
        float start = _renderer.material.GetFloat("_DissolveProperty");
        float lerp = 0;
        while (lerp < 1)
        {
            _renderer.material.SetFloat("_DissolveProperty", Mathf.Lerp(start,target,lerp));
            lerp += Time.deltaTime * _DisolveSpeed;
            yield return null;
        }
    }
}
