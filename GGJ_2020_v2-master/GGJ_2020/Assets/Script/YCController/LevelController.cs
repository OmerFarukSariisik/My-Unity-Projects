using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Player player;
    public GameObject elmaCanvas;
    public bool cameraState;//false = yiğit , true = isaac
    private bool elmaMi= true;
    private bool elma = false;
    private bool elma2 = false;

    GameMaster gameMaster;
    void Start()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        ChangeCameraState(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ChangeCameraState(!cameraState);
        }

        if (elma)
        {
            if (Input.GetMouseButtonDown(0))
            {
                elmaCanvas.transform.GetChild(0).gameObject.SetActive(false);
                elma = false;
                elma2 = true;
            }
        }
        else if (elma2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                elmaCanvas.SetActive(false);
                elma2 = false;
            }
        }
    }

    public void AddBuff(float val)
    {
        player.isaac.speed = player.isaac.speed * val;
        player.isaac.speedLockTime = Time.time + 5.0f;
        // giveMap
    }
    public void AddDeBuff(float val)
    {
        player.isaac.speed = player.isaac.speed * val;
        player.isaac.speedLockTime = Time.time + 5.0f;
    }

    public void StartGame()
    {
        ChangeCameraState(true);
        if (elmaMi)
        {
            elmaCanvas.SetActive(true);
            elma = true;
            elmaMi = false;
        }
    }
    public void PauseGame()
    {
        ChangeCameraState(false);
    }

    public void Win()
    {
        gameMaster.Chapter += 1;
    }
    public void Died()
    {
        GameObject.Find("IPlayer").transform.position = new Vector3(0,-3,0);
    }
    
 
    void ChangeCameraState(bool state)
    {
        cameraState = state;
        player.AvatarChange(state);
        if (cameraState)
        {
            player.yc.ycCam.enabled = false;
            player.isaac.isaacCam.enabled = true;
        }
        else
        {
            player.yc.ycCam.enabled = true;
            player.isaac.isaacCam.enabled = false;
        }
    }
    

    void AddMap(int type)
    {

    }

}
