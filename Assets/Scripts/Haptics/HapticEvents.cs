using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticEvents : MonoBehaviour
{

    public void WeelEvent()
    {
        Bhaptics.SDK2.BhapticsLibrary.Play("weelone");
    }

    public void RoomFalling()
    {
        Bhaptics.SDK2.BhapticsLibrary.Play("floor_rumble");
    }

    public void HeartScan()
    {
        Bhaptics.SDK2.BhapticsLibrary.Play("heartscan");
    }
}
