using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool _cooldown = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null && _cooldown)
        {
            hit.Damage();
            _cooldown = false;
            StartCoroutine(CooldownTimer());
        }

        
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(0.5f);
        _cooldown = true;
    }
}
