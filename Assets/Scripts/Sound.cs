using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound")]
public class Sound : ScriptableObject
{
    public string Name;

    public AudioClip clip;
    [Range(0.01f, 1f)] public float volume;
    [Range(-3f, 3f)] public float pitch;
}
