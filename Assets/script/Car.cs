using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;


public class Car : MonoBehaviour
{
    #region Fields
    [SerializeField]


    private TextMeshProUGUI textScore;
    private Rigidbody2D carRigidbody;

    public new Transform transform;
    public float force = 7f;
    int score = 0;
    #endregion
    #region Methods
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        carMoving();
    }

    void carMoving()
    {
        float currentPosition = transform.position.x; // Lấy vị trí hiện tại của Car theo trục x

        if (Input.GetKey("w") && currentPosition < 5f) // Kiểm tra nếu nhấn phím "w" và vị trí hiện tại nhỏ hơn 5f
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force * Time.deltaTime));

        if (Input.GetKey("a") && currentPosition > -5f) // Kiểm tra nếu nhấn phím "a" và vị trí hiện tại lớn hơn -5f
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force * Time.deltaTime, 0));

        if (Input.GetKey("d") && currentPosition < 5f) // Kiểm tra nếu nhấn phím "d" và vị trí hiện tại nhỏ hơn 5f
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * Time.deltaTime, 0));

        if (Input.GetKey("s") && currentPosition > -5f) // Kiểm tra nếu nhấn phím "s" và vị trí hiện tại lớn hơn -5f
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Oncollison2d");
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Phá hủy đối tượng hiện tại
            Destroy(collision.gameObject);
            score += 1;
            textScore.text = "Score: " + score.ToString();// update điểm 


        }
    }
    #endregion

}