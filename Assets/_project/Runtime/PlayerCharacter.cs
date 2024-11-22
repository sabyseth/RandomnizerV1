using UnityEngine;
using KinematicCharacterController;

public struct CharacterInput
{
    public Quaternion Rotation;
    public Vector2 Move;
    public bool Jump;
}
public class PlayerCharacter : MonoBehaviour, ICharacterController
{

    [SerializeField] private KinematicCharacterMotor motor;
    [SerializeField] private Transform cameraTarget;
    [Space]
    [SerializeField] private float walkSpeed = 20f;
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private float gravity = -90f;

    private Quaternion _requestedRotation;
    private Vector3 _requestedMovement;
    private bool _requestedJump;

    public void Initialize()
    {
        motor.CharacterController = this;
    }

    public void UpdateInput(CharacterInput input)
    {
        _requestedRotation = input.Rotation;
        // Take the 2d input veector and create a 3d movement vector on the XZ plane.
        _requestedMovement = new Vector3(input.Move.x, 0f, input.Move.y);
        // clamp the lenght to 1 to prevent moving faster diagonally was WASD inoput.
        _requestedMovement = Vector3.ClampMagnitude(_requestedMovement, 1f);
        // Orient the input so it's relative to the direction te player is facing.
        _requestedMovement = input.Rotation * _requestedMovement;

        _requestedJump = _requestedJump || input.Jump;
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        if (motor.GroundingStatus.IsStableOnGround)
        {
            var groundedMovement = motor.GetDirectionTangentToSurface
            (
                direction: _requestedMovement,
                surfaceNormal: motor.GroundingStatus.GroundNormal
            ) * _requestedMovement.magnitude;
            
            currentVelocity = groundedMovement * walkSpeed;
        }
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        // Update the character's rotation to face in the same direction as the
        // requested rotation (camera rotation).

        // We don't want the character to pitch up and down, so the direction the character
        // looks should always be "flattened."

        // This is done by projecting a vector poingin in the same direction that
        // the player is looking onto a flay ground plane.

        var forward = Vector3.ProjectOnPlane
        (
            _requestedRotation * Vector3.forward,
            motor.CharacterUp
        );

        if (forward != Vector3.zero)
            currentRotation = Quaternion.LookRotation(forward, motor.CharacterUp);
    }

    public void BeforeCharacterUpdate(float deltaTime){}

    public void PostGroundingUpdate(float deltaTime){}

    public void AfterCharacterUpdate(float deltaTime){}


    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport){}

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport){}

    public bool IsColliderValidForCollisions (Collider coll) => true;

    public void OnDiscreteCollisionDetected (Collider hitCollider){}

    public void ProcessHitStabilityReport(
        Collider hitCollider, 
        Vector3 hitNormal, 
        Vector3 hitPoint, 
        Vector3 atCharacterPosition, 
        Quaternion atCharacterRotation, 
    ref HitStabilityReport hitStabilityReport){}

    public Transform GetCameraTarget() => cameraTarget;
}
