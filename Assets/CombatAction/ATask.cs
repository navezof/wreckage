using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATask : MonoBehaviour
{
    [SerializeField] protected new string name;
    [SerializeField] protected NextTask[] nextTaskList;

    protected CombatAction combatAction;
    protected SelectorManager selectorManager;

    public abstract void Execute();

    public void InitializeTask(CombatAction combatAction)
    {
        this.combatAction = combatAction;
        
        selectorManager = SelectorManager.current;
    }

    protected void ExecuteNextTask(ETaskResolution taskResolution)
    {
        foreach (NextTask nextTask in nextTaskList)
        {
            if (nextTask.resolution == taskResolution || nextTask.resolution == ETaskResolution.ALWAYS)
            {
                nextTask.task.InitializeTask(combatAction);
                nextTask.task.Execute();
            }
        }
    }

    protected void ExecuteNextTask()
    {
        foreach (NextTask nextTask in nextTaskList)
        {
            nextTask.task.InitializeTask(combatAction);
            nextTask.task.Execute();
        }
    }
}

[System.Serializable]
public struct NextTask
{
    public ETaskResolution resolution;
    public ATask task;
}

public enum ETaskResolution
{
    ON_SUCCESS,
    ON_FAILURE,
    ALWAYS
}
