using Godot;
using System;

public partial class Player_Movement : CharacterBody3D
{	
	const float speed = 5f;
	const float gravity = 30f;
	const float jumpForce = 8f;
	const float acceleration = 0.5f;
	const float sensitivity = 0.01f;

	private Vector3 vel = Vector3.Zero;
	
	public Camera3D _camera;
	public Node3D _head;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_head = GetNode<Node3D>("Head");
		_camera = GetNode<Camera3D>("Head/Camera");

		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
			_head.RotateY(-mouseMotion.Relative.X * sensitivity);
			_camera.RotateX(-mouseMotion.Relative.Y * sensitivity);

			Vector3 cameraRot = _camera.Rotation;
			cameraRot.X = Mathf.Clamp(cameraRot.X, Mathf.DegToRad(-80f), Mathf.DegToRad(80f));
			_camera.Rotation = cameraRot;
		}

	}

	public override void _PhysicsProcess(double delta) {
		Vector2 inputDir = Input.GetVector("left","right","forward","back");
		Vector3 direction = (_head.GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

		if ((direction != Vector3.Zero))
		{
			vel.X = direction.X * speed;
			vel.Z = direction.Z * speed;
		} else
		{
			vel.X = Mathf.MoveToward(Velocity.X, 0, acceleration);
			vel.Z = Mathf.MoveToward(Velocity.Z, 0, acceleration);
		}
		

		if (!IsOnFloor()){ vel.Y -= gravity * (float)delta;	}
		
		if (IsOnFloor() && Input.IsActionPressed("jump")){ vel.Y = jumpForce; }

		Velocity = vel;
		MoveAndSlide();
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("mouse_escape"))
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
	}
}
