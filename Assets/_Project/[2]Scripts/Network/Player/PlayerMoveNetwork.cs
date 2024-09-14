using Fusion;

public class PlayerMoveNetwork : NetworkBehaviour
{
    private NetworkCharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkMoveInput data))
        {
            data.Direction.Normalize();
            _cc.Move(5 * data.Direction * Runner.DeltaTime);
        }
    }
}
