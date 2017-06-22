using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameTicker : MonoBehaviour {
    public Text FrameValue;

	void Update () {
        if (FrameValue != null)
            FrameValue.text = Time.frameCount.ToString();	
	}
}
