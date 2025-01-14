﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;

    public GameObject explosionFactory; // 폭발 공장 주소 만들기
    // Start is called before the first frame update
    void Start()
    {

        int randValue = UnityEngine.Random.Range(0, 10);

        if(randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }else
        {
            dir = Vector3.down;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position += dir * speed * Time.deltaTime;
    }
}
