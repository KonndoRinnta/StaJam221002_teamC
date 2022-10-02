using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] string _damageTagName = "Damage";
    [SerializeField] string _pointTagName = "Point";
    [SerializeField] AudioSource _audio;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TimeSystem._isGame)
        {
            if (collision.gameObject.tag == _damageTagName)
            {
                Destroy(collision.gameObject);
                ScoreSystem.DecreaseScore();
                _audio.Play();
            }

            if (collision.gameObject.tag == _pointTagName)
            {
                Destroy(collision.gameObject);
                ScoreSystem.AddScore();
                _audio.Play();
            }
        }
    }
}
