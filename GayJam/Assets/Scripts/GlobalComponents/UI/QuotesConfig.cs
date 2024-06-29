using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuotesConfig", menuName = "Scriptable Objects/QuotesConfig")]
public class QuotesConfig : ScriptableObject
{
    [field: SerializeField, Range(0, 10)] public float FadeInDuration { get; private set; }
    [field: SerializeField, Range(0, 10)] public float PauseDuration { get; private set; }
    [field: SerializeField, Range(0, 10)] public float FadeOutDuration { get; private set; }
    [field: SerializeField, TextArea(6, 10)] public string QuoteText { get; set; }
    [field: SerializeField] public List<Quote> Quotes { get; private set; }
   
}
