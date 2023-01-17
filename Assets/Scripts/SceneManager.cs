using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneManager : MonoBehaviour
{
    public GameObject weelChair;
    public GameObject tv;

    public GameObject fallingFloor;
    public GameObject visibleFloor;

    public GameObject lamp1;
    public GameObject lamp2;

    public GameObject robotArm;

    public AudioSource aSource;
    public AudioSource bSource;

    public HapticEvents hapticEvents;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            weelChair.GetComponent<Animator>().SetBool("IsActivated", true);
            robotArm.GetComponent<Animator>().Play("Armature_002_ArmDetract");
            tv.GetComponent<VideoPlayer>().Prepare();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            lamp1.SetActive(true);
            lamp2.SetActive(true);
            tv.GetComponent<VideoPlayer>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|ArmLower");
            //Robot arm down thing
            //Play ear sound
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|Heartbeat_Measure");
            //play haptic vest.
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|Temperature Measure");
            //we stab the person in the chair
            //robot arm moves up and disappears again.
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            //play voice initiate
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //let gas flow up if we're going to use it
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            //Play the insect thing
            //play haptic vest again
        }

        if (Input.GetKeyDown(KeyCode.Alpha9)) 
        {
            //play weird voice and afterwards
            //initiate phase 2 or seperate that to something else.
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|ArmLower");
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|Arm Cutting");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //play animation for weird player arms
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            //initiate phase 3
            visibleFloor.SetActive(false);
            hapticEvents.Invoke("RoomFalling", 1f);
            fallingFloor.GetComponent<Animator>().SetBool("IsActivated", true);
        }

    }
}
