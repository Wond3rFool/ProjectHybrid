using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.VFX;

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

    public GameObject vfxGas;

    public GameObject animationParent;
    public GameObject robotArm;
    public GameObject knife;

    public AudioSource aSource;
    public AudioSource bSource;

    public AudioSource robotArmAudio;
    public AudioSource lampAudio;

    public AudioClip[] adu;

    public HapticEvents hapticEvents;

    bool isCutting = false;
    bool gasIsGassing = false;
    bool videoDone = false;
    bool armIsUp = false;
    bool armIsUp2 = false;

    float timer = 3.91f;
    float tvTimer = 4f;
    float tvTimer2 = 2f;
    float tvTimer3 = 2f;
    float vfxTimer = 3f;

    private void Start()
    {
        knife.SetActive(false);
        robotArm.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isCutting)
        {
            timer -= Time.deltaTime;
            if (timer < 0) 
            {
                mesh1.SetActive(false);
                mesh2.SetActive(true);
                isCutting = false;
                timer = 3.91f;
            }
        }
        if (gasIsGassing) 
        {
            vfxTimer -= Time.deltaTime;
            if (vfxTimer < 0) 
            {
                vfxGas.GetComponent<VisualEffect>().Stop();
                gasIsGassing = false;
                vfxTimer = 3f;
            }
        
        }
        if (videoDone)
        {
            tvTimer -= Time.deltaTime;
            if (tvTimer < 0)
            {
                bSource.PlayOneShot(adu[1]);
                videoDone = false;
                tvTimer = 4f;
            }
        }
        if (armIsUp) 
        {
            tvTimer2 -= Time.deltaTime;
            if (tvTimer2 < 0) 
            {
                bSource.PlayOneShot(adu[2]);
                armIsUp = false;
                tvTimer2 = 2f;
            }
        
        }
        if (armIsUp2) 
        {
            tvTimer3 -= Time.deltaTime;
            if (tvTimer3 < 0) 
            {
                bSource.PlayOneShot(adu[3]);
                armIsUp2 = false;
                tvTimer3 = 2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            weelChair.GetComponent<Animator>().SetBool("IsActivated", true);
            hapticEvents.Invoke("WeelEvent", 8f);
            vfxGas.GetComponent<VisualEffect>().Stop();
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
            videoDone = true;
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
            animationParent.GetComponent<Animator>().Play("Armature_002|Heartbeat_Measure V2");
            robotArmAudio.PlayOneShot(adu[8]);
            hapticEvents.Invoke("HeartScan", 2f);
            //we stab the person in the chair
            //robot arm moves up and disappears again.
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|BloodTest");
            robotArmAudio.PlayOneShot(adu[10]);

        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) 
        {
            animationParent.GetComponent<Animator>().Play("Armature_002_ArmRise");
            robotArmAudio.PlayOneShot(adu[9]);
            armIsUp = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            vfxGas.GetComponent<VisualEffect>().Play();
            gasIsGassing = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|ArmLower");
            robotArmAudio.PlayOneShot(adu[9]);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|Arm Cutting");
            robotArmAudio.PlayOneShot(adu[6]);
            isCutting = true;
            //Play the insect thing
            //play haptic vest again
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            //play weird voice and afterwards
            //initiate phase 2 or seperate that to something else.
            animationParent.GetComponent<Animator>().Play("Armature_002_ArmRise");
            robotArmAudio.PlayOneShot(adu[9]);
            armIsUp2 = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|ArmLower");
            knife.SetActive(true);
            robotArmAudio.PlayOneShot(adu[9]);
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            animationParent.GetComponent<Animator>().Play("Armature_002|Arm_Cutoff");
            robotArmAudio.PlayOneShot(adu[6]);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            hand.SetActive(true);
            mesh2.SetActive(false);
            mesh3.SetActive(true);
            animationParent.GetComponent<Animator>().Play("Hnad|Hand_Fall");
            //play animation for weird player arms
        }
        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            //initiate phase 3
            bSource.PlayOneShot(adu[4]);
            visibleFloor.SetActive(false);
            hapticEvents.Invoke("RoomFalling", 1f);
            fallingFloor.GetComponent<Animator>().SetBool("IsActivated", true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            lamp.SetActive(true);
            lampAudio.Play();
        }

    }
}
