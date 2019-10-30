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
        _EndPortal = FindObjectOfType<EndPortal>().gameObject;
        _AudioSource = GameObject.Find("gamemanager").GetComponent<AudioSource>();
        _CollectedSound = Resources.Load<AudioClip>("Sound/PickupSound1");
        _SpriteRenderer = GetComponent<SpriteRenderer>();

        _EndPortal.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _EndPortal.SetActive(true);
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
