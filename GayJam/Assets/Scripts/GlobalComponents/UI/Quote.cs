using UnityEngine;

[CreateAssetMenu(fileName = "Quote", menuName = "Scriptable Objects/Quote")]
public class Quote : ScriptableObject
{
    [field: SerializeField, TextArea(6, 10)] public string QuoteText { get; private set; }
}