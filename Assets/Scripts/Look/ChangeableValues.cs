using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ChangeableValues
{
	public float skipTimer { get; set; }

	public AudioClip sound;

	public Vector3 position;

	public Vector3 rotation;

	public Vector3 scale;

	public Color color;

	public float maxSkipTime;
}
