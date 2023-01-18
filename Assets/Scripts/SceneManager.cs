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

    public AudioSource robotArmAudio;
    public AudioSource lampAudio;

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
            hapticEvents.Invoke("WeelEvent", 8f);
            aSource.PlayOneShot(adu[12]);
            tv.GetComponentInChildren<VideoPlayer>().Prepare();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            lamp.SetActive(true);
            lampAudio.Play();
            tv.GetComponent<Animator>().Play("Drop down");
            tv.GetComponentInChildren<VideoPlayer>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tv.GetComponent<Animator>().Play("Pop Up");
            bSource.PlayOneShot(adu[1]);
        }


        if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            robotArm.SetActive(true);
            animationParent.GetComponent<Animator>().Play("Armature_002|ArmLower");
            robotArmAudio.PlayOneShot(adu[9]);
            //Robot arm down thing
            //Play ear sound
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|Temperature Measure");
            robotArmAudio.PlayOneShot(adu[7]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|Heartbeat_Measure");
            robotArmAudio.PlayOneShot(adu[8]);
            hapticEvents.Invoke("HeartScan", 2f);
            //we stab the person in the chair
            //robot arm moves up and disappears again.
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|Arm Cutting");
            robotArmAudio.PlayOneShot(adu[6]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) 
        {
            animationParent.GetComponent<Animator>().Play("Armature_002_ArmRise");
            robotArmAudio.PlayOneShot(adu[9]);
            bSource.PlayOneShot(adu[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
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
            bSource.PlayOneShot(adu[3]);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|ArmLower");
            robotArmAudio.PlayOneShot(adu[9]);
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|Arm Cutting");
            robotArmAudio.PlayOneShot(adu[6]);
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
