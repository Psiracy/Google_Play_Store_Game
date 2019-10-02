using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Transform _Portal;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _CollectedSound;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
    private bool _Collected = false;
    private bool _SoundPlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _Portal.transform.gameObject.SetActive(true);
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
