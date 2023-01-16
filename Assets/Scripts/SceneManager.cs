using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject weelChair;
    public GameObject fallingFloor;
    public GameObject visibleFloor;
    public GameObject lamp1;
    public GameObject lamp2;
    public AudioSource aSource;
    public AudioSource bSource;
    public HapticEvents hapticEvents;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            weelChair.GetComponent<Animator>().SetBool("IsActivated", true);
            //hapticEvents.RoomFalling();
            hapticEvents.Invoke("RoomFalling",5f);
            //aSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            lamp1.SetActive(true);
            lamp2.SetActive(true);  
            //bSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            //Robot arm down thing
            //Play ear sound
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            //Robot arm to chest thing
            //play haptic vest.
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Robot arm to arm
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
            //Robot arm returns. watch He has A gun!!. on no wait it's a knife.
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            //if player looks at the knife start cutting.
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //play animation for weird player arms
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            //initiate phase 3
            visibleFloor.SetActive(false);
            fallingFloor.GetComponent<Animator>().SetBool("IsActivated", true);
        }

    }
}
