using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoltHolder : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject blockHolder;
    private BlockHolder _blockHolder;
    private Animator _animator;
    private void Start()
    {
        //initialize components
        _animator = GetComponent<Animator>();
        _blockHolder = blockHolder.GetComponent<BlockHolder>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //play animation
        _animator.Play("Fall");
        StartCoroutine(SwitchOff());
    }

    private IEnumerator SwitchOff()
    {
        yield return new WaitForSeconds(2.1f);
        gameObject.SetActive(false);
        _blockHolder.Check();
    }
}
