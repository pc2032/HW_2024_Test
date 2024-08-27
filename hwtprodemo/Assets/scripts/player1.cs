using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1 : MonoBehaviour
{
    public Rigidbody rb;
    public float spd;
    public int score;

    public float yThreshold = 0.45f;

    private float x = 0f;
    private float z = 0f;

    void Start()
    {
        load_settings();
        score = 0;
    }

    void Update()
    {
        x = 0;
        z = 0;

        if (Input.GetKey(KeyCode.W)) { z = 1; }
        if (Input.GetKey(KeyCode.S)) { z = -1; }
        if (Input.GetKey(KeyCode.D)) { x = 1; }
        if (Input.GetKey(KeyCode.A)) { x = -1; }

        if (transform.position.y < yThreshold)
        {
            SceneManager.LoadScene("gameover");
        }
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(x, 0, z) * spd * 3;
        rb.velocity = move;
    }

    void load_settings()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("jspeed");
        if (jsonFile != null)
        {
            jspeed settings = JsonUtility.FromJson<jspeed>(jsonFile.text);
            spd = settings.speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            score++;
            Debug.Log("Score: " + score);
        }
    }
}

[System.Serializable]
public class jspeed
{
    public float speed;
}