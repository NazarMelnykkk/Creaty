using UnityEngine;

public enum CommandType
{
    None,
    MoveToPoint

}

public class Command
{
    public CommandType CommandType;
    public Vector3 Point;

    public bool IsComplete;

    public Command(CommandType commandType, Vector3 point)
    {
        CommandType = commandType;
        Point = point;
    }
}

public class CommandHandler : MonoBehaviour
{
    public Command CurrentCommand;
    private ICommandHandler moveCommandHandler;

    private void Awake()
    {
        moveCommandHandler = GetComponent<MoveHandler>();
    }

    public void SetCommand(Command newCommand)
    {
        if (CurrentCommand == null || CurrentCommand.CommandType != newCommand.CommandType)
        {
            CurrentCommand = newCommand;
        }
    }

    private void Update()
    {
        if (CurrentCommand == null)
        {
            return;
        }

        ProcessCommand();
    }

    private void ProcessCommand()
    {
        switch (CurrentCommand.CommandType)
        {
            case CommandType.MoveToPoint:
                ProcessMoveCommand();
                break;
        }
        if (CurrentCommand.IsComplete)
        {
            CompleteComand();
        }
    }

    private void CompleteComand()
    {
        CurrentCommand = null;
    }

    private void ProcessMoveCommand()
    {
        moveCommandHandler.ProcessCommand(CurrentCommand);
    }

    public CommandType GetCurrentCommandType()
    {
        if (CurrentCommand == null)
        {
            return CommandType.None;
        }

        return CurrentCommand.CommandType;
    }
}
