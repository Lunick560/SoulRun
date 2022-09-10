using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class SpeakerUI : MonoBehaviour
{
    public Image Portrait;
    public Text Name;
    public Text Dialog;
    /*
    private Character speaker;
    public Character Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            Portrait.sprite = speaker.DisplayImage;
            Name.text = speaker.name;
        }
    }
    // Start is called before the first frame update
    public string DialogText
    {
        set
        {
            Dialog.text = value;
        }
    }
    public bool HasSpeaker()
    {
        return speaker != null;
    }
    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    */
}
