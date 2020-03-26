using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSound : MonoBehaviour
{
    private AudioSource Audio;
    [SerializeField]
    private AudioClip[] ClipList;
    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
    public void Play()
    {
        Audio.PlayOneShot(ClipList[Random.Range(0, ClipList.Length)]);
    }
}
