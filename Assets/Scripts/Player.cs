using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class Player : MonoBehaviour
{
    private Vector3 newPosition;
    private Rigidbody player;
    private Vector3 moveDiraction;
    
    private void Awake()
    {
        player = GetComponent<Rigidbody>();
    }
    void Start()
    {
        newPosition = transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                moveDiraction = transform.position - newPosition;
            }
        }
        if (Input.GetMouseButton(0))
        {
            player.AddForce(-moveDiraction *Time.deltaTime ,ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goodObj")
        {
            GameManager.instance.scoreCount++;
            other.gameObject.SetActive(false);
            GameManager.instance.scoreCountText.text = "Score : " + GameManager.instance.scoreCount.ToString();
            GameManager.instance.winScore++;
            GameManager.instance.winScoreText.text = "Score : " + GameManager.instance.winScore.ToString();
            GameManager.instance.overScore++;
            GameManager.instance.overScoreText.text = "Score : " + GameManager.instance.overScore.ToString();
            if (GameManager.instance.scoreCount == 11)
            {
                player.isKinematic = true;
                GameManager.instance.ShowWinPanel();
            }
        }
        else if (other.gameObject.tag == "badObj")
        {
            other.gameObject.SetActive(false);
            GameManager.instance.playerHealth--;
            GameManager.instance.playerHealthText.text = "Health : " + GameManager.instance.playerHealth.ToString();
            if (GameManager.instance.playerHealth == 0)
            {
                player.isKinematic = true;
                GameManager.instance.ShowGameOverPanel();
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "isGround")
        {
            GameManager.instance.ShowGameOverPanel();
        }
    }
}