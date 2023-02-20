using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float inputH;
    float inputV;
    Vector3 movement;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddPlayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");
        movement = new Vector3(inputH, 0, inputV).normalized;


        transform.Translate(movement * speed * Time.deltaTime);
    }
}
