using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public TohumPlusSprite tohumPlusSprite;
    ParticleSystem _particleSystem;
    Renderer _renderer;
    Collider2D _col;
    Rigidbody2D _rb;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _renderer = GetComponent<Renderer>();
        _col = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }
    public void ParticleStop()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }
    void Update()
    {
    }
    public void Hitting()
    {
        Tohum.Instance.TohumPlus(1);
        tohumPlusSprite.CreateTohumSprite(transform, 1);
        _particleSystem.Play();
        _renderer.enabled = false;
        _col.enabled = false;
        _rb.velocity = Vector3.zero;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.angularVelocity = 0f;
        StartCoroutine(HittingRestart());
    }
    IEnumerator HittingRestart()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        _renderer.enabled = true;
        _col.enabled = true;
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

}
