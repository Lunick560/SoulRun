using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class CutSceneDialogBehaviour : PlayableBehaviour
{
    public string dialogueText;
    public string characterName;
    public Sprite speakerimage;
    public SpeakerUI Speaker;
    //public SpeakerUI SpeakerUI;
    // Start is called before the first frame update
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        Speaker = playerData as SpeakerUI;
        Speaker.Dialog.text = dialogueText;
        Speaker.Name.text = characterName;
        Speaker.Portrait.sprite = speakerimage;
    }
}
