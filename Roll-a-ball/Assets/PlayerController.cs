using System . Collections ;
using System . Collections . Generic ;
using UnityEngine ;
using UnityEngine . InputSystem ;

public class PlayerController : MonoBehaviour {

public Vector2 moveValue;
public float speed;
private int count;
private int numPickups = 4; // Put here the number of pickups you have .
public TMPro.TextMeshProUGUI ScoreText;
public TMPro.TextMeshProUGUI WinText;

    void Start()
    {
        count=0;
        WinText.text = "";
        SetCountText();
    }
    void OnMove ( InputValue value ) {
        moveValue = value.Get< Vector2 >() ;
    }

    void FixedUpdate () {
        Vector3 movement = new Vector3 ( moveValue.x , 0.0f , moveValue.y ) ;

        GetComponent < Rigidbody >() . AddForce ( movement * speed * Time.fixedDeltaTime ) ;
    }

    void OnTriggerEnter ( Collider other ) {
        if( other.gameObject.tag == "PickUp" ){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        ScoreText.text = " Score : " + count.ToString();
        if (count >= numPickups)
        {
            WinText.text = " You win ! ";
            }
        }

}
