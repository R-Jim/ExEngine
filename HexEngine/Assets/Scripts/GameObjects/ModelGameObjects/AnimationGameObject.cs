using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGameObject : MonoBehaviour
{
    private readonly Queue<Dictionary<string, int>> AnimationQueue = new Queue<Dictionary<string, int>>();
    public Model Model;
    public AnimationPreset.Preset AnimationPresetType;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Model == null)
        {
            return;
        }
        UpdateNewAnimation();
        UpdateAnimator();
    }

    private void UpdateNewAnimation()
    {
        LoggingEvent loggingEvent = Model.GetEvent();
        if (loggingEvent != null)
        {
            Dictionary<string, int> animationTransition = AnimationPreset.GetAnimationTransition(AnimationPresetType, loggingEvent.TriggerType);
            if (animationTransition != null)
            {
                AnimationQueue.Enqueue(animationTransition);
            }
        }
    }

    private void UpdateAnimator()
    {
        try
        {
            Dictionary<string, int> animationTransition = AnimationQueue.Dequeue();
            foreach (string tag in animationTransition.Keys)
            {
                animator.SetInteger(tag, animationTransition[tag]);
            }
        }
        catch (InvalidOperationException) { }
    }
}
