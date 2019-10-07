using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject _EndPortal;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _CollectedSound;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
    private bool _Collected = false;
    private bool _SoundPlayed = false;

    private void Start()
    {
        _EndPortal = GameObject.Find("EndPortal");
        _AudioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();

        _EndPortal.GetComponent<SpriteRenderer>().enabled = false;
        _EndPortal.GetComponent<Collider2D>().enabled = false;
        _EndPortal.GetComponent<ParticleSystem>().Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _EndPortal.GetComponent<SpriteRenderer>().enabled = true;
        _EndPortal.GetComponent<Collider2D>().enabled = true;
        _EndPortal.GetComponent<ParticleSystem>().Play();
        _AudioSource.clip = _CollectedSound;
        _AudioSource.Play();
        _SoundPlayed = true;
        _Collected = true;

        if (_SoundPlayed)
        {
            gameObject.SetActive(false);
        }
    }
}
