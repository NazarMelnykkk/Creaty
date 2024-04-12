using UnityEngine;

public class MoveInputHandler : MonoBehaviour
{
    [SerializeField] private CommandHandler _commandHandler;
    [SerializeField] private PointHandler _pointHandler;

    private void OnEnable()
    {
       InputController.Instance.OnMoveDirectionButtonPerformedEvent += MoveCommand;
    }

    private void OnDisable()
    {
        InputController.Instance.OnMoveDirectionButtonPerformedEvent -= MoveCommand;
    }

    private void MoveCommand(Vector2 direction)
    {
        _commandHandler.SetCommand(new Command(CommandType.MoveToPoint, _pointHandler.GetPoint(direction)));
    }

}
