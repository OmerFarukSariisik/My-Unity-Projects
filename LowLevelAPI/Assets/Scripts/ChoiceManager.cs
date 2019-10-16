using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public Image suiI;
    public Image witchI;
    public Image ghostI;
    public Image iceI;

    public Button suiB;
    public Button witchB;
    public Button ghostB;
    public Button iceB;
    public Button chooseB;

    public Text waitingText;

    private Color c;
    private Client client;
    private char hero;
    public static ChoiceManager Instance { get; set; }

    private void Start()
    {
        c.b = 255;
        c.a = 1f;
        Instance = this;
        DontDestroyOnLoad(gameObject);
        client = FindObjectOfType<Client>();
    }

    public void SuiButton()
    {
        hero = 's';
        suiI.color = c;
        c.a = 0f;

        witchI.color = c;
        iceI.color = c;
        ghostI.color = c;
        c.a = 1f;
    }
        public void WitchButton()
    {
        hero = 'w';
        witchI.color = c;
        c.a = 0f;

        suiI.color = c;
        iceI.color = c;
        ghostI.color = c;
        c.a = 1f;
    }
    public void GhostButton()
    {
        hero = 'g';
        ghostI.color = c;
        c.a = 0f;

        suiI.color = c;
        witchI.color = c;
        iceI.color = c;
        c.a = 1f;
    }
    public void IceButton()
    {
        hero = 'i';
        iceI.color = c;
        c.a = 0f;

        suiI.color = c;
        witchI.color = c;
        ghostI.color = c;
        c.a = 1f;
    }

    public void ChooseButton()
    {
        iceB.interactable = false;
        witchB.interactable = false;
        suiB.interactable = false;
        ghostB.interactable = false;

        chooseB.gameObject.SetActive(false);
        waitingText.gameObject.SetActive(true);
        client.Send("CHERO|" + hero);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
