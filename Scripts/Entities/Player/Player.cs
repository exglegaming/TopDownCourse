using Godot;

namespace TopDownCourse.Scripts.Entities.Player;

public partial class Player : CharacterBody2D
{
    private const float Speed = 150f;
    private const float Acceleration = 15f;
    
    private Vector2 _inputDirection = Vector2.Zero;

    public override void _Process(double delta)
    {
        _inputDirection = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");

        Velocity = Velocity.Lerp(_inputDirection * Speed, Acceleration * (float)delta);

        MoveAndSlide();
    }
}