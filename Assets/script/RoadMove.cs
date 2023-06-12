using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class RoadMove : MonoBehaviour
{
    public GameObject background;
    [SerializeField] float speed;
    [SerializeField] GameObject swap;

    Vector2 respawn;
    Vector2 offset;
    float changeTime = 0f;
    bool isScroll = false;
    bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        respawn = swap.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        changeTime += Time.deltaTime;
        if(!isEnd)
        {
            if (changeTime < 15f && !isScroll && !isEnd)
            {

                offset = new Vector2(0, Time.time * speed);
                GetComponent<Renderer>().material.mainTextureOffset = offset;
            }
            else
            {
                isScroll = true;
                transform.Translate(Vector2.down * 5f * Time.deltaTime);
                if (background != null)
                {
                    background.transform.Translate(Vector2.down * 5f * Time.deltaTime);
                }

                offset = Vector2.zero;
                changeTime = 0f;

                if (transform.localPosition.y < -9.911392 && gameObject.tag == "bridge")
                {

                    Destroy(gameObject);
                    Destroy(background);

                }

                if (transform.localPosition.y < 0.01 && gameObject.tag == "highway")
                {
                    transform.position = respawn;
                    if (background.transform.localPosition.y < 0.01)
                    {
                        isScroll = false;
                    }


                }
            }
        }

    }

}
