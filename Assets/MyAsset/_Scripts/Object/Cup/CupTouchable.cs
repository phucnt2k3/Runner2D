using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CupTouchable : ObjTouchable
{
    [Header("Cup Touchable")]
    [SerializeField] protected CupCtrl cupCtrl;
    [SerializeField] protected Animator cupAnimator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCupCtrl();
        LoadAnimator();
    }

    protected virtual void LoadCupCtrl()
    {
        if (cupCtrl != null) return;

        cupCtrl = transform.parent.GetComponent<CupCtrl>();
        Debug.LogWarning(transform.name + ": Load CupCtrl", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if(cupAnimator != null) return;

        cupAnimator = cupCtrl.Model.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": Load Cup Animator", gameObject);
    }

    private void OnEnable()
    {
        cupAnimator.enabled = false;
        isTouched = false;
    }

    protected override void OnTouch(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isTouched)
        {
            isTouched = true;
            cupAnimator.enabled = true;
            Invoke("NextLevel", 1.0f);
        }
    }

    private void NextLevel()
    {
        GameManager.Instance.OnWinGame();
    }
}
