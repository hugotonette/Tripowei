using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float Speed = 10;
    public Collider2D FieldOfView;

    #region States
    public enum State
    {
        Idle,
        Persuit,
    }

    public State state;

    IEnumerator IdleState()
    {
        while (state == State.Idle)
            yield return 0;

        NextState();
    }

    IEnumerator PersuitState()
    {
        while (state == State.Persuit)
            yield return 0;
        NextState();
    }

    void NextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }
    #endregion
    /* 
     * State:
     *  Idle
     *  Persuit
    */

    private void Start()
    {
        NextState();
    }

    private void FixedUpdate()
    {
        if (state == State.Idle)
        {
            //something may happen
        }
        if (state == State.Persuit)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
            if (state == State.Idle)
                state = State.Persuit;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
            if (state == State.Persuit)
                state = State.Idle;
    }
}
