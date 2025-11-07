using Godot;

namespace TopDownCourse.Scripts.Entities.Player;

public partial class Player : CharacterBody2D
{
    private const float Speed = 150f;
    private const float Acceleration = 15f;
    
    private Vector2 _inputDirection = Vector2.Zero;
    private string _facingDirection = "Down";
    private string _animationToPlay;
    private AnimatedSprite2D _animatedSprite2D;

    public override void _Ready()
    {
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }
    
    public override void _Process(double delta)
    {
        _inputDirection = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");

        Velocity = Velocity.Lerp(_inputDirection * Speed, Acceleration * (float)delta);

        MoveAndSlide();
        AnimationToPlay();
    }

    private string GetDirectionName()
    {
        if (_inputDirection == Vector2.Zero)
        {
            return _facingDirection;
        }

        if (_inputDirection.Y > 0)
        {
            _facingDirection = "Down";
        }
        else if (_inputDirection.Y < 0)
        {
            _facingDirection = "Up";
        }
        else
        {
            if (_inputDirection.X > 0)
            {
                _facingDirection = "Right";
            }
            else if (_inputDirection.X < 0)
            {
                _facingDirection = "Left";
            }
        }
        
        return _facingDirection;
    }

    private void AnimationToPlay()
    {
        if (Velocity.Length() > 20f)
        {
            _animationToPlay = "Run_" + GetDirectionName();
        }
        else
        {
            _animationToPlay = "Idle_" + GetDirectionName();
        }
        
        _animatedSprite2D.Play(_animationToPlay);
    }
}