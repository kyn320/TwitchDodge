using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public int hp;

    [SerializeField]
    float h, v;

    Transform tr;
    Rigidbody2D ri;

    public float moveSpeed;

    public bool isKnockBack;
    public float knockBackPower = 100f;

    CameraShake camShake;

    void Awake()
    {
        tr = GetComponent<Transform>();
        ri = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        camShake = GameManager.Instance.mainCam.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (isKnockBack)
            return;

        ri.velocity = Vector2.zero;
        ri.velocity = (Vector2.right * h + Vector2.up * v) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        if (_col.gameObject.CompareTag("Heal"))
        {
            AddHp(1);
            ObjectPoolManager.Instance.Get("HealEffect").transform.position = tr.position;
            ObjectPoolManager.Instance.Free(_col.gameObject);
        }
        else if (_col.gameObject.CompareTag("Bullet"))
        {
            SubHp(1);
            ObjectPoolManager.Instance.Get("DamageEffect").transform.position = tr.position;
            ObjectPoolManager.Instance.Free(_col.gameObject);
            camShake.ShakeCam();
            KnockBackDamage((_col.gameObject.transform.position - tr.position).normalized);
        }
        else if (_col.gameObject.CompareTag("Trap"))
        {
            SubHp(1);
            ObjectPoolManager.Instance.Get("TrapEffect").transform.position = tr.position;
            ObjectPoolManager.Instance.Free(_col.gameObject);
        }
    }

    public void AddHp(int _amount)
    {
        ++hp;
        hp = Mathf.Clamp(hp, 0, 10);
        GameManager.Instance.ui.heart.UpdateHp(hp);
    }

    public void SubHp(int _amount)
    {
        --hp;
        hp = Mathf.Clamp(hp, 0, 10);

        if (hp <= 0)
            GameManager.Instance.EndGame();

        GameManager.Instance.ui.heart.UpdateHp(hp);
    }

    public void KnockBackDamage(Vector2 _dir)
    {
        if (knockBack != null)
            StopCoroutine(knockBack);

        isKnockBack = true;
        knockBack = StartCoroutine(KnockBack(_dir));
    }

    Coroutine knockBack = null;

    IEnumerator KnockBack(Vector2 _dir)
    {
        ri.AddForce(-_dir * knockBackPower, ForceMode2D.Impulse);

        ri.drag = knockBackPower * 2.5f;
        while (ri.velocity.sqrMagnitude > 0.5f)
        {
            yield return null;
        }
        ri.drag = 0f;
        isKnockBack = false;
    }
}
