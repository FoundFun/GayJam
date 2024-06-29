using UnityEngine;
using TMPro;
using System.Collections;

public class QuoteLogic : MonoBehaviour
{
    [SerializeField] private QuotesConfig _quotesConfig;
    [SerializeField] private FadeIn _fadeIn;
    [SerializeField] private PauseTimer _pauseTimer;
    [SerializeField] private FadeOut _fadeOut;
    [SerializeField] private TMP_Text _quote;

    public void ShowQuote()
    {
        _quote.text = _quotesConfig.QuoteText;
        StartCoroutine(StartSequince());
    }

    private IEnumerator StartSequince()
    {
        yield return StartCoroutine(_fadeIn.FadeInCoroutine());
        yield return StartCoroutine(_pauseTimer.PauseCoroutine());
        yield return StartCoroutine(_fadeOut.FadeOutCoroutine());
    }
}
