using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    private bool InAir;
    Vector3 jump;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    void Start()
    {
        jump = new Vector3(0,250,0);
        InAir = false;
        rb = this.GetComponent<Rigidbody>();
        count=0;
        countText.text="Count: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && InAir == false)
        {
            rb.AddForce(jump);
        }
        float x =Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");

     
        Vector3 movement = new Vector3(x,0,z);

        rb.AddForce(movement*speed);
    }
    private void OnTriggerEnter(Collider other){
        other.gameObject.SetActive(false);
        count++;
        countText.text="Count: " + count.ToString();
       
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Untagged" && InAir == true)
        {
            InAir = false;
        }
        if (other.gameObject.tag == "Obstacle") {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        if (other.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        if (other.gameObject.tag == "Obstacle2")
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        if (other.gameObject.tag == "Goal2")
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Untagged" && InAir == true)
        {
            InAir = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        InAir = true;
    }
   
}
