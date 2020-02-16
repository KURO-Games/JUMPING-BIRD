using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    public GameObject Rock;
    public static int speed = 1;
    ZonbieState _zonbieState;
    //飛ばすオブジェクト
    private GameObject ThrowingObject;
    
    /// 標的のオブジェクト
    [SerializeField]
    private GameObject leftTargetObject;
    [SerializeField]
    private GameObject rightTargetObject;

    /// 射出角度
    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float ThrowingAngle;
    private Rigidbody2D rid2D;
    private Vector3 targetPosition;
    //[HideInInspector]
    public bool inCamera;
    private bool zombieJumpBool = true;
    [SerializeField]
    private GameObject zombieShadow;
    private bool isFry = false;
    enum ZonbieState
    {
        Wait,
        Attack,
        Die,
    }
    void Awake()
    {
        
    }
    private void Start()
    {
        _zonbieState = ZonbieState.Wait;
        ThrowingObject = GameObject.FindWithTag("Zombie");
        rid2D = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Debug.Log("Birdpos" + Bird.Instance.bird().transform.position.x);

        if (this.gameObject.transform.position.x < Bird.Instance.bird().transform.position.x + 10 && Bird.Instance.bird().transform.position.x - 10 < this.gameObject.transform.position.x)
        {
            inCamera = true;
        }
        else
        {
            inCamera = false;
        }

        float step = speed * Time.deltaTime;
        if (Bird.Instance.Die == false && zombieJumpBool)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(Bird.Instance.bird().transform.position.x, this.transform.position.y), step);
            if (gameObject.transform.position.x + 5 > Bird.Instance.bird().transform.position.x && gameObject.transform.position.x - 5 < Bird.Instance.bird().transform.position.x)
            {
                RockAttack();
            }
            if (this.transform.position.x < Bird.Instance.bird().transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    void AttackReset()
    {
        _zonbieState = ZonbieState.Wait;
    }

    void RockAttack()
    {        
        //Debug.Log("RockAttack");
        if (_zonbieState==ZonbieState.Wait && !SPGimick.Instance.SPGimickStart)
        {
            Vector2 InstantiateRock;
            InstantiateRock.x = this.gameObject.transform.position.x - 1;
            InstantiateRock.y = this.gameObject.transform.position.y - 1;
            GameObject _Rockinstance = Instantiate(Rock, InstantiateRock, Quaternion.identity);
            _Rockinstance.name = Rock.name + this.gameObject.name;
            _zonbieState = ZonbieState.Attack;
            Invoke("AttackReset", 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //左向き
        if (collision.gameObject.tag == "RightCol" && this.transform.localRotation.y == 0)
        {
            //this.rid2D.simulated = true;
            this.rid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            targetPosition = leftTargetObject.transform.position;
            ThrowingZombie(targetPosition);
        }
        
        //右向き
        if (collision.gameObject.tag == "LeftCol" && this.transform.localRotation.y == -1)
        {
            //this.rid2D.simulated = true;
            this.rid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            targetPosition = rightTargetObject.transform.position;
            ThrowingZombie(targetPosition);
        }

        if (collision.gameObject.tag == "Ground" && this.transform.localRotation.y == 0 && isFry)
        {
            isFry = false;
            zombieShadow.gameObject.SetActive(true);
            zombieJumpBool = true;
            //this.rid2D.simulated = false;
            this.rid2D.velocity = Vector2.zero;
            this.rid2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }

        if (collision.gameObject.tag == "Ground" && this.transform.localRotation.y == -1 && isFry)
        {
            isFry = false;
            zombieShadow.gameObject.SetActive(true);
            zombieJumpBool = true;
            //this.rid2D.simulated = false;
            this.rid2D.velocity = Vector2.zero;
            this.rid2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void ThrowingZombie(Vector3 targetPosition)
    {
        zombieShadow.gameObject.SetActive(false);
        isFry = true;

        zombieJumpBool = false;
        // 射出角度
        float angle = ThrowingAngle;

        // 射出速度を算出
        Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

        // 射出        
        this.rid2D.AddForce(velocity * rid2D.mass, ForceMode2D.Impulse);
    }

    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
