using UnityEngine;
using UnityEngine.UI;
using System.Collections; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int scene;
    public Text sText;
    private int omNomNom; //Humor attept. It's used to check and see if PickUps are all gone.

    void OnAwake()
    {
        GameMgr.points = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        omNomNom = 16;
    }

    void Update()
    {
        if (omNomNom == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }

        sText.text = "Count: " + GameMgr.points.ToString();
    }

    void FixedUpdate()
    {
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(movHor, 0.0f, movVer);
        rb.AddForce(mov * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            GameMgr.points = GameMgr.points + 100;
            omNomNom--;
        }
        else if (other.gameObject.CompareTag("Hole"))
        {
            Destroy(this.gameObject.GetComponent<Collider>());
            GameMgr.points = GameMgr.points - 100;
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}
