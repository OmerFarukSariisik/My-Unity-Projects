using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogueType dType;
    public string message;
    public string[] answers;
    public int correctAnswer;
    public float value;
    void Start()
    {
        dType = transform.GetComponent<DialogueType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
