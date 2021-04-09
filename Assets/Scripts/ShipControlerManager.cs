using UnityEngine;
public class ShipControlerManager : MonoBehaviour
{

    public RectTransform mousePos;
    [SerializeField] private Transform shipBody;

    //private PhotonView View;
    public GameObject LosePanel;
    public GameObject mycam;

    private Controler controler;
    private Rigidbody ship_rb;

    public int health = 10;

    [Header("Move Speed")]
    public int moveSpeed;
    [Header("Mouse Sensivity")]
    public int mouseSensivity;
    [Header("Rotation Axis Multiplier")]
    public Vector3 rotSpeedVector;
    public bool jump_Start = false;


    private ShipControlByMouse mc;
    //private ShipControlByKey kc;

    private void Awake()
    {
      //  View = GetComponent<PhotonView>();
        ship_rb = GetComponent<Rigidbody>();
         mc = new ShipControlByMouse(shipBody,transform,ship_rb,moveSpeed,mouseSensivity,rotSpeedVector);
      //  kc = new ShipControlByKey(shipBody,transform, ship_rb, moveSpeed, rotSpeedVector);
        controler = mc;

        //if (View.IsMine)
        //{
        //    mycam.SetActive(true);
        //}
    }
    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.RightAlt))
        //{
        //    controler = kc;
        //}
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            controler = mc;
        }
    }
    private void FixedUpdate()
    {
           // if (View.IsMine)
            {
                controler.Move();
            }
    }

  //  [PunRPC]
    //public void ReduceHealth()
    //{
    //    health --;
    //    if (health<=0)
    //    {
    //        Debug.Log(View.name + " Died");
    //        if (View.IsMine)
    //        {
    //            LosePanel.SetActive(true);
    //        }
    //    }
    //}
}