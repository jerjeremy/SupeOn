using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketGrassSway : MonoBehaviour
{
    private GrassVelocity _grassVelocityController;
    [SerializeField] private GameObject _bucket;
    private Material _material;
    private Rigidbody rb;

    private bool easeinCoruotineRun;
    private bool easeoutCoruotineRun;

    private int _externalInfluence = Shader.PropertyToID("_ExternalInfluence");

    private float _startingVelocity;
    private float velocityLastFrame;

    private void Start()
    {
        //_bucket = GameObject.FindGameObjectWithTag("Bucket");
        rb = _bucket.GetComponent<Rigidbody>();
        _grassVelocityController = GetComponentInParent<GrassVelocity>();

        _material = _bucket.GetComponent<SpriteRenderer>().material;
        _startingVelocity = _material.GetFloat(_externalInfluence);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == _bucket)
        {
            if(!easeinCoruotineRun && Mathf.Abs(rb.velocity.x) > Mathf.Abs(_grassVelocityController.VelocityThreshold))
            {
                StartCoroutine(EaseIn(rb.velocity.x * _grassVelocityController.externalInfluence));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == _bucket)
        {
            if (!easeinCoruotineRun && Mathf.Abs(rb.velocity.x) > Mathf.Abs(_grassVelocityController.VelocityThreshold))
            {
                StartCoroutine(EaseOut());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _bucket)
        {
            if (Mathf.Abs(velocityLastFrame) > Mathf.Abs(_grassVelocityController.VelocityThreshold) &&
                    Mathf.Abs(rb.velocity.x) < Mathf.Abs(_grassVelocityController.VelocityThreshold))
            {
                StartCoroutine(EaseOut());  
            }
            else if(Mathf.Abs(rb.velocity.x) > Mathf.Abs(_grassVelocityController.VelocityThreshold) &&
                Mathf.Abs(velocityLastFrame) < Mathf.Abs(_grassVelocityController.VelocityThreshold))
            {
                StartCoroutine(EaseIn(rb.velocity.x * _grassVelocityController.externalInfluence));
            }
            else if(!easeinCoruotineRun && !easeoutCoruotineRun && 
                Mathf.Abs(rb.velocity.x) > Mathf.Abs(_grassVelocityController.VelocityThreshold))
            {
                _grassVelocityController.InfluenceOnGrass(_material, rb.velocity.x*_grassVelocityController.externalInfluence);
            }
            velocityLastFrame = rb.velocity.x;
        }
    }

    private IEnumerator EaseIn(float Xvel)
    {
        easeinCoruotineRun = true;

        float elaspedTime = 0.0f;

        while (elaspedTime < _grassVelocityController.easeInTime)
        {
            elaspedTime += Time.deltaTime;
            float lerpedAmount = Mathf.Lerp(_startingVelocity, Xvel, (elaspedTime / _grassVelocityController.easeInTime));

            yield return null;
        }

        easeoutCoruotineRun = false;
    }

    private IEnumerator EaseOut()
    {
        easeoutCoruotineRun = true;

        float currentInflunce = _material.GetFloat("_ExternalInfluence");
        float elaspedTime = 0.0f;
        while (elaspedTime < _grassVelocityController.easeOutTime)
        {
            elaspedTime += Time.deltaTime;

            float lerpedAmount = Mathf.Lerp(currentInflunce, _startingVelocity, (elaspedTime/ _grassVelocityController.easeOutTime));
            _grassVelocityController.InfluenceOnGrass(_material, lerpedAmount);

            yield return null;
        }

        easeinCoruotineRun = false;
    }
}
