//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Net.Http;
//using UnityEngine;


//public class Coin_Spawner : MonoBehaviour
//{
//    public GameObject coinPrefab;
//    public float speed = 4f;
//    private bool isCoinSpawned = false;
//    public Transform holder;


//    private Camera mainCamera;


//    // Start is called before the first frame update
//    void Start()
//    {
//        mainCamera = Camera.main;
//        StartCoroutine(CoinSpawner());


//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
//    }

//    //void CoinSpawn()
//    //{

//    //    float randomX = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
//    //    Vector3 spawnPosition = new Vector3(randomX, mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y, transform.position.z);
//    //    Instantiate(coinPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
//    //}
//    private void CoinSpawn()
//    {
//        if (isCoinSpawned)
//        {
//            return;
//        }

//        float randomX = UnityEngine.Random.Range(-5f, 5f);
//        Vector3 spawnPosition = new Vector3(randomX, mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y, transform.position.z);
//        GameObject coint = Instantiate(coinPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
//        isCoinSpawned = true;
//        coint.transform.SetParent(this.holder);


//    }

//    IEnumerator CoinSpawner()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(1f);
//            CoinSpawn();
//        }
//    }
//}
////private void ontriggerenter2d(collider2d collision)
////{
////    debug.log("collision occurred !!!");
////}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float speed = 4f;
    private bool isCoinSpawned = false;
    public Transform holder;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(CoinSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void CoinSpawn()
    {
        if (isCoinSpawned)
        {
            return;
        }

        float randomX = UnityEngine.Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(randomX, mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y, transform.position.z);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
        isCoinSpawned = true;
        coin.transform.SetParent(this.holder);
    }

    IEnumerator CoinSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            CoinSpawn();
            isCoinSpawned = false; // Đặt lại cờ để tạo đồng xu tiếp theo
        }
    }
}
