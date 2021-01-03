using System.Collections.Generic;
using UnityEngine;

public class AnimationSet
{
    private readonly Dictionary<string, int> AnimationDefaultDictionary = new Dictionary<string, int>();
    private readonly Dictionary<string, AnimationProperty> AnimationDictionary = new Dictionary<string, AnimationProperty>();

    public AnimationSet(Dictionary<string, int> animationDefaultDictionary)
    {
        AnimationDefaultDictionary = animationDefaultDictionary;
    }

    public HashSet<string> GetTags()
    {
        HashSet<string> tagSet = new HashSet<string>();
        foreach (string tag in AnimationDictionary.Keys)
        {
            tagSet.Add(tag);
        }
        foreach (string tag in AnimationDefaultDictionary.Keys)
        {
            tagSet.Add(tag);
        }
        return tagSet;
    }

    public void Add(AnimationTransition transition)
    {
        if (transition == null)
        {
            return;
        }
        foreach (string tag in transition.Tags)
        {
            Add(tag, transition.Value, transition.Tick);
        }
    }

    public void Add(string tag, int value, int tick)
    {
        AnimationDictionary.Add(tag, new AnimationProperty(value, tick));
    }

    public void Tick()
    {
        List<string> removableTagList = new List<string>();
        foreach(KeyValuePair<string, AnimationProperty> pair in AnimationDictionary)
        {
            AnimationProperty animationProperty = pair.Value;
            if(--animationProperty.Tick == 0)
            {
                removableTagList.Add(pair.Key);
            }
        }

        foreach(string removableTag in removableTagList)
        {
            Remove(removableTag);
        }
    }

    public void Remove(string tag)
    {
        AnimationDictionary.Remove(tag);
    }

    public int GetValue(string tag)
    {
        if (AnimationDictionary.TryGetValue(tag, out AnimationProperty defaultAnimationProperty))
        {
            return defaultAnimationProperty.Value;
        }
        else if (AnimationDefaultDictionary.TryGetValue(tag, out int defaultValue))
        {
            return defaultValue;
        }
        return -1;
    }

    public class AnimationProperty
    {
        public int Value;
        public int Tick;

        public AnimationProperty(int value, int tick)
        {
            Value = value;
            Tick = tick;
        }
    }
}
