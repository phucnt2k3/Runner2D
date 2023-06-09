using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCtrl : ObjCtrl
{
    [Header("Player Ctrl")]
    [SerializeField] private PlayerConfigSO playerInfo; 
    public PlayerConfigSO PlayerInfo => playerInfo;
    [SerializeField] private Rigidbody2D playerRb;
    public Rigidbody2D PlayerRb => playerRb;
    [SerializeField] private PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;
    [SerializeField] private PlayerJump playerJump;
    public PlayerJump PlayerJump => playerJump;
    [SerializeField] private DamageSender playerDamageSender;
    public DamageSender DamageSender => playerDamageSender;
    [SerializeField] private DamageReceiver playerDamageReceiver;
    public DamageReceiver DamageReceiver => playerDamageReceiver;
    [SerializeField] private FruitCollector playerFruitCollector;
    public FruitCollector FruitCollector => playerFruitCollector;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidBody();
        LoadPlayerMove();
        LoadPlayerJump();
        LoadPlayerDamageSender();
        LoadPlayerDamageReceiver();
        LoadPlayerFruitCollector();
        LoadPlayerConfig();
    }

    protected virtual void LoadPlayerConfig()
    {
        if (playerInfo != null) return;

        var objs = Resources.LoadAll("_Config", typeof(PlayerConfigSO));
        if (objs.Length > 1) 
            Debug.LogError(transform.name + ": Resources LoadAll 1 more PlayerConfigSO", gameObject);

        playerInfo = (PlayerConfigSO) objs[0];
        Debug.LogWarning(transform.name + ": Load PlayerConfigSO", gameObject);
    }

    protected virtual void LoadRigidBody()
    {
        if (playerRb != null) return;

        playerRb = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": Load Rigidbody2D", gameObject);
    }

    protected virtual void LoadPlayerMove()
    {
        if (playerMove != null) return;

        playerMove = transform.GetComponentInChildren<PlayerMove>();
        Debug.LogWarning(transform.name + ": Load PlayerMove", gameObject);
    }

    protected virtual void LoadPlayerJump()
    {
        if (playerJump != null) return;

        playerJump = transform.GetComponentInChildren<PlayerJump>();
        Debug.LogWarning(transform.name + ": Load PlayerJump", gameObject);
    }

    protected virtual void LoadPlayerDamageSender()
    {
        if (playerDamageSender != null) return;

        playerDamageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + ": Load Player DamageSender", gameObject);
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (playerDamageReceiver != null) return;

        playerDamageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": Load Player DamageReceiver", gameObject);
    }

    protected virtual void LoadPlayerFruitCollector()
    {
        if (playerFruitCollector != null) return;

        playerFruitCollector = transform.GetComponentInChildren<FruitCollector>();
        Debug.LogWarning(transform.name + ": Load Player FruitCollector", gameObject);
    }
}
