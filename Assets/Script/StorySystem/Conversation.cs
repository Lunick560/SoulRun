using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public struct line
{
    public Character character;
    [TextArea(2, 5)]
    public string text;
}
[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]

public class Conversation:ScriptableObject
{
    public Character speakerLeft;
    public Character speakerRight;
   // public Character speakerInThemiddle;
    public line[] lines;
}
