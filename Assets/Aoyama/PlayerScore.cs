using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] string _damageTagName = "Damage";
    [SerializeField] string _pointTagName = "Point";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _damageTagName)
        {
            Destroy(collision.gameObject);
            ScoreSystem.DecreaseScore();
        }

        if (collision.gameObject.tag == _pointTagName)
        {
            Destroy(collision.gameObject);
            ScoreSystem.AddScore();
        }
    }
}
