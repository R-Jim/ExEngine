using System.Collections;
using UnityEngine;

public class SystemProperties : MonoBehaviour
{
    public static SystemProfile SystemProfile = new SystemProfile();
    private IEnumerator SystemTickCoroutine;

    private bool IsContinue = false;
    public static bool IsSwitch = false;
    public float TimeBetweenTick = .5f;

    private MomentumInterval MomentumInterval = new MomentumInterval();

    void Start()
    {
        SystemTickCoroutine = SystemTick();

    }

    void Update()
    {
        if (IsSwitch)
        {
            Switch();
        }
    }

    private void Switch()
    {
        IsSwitch = false;
        IsContinue = !IsContinue;
        if (IsContinue)
        {
            StartCoroutine(SystemTickCoroutine);
        }
        else
        {
            StopCoroutine(SystemTickCoroutine);
        }
    }

    IEnumerator SystemTick()
    {
        while (true)
        {
            RunIntervalSet();
            ++SystemProfile.SystemTick;
            yield return new WaitForSeconds(TimeBetweenTick);
        }
    }

    public void RunIntervalSet()
    {
        foreach (Model model in ModelContainer.ModelList)
        {
            //Assign Interval Entities here
            MomentumInterval.Run(SystemProfile.SystemTick, model);
        }
    }
}
