using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;
    public static AudioManager Instance;

    private Dictionary<string, Sound> soundDict;
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

        soundDict = new Dictionary<string, Sound>();
        foreach (Sound s in sounds)
        {
            soundDict.Add(s.Name, s);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        Sound s = soundDict[soundName];
        audioSource.volume = s.volume;
        audioSource.pitch = s.pitch;
        audioSource.PlayOneShot(s.clip);
    }
}
