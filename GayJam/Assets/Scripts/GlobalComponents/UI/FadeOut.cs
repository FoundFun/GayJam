using System.Collections;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private QuotesConfig _quotesConfig;
    
    private float _fadeDuration;

    private void Start()
    {
        _fadeDuration = _quotesConfig.FadeOutDuration;
    }

    public IEnumerator FadeOutCoroutine()
    {
        _canvasGroup.alpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Clamp01(1f - elapsedTime / _fadeDuration);
            yield return null;
        }

        _canvasGroup.alpha = 0f;
    }
}
