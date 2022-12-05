using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _hitClip;
    [SerializeField]
    private AudioClip _deathClip;

    //use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
        _audioSource = GetComponent<AudioSource>();
    }
    public override void Movement()
    {
        base.Movement();        
    }

    public void Damage()
    {
        if (Health < 1) return;
        //Debug.Log("Skeleton::Damage()");
        Health--;
        HealthBarUpdate(Health);
        if (Health >=1)
        {
            anim.SetTrigger("Hit");
            _audioSource.PlayOneShot(_hitClip);
            isHit = true;
            anim.SetBool("InCombat", true);
        }
        if (Health < 1)
        {
            isDeath = true;
            anim.SetTrigger("Death");
            _audioSource.PlayOneShot(_hitClip);
            _audioSource.PlayOneShot(_deathClip);
            GetComponent<BoxCollider2D>().enabled = false;
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }

    }

    public void Spike()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool _canDamage = true;

        if (other.tag == "Player")
        {
            anim.SetTrigger("Hit");
            isHit = true;
            anim.SetBool("InCombat", true);

            IDamageable hit = other.GetComponent<IDamageable>();

            if (_canDamage == true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }

        }

        IEnumerator ResetDamage()
        {
            yield return new WaitForSeconds(0.5f);
            _canDamage = true;
        }

    }
}
