using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class CutSceneDialogueClip : PlayableAsset
{
    public string dialog;
    public string name;
    public Sprite speakerimage;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<CutSceneDialogBehaviour>.Create(graph);

        CutSceneDialogBehaviour dialogueBehaviour = playable.GetBehaviour();
        dialogueBehaviour.dialogueText = dialog;
        dialogueBehaviour.characterName = name;
        dialogueBehaviour.speakerimage = speakerimage;
        return playable;

    }


}
