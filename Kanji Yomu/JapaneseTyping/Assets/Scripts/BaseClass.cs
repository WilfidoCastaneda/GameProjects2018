using UnityEngine;

public abstract class BaseClass : MonoBehaviour {


    [SerializeField]private AudioClip openingSound;
    [SerializeField]private AudioClip correctSound;
    [SerializeField]private AudioClip incorrectSound;
    [SerializeField]private AudioClip completeSound;

    public abstract void OnTextComplete();

}
