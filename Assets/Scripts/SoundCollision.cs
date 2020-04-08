using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollision : MonoBehaviour
{

    public float SoundRatio;
    public AudioSource Audio;

    private void OnCollisionEnter(Collision collision)
    {
        var force = collision.relativeVelocity.magnitude;
        Audio.volume = force * SoundRatio;
        Audio.PlayOneShot(Audio.clip);
    }


}
