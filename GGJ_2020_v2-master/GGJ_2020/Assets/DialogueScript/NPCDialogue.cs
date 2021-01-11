using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    private Dialogue dialogue;
    public AudioClip dialogueSound;
    public LevelController lc;
    [Multiline]
    public string text;
    public bool isActivated = false;

    public GameObject TalkCanvas;
    public GameObject soundController;

    private void ShowCanvas(bool boo)
    {
        if (dialogue.dType.choice == 2)
        {//Talk Text
            TalkCanvas.SetActive(boo);
            TalkCanvas.transform.GetChild(2).gameObject.SetActive(boo);
        }
        else if (dialogue.dType.choice == 1)
        {//Choice Text
            TalkCanvas.SetActive(boo);
            TalkCanvas.transform.GetChild(3).gameObject.SetActive(boo);
        }
    }
    public void PlayerEnter()
    {
        ShowCanvas(true);
    }
    public void PlayerExit()
    {
        ShowCanvas(false);
    }

    public void TriggerEvent(int c = 0)
    {
        if(dialogue.dType.choice == 1)
        {
            if(c == dialogue.correctAnswer)
                lc.AddBuff(dialogue.value);
            else
                lc.AddDeBuff(dialogue.value);
        }
        else if (dialogue.dType.choice == 2)
        {
            if (Random.Range(0, 2) == 1)
                lc.AddBuff(dialogue.value);
            else
                lc.AddDeBuff(dialogue.value);
        }
        ShowCanvas(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (!isActivated)
            {
                
                PlayerEnter();
            }
                
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerExit();
        }
    }

    private void Start()
    {
        dialogue = transform.GetComponent<Dialogue>();
        //lc = GameObject.FindWithTag("GameMaster").GetComponent<LevelController>();
    }
}
