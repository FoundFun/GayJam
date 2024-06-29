using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class QuoteChooser : MonoBehaviour
{
    [SerializeField] private QuotesConfig _config;
    private int _currentQuoteIndex = 0;

    private void Start()
    {
        if (_config != null && _config.Quotes != null && _config.Quotes.Count > 0)
        {            
            SetCurrentQuote(_currentQuoteIndex);
        }
        else
        {
            Debug.LogError("QuotesConfig или список цитат не установлен!");
        }
    }

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeQuote();
        }
    }

    private void ChangeQuote()
    {
        if (_config.Quotes == null || _config.Quotes.Count == 0) 
            return;

        _currentQuoteIndex = (_currentQuoteIndex + 1) % _config.Quotes.Count;
        SetCurrentQuote(_currentQuoteIndex);
    }

    private void SetCurrentQuote(int index)
    {
        if (index >= 0 && index < _config.Quotes.Count)
        {
            Quote currentQuote = _config.Quotes[index];
            _config.QuoteText = currentQuote.QuoteText;
        }
        else
        {
            Debug.LogError("Индекс цитаты выходит за пределы списка!");
        }
    }
}
