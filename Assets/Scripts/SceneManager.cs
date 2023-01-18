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

    public GameObject lamp;

    public GameObject mesh1;
    public GameObject mesh2;
    public GameObject mesh3;
    public GameObject hand;


    public GameObject animationParent;
    public GameObject robotArm;
    public GameObject knife;

    public AudioSource aSource;
    public AudioSource bSource;

    public AudioClip[] adu;

    public HapticEvents hapticEvents;

    private void Start()
    {
        knife.SetActive(false);
        robotArm.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            weelChair.GetComponent<Animator>().SetBool("IsActivated", true);
            //hapticEvents.Invoke("WeelEvent", 8f);
            aSource.PlayOneShot(adu[12]);
            //animationParent.GetComponent<Animator>().Play("Armature_002_ArmDetract");
            tv.GetComponentInChildren<VideoPlayer>().Prepare();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            lamp.SetActive(true);
            tv.GetComponent<Animator>().Play("Drop down");
            tv.GetComponentInChildren<VideoPlayer>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tv.GetComponent<Animator>().Play("Pop Up");
            aSource.PlayOneShot(adu[1]);
        }


        if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            robotArm.SetActive(true);
            animationParent.GetComponent<Animator>().Play("Armature_002|ArmLower");
            //Robot arm down thing
            //Play ear sound
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|Heartbeat_Measure");
            hapticEvents.Invoke("HeartScan", 2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            robotArm.GetComponent<Animator>().Play("Armature_002|Temperature Measure");
            //we stab the person in the chair
            //robot arm moves up and disappears again.
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) 
        {
            aSource.PlayOneShot(adu[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            //let gas flow up if we're going to use it
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //Play the insect thing
            //play haptic vest again
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) 
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
