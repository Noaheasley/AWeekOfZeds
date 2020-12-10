# Design of the game

the game's design uses a while loop that loops through multiple update functions

the player shoots a gun that sends out a single bullet everytime it is fired

enemies will track and chase the player till either they die or the player dies

# Object description

### Game Class
     Name: _gameOver
             Description: determines if the game has ended or not
             Type:static bool
     Name: Scene[]
             Description: is the Scene index
             Type:static Scene[]
     Name: _currentSceneIndex
             Description: gets the current index the scene is in
             Type:static int
     Name: _enemy1 - _enemy6
             Description: constructor for the enemy to allow them to spawn
             Type:Enemy
     Name: _player
             Description: constructor for the player
             Type:Player
     Name: _gun
             Description: constructor for the gun
             Type:Item
     Name: _scene
             Description: constructor for the scene
             Type:Scene
     Name: CurrentSceneIndex
             Description: returns _currentSceneIndex for any classes that wants to use it
             Type:static int
     Name: GetScenes(int index)
             Description: returns _scenes[index] for any Scene index
             Type:static Scene
     Name: GetCurrentScene()
             Description: returns _scenes[_currentSceneIndex] for any the current Scene
             Type:static Scene
     Name: GetKeyDown(int key)
             Description: Reads if any key is pressed
             Type:static bool
     Name: AddScene(Scene scene)
             Description: adds a scene into the scene index
             Type:static int
     Name: RemoveScene(Scene scene)
             Description: removes a scene from the scene index
             Type:static bool
     Name: SetGameOver(bool value)
             Description: sets _gameOver to a value (true or false)
             Type:static void
     Name: Game()
             Description: Constructor for Game
             Type:public
     Name: SetCurrentScene(int index)
             Description: sets a scene to be the current scene in the scene index
             Type:static void
     Name: Start()
             Description: the start of the game that sets up all the scenes and characters in those scenes
             Type:void
     Name: Update(float deltaTime)
             Description: Updates the current scene by a certain frame rate
             Type:void
     Name: Draw()
             Description: Updates the actors in a scene to allow movement and animation
             Type:void
     Name: Run()
             Description: used to run the entire program
             Type:void
             
### Actor Class
     Name: _icon
             Description: used for icons of actors
             Type:char
     Name: _velocity
             Description: used for the velocity of different actors
             Type:Vector2
     Name: acceleration
             Description: used for acceleration for velocity
             Type:Vector2
     Name: _maxSpeed
             Description: sets the max speed acceleration can increase to
             Type:float
     Name: _sprite
             Description: used for sprites
             Type:Sprite
     Name: _globalTransform
             Description: used for the global transform of the actors
             Type:Matrix3
     Name: _localTransform
             Description: used for the local transform of the actors
             Type:Matrix3
     Name: _translation
             Description: used for the translation of the actors
             Type:Matrix3
     Name: _rotation
             Description: used for the rotation of actors
             Type:Matrix3
     Name: _scale
             Description: used for the scale of actors
             Type:Matrix3
     Name: _color
             Description: used for Console color
             Type:ConsoleColor
     Name: _rayColor
             Description: used to color the raylib icons
             Type:Color
     Name: _parent
             Description: used to tag an actor to be a parent
             Type:Actor
     Name: _isDead
             Description: used to tag an actor to be dead
             Type:bool
     Name: _interacted
             Description: a tag for items that were interacted by another actor
             Type:bool
     Name: _children
             Description: used to put an actor in a array for children 
             Type:Actor[]
     Name: _health
             Description: used for the health value of actors 
             Type: float
     Name: _name
             Description: used to give actors a name 
             Type:string
     Name: _damage
             Description: used to give actors a damage value 
             Type:float
     Name: _speed
             Description: sets the speed of an actor 
             Type:float
     Name: _angle
             Description: sets the angle of an actor 
             Type:float
     Name: _points
             Description: gives actors a point value 
             Type:float
     Name: _collisionRadius
             Description: gives actors a radius for their collision
             Type:float
     Name: Speed
             Description: gets and sets _speed to a value 
             Type:float
     Name: Forward
             Description: sets the forward to be m11 and m21 in the local transforms
             Type:Vector2
     Name: Acceleration
             Description: gets and sets actor's Acceleration to be a value 
             Type:Vector2
     Name: MaxSpeed
             Description:gets and sets actor's MaxSpeed to be a value 
             Type:float
     Name: WorldPosition
             Description: gets and sets m13 and m23 to a x and y value in a global transform
             Type:Vector2
     Name: LocalPosition
             Description: gets and sets m13 and 32 to a x and y value in a local transform
             Type:Vector2
     Name: Velocity
             Description: returns _velocity 
             Type:Vector2
     Name: GetAngle()
             Description: returns _angle
             Type:float
     Name: AddChild(Actor child)
             Description: adds an actor in the children index to be controlled by the parent
             Type:bool
     Name: RemoveChild(Actor child)
             Description: removes an actor in the children index
             Type:bool
     Name: GetIsAlive()
             Description: checks if the actor is alive 
             Type:bool
     Name: SetTranslate(Vector2 position)
             Description: sets _translation to be Matrix3's CreateTranslation
             Type:void
     Name: SetRotation(float radians)
             Description: sets _rotation to be Matrix3's CreateRotation
             Type:void
     Name: SetScale(float x, float y)
             Description: sets _scale to be Matrix3's CreateScale
             Type:void
     Name: Rotate(float radians)
             Description: rotates the actor at a ceratain speed
             Type:void
     Name: UpdateTransforms()
             Description: updates the transform to be the newer transforms
             Type:void
     Name: Start()
             Description: sets Started to be true 
             Type: virtual void
     Name: CheckCollision
             Description: checks the actors World position to see if the actors collision radius intersects 
             Type:bool
     Name: OnCollision
             Description: used to do a action incase two actors collided 
             Type:virtual void
     Name: Update(float deltaTime)
             Description: updates the actor class math for Matrix higherarchys and velocity
             Type:virtual void
     Name: Draw()
             Description: updates the actor's sprites and icons 
             Type:virtual void
     Name: End()
             Description: sets Started to false 
             Type:virtual void
             
### Player : Actor Class
     Name: Bullet()
             Description: Constructor for Bullet
             Type:Bullet
     Name: _durability
             Description: used for the durability of a bullet
             Type:float
     Name: _timer
             Description: used for a timer
             Type:float
     Name: _coolDown
             Description: used for the use time of a bullet
             Type:float
     Name: _coolingDown
             Description: used as a tag to see if _coolDown has been completed
             Type:bool
     Name: Update(float deltaTime)
             Description: used to Update the Player class
             Type:override void
     Name: CreateBullet(Bullet bullet)
             Description: used to create a bullet in the scene
             Type:void
     Name: RemoveBullet
             Description: removes a bullet from the scene
             Type:void
     Name: Draw()
             Description: draws the player character
             Type:override void
     Name: OnCollision
             Description: used to determine if the player collided with any object listed in the function
             Type:override void

### Enemy: Actor Class
     Name: _deadZombie
             Description:used to determine if the zombie died 
             Type:bool
     Name: _approveRespawn
             Description: tag for zombies who are or aren't elligable to respawn
             Type: bool
     Name: _target
             Description: gives an actor the targeted tag for zombies to track 
             Type:Actor
     Name: _alertColor
             Description: sets the alerted color if the enemy spots a target 
             Type:Color
     Name: Target
             Description: gets and sets Target to be a value 
             Type:Actor
     Name: GetTargetInSight(float maxAngle, float maxDistance)
             Description: allows the enemy to detect
             Type:bool
     Name: TrackTargetInSight(Vector2 position)
             Description: allows to follow the targeted actor
             Type: void
     Name: Oncollision(Actor other)
             Description: allows the Enemy to interact with the player and bullet on collision
             Type:override voide
     Name: Respawn(Enemy enemy)
             Description: gives the zombie the proper tags to be respawned
             Type:void
     Name: Update(float deltaTime)
             Description: updates Enemy for targeting 
             Type:override void
     Name: Draw()
             Description: draws the sprite on the scene 
             Type:override void
### Scene
     Name: _actors 
             Description: actor array 
             Type: Actor[]
     Name: _transform
             Description: transform for Matrix3 
             Type:Matrix3
     Name: CheckCollision()
             Description: Checks the collision of actors in a scene
             Type:void
     Name: AddActor(Actor actor)
             Description: adds an actor into the current scene
             Type:void
     Name: RemoveActor(int index)
             Description: removes an actor from the scene's index
             Type:bool
     Name: Start()
             Description: starts the process of adding actors in the scene 
             Type:virtual void
     Name: Draw()
             Description: starts the process of adding actor sprites in the scene 
             Type:virtual void
     Name: End()
             Description: ends the update for updating the actor array 
             Type:virtual void
             
### Sprite Class

     Name: _texture
             Description: sets the texture 
             Type:Texture2D
     Name: Width
             Description: sets the Width of a sprite 
             Type:int
     Name: Height
             Description: sets the height of a sprite 
             Type:int
     Name: Draw(Matrix3 transform)
             Description: draws out all the sprites
             Type:void

# MathLibrary

### Vector2 Class
     Name: _x
             Description: used for x in equations 
             Type:float
     Name: _y
             Description: used for y in equations 
             Type:float
     Name: FindAngle(Vector2 lhs, Vector2 rhs)
             Description: finds the angle
             Type:static float
     Name: Distance(Vector2 lhs, Vector2 rhs)
             Description:  finds the distance
             Type: static float
     Name: DotProduct(Vector2 lhs, Vector2 rhs)
             Description:  finds the dot product
             Type:static float
     Name: Magnitude
             Description: gets the formula for magnitude  
             Type:float
     Name: Normalized
             Description: normalizes a value  
             Type:Vector2
     Name: DRange
             Description: gets the distance of an object
             Type:float
     Name: Normalize(Vector2 vector)
             Description: Normalizes a vector
             Type:static Vector2
             
             Adding:
             public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
             lhs.X + rhs.X, lhs.Y + rhs.Y
             Subtraction:
             public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
             lhs.X - rhs.X, lhs.Y - rhs.Y
             Multiplying:
             public static Vector2 operator *(Vector2 lhs, float scalar)
             lhs.X * scalar, lhs.Y * scalar
             Dividing:
             public static Vector2 operator /(Vector2 lhs, float scalar)
             lhs.X / scalar, lhs.Y / scalar

### Vector3 Class

     Name: _x
             Description: used for x in equations 
             Type:float
     Name: _y
             Description: used for y in equations 
             Type:float
     Name: _z
             Description: used for z in equations 
             Type:float
     Name: X
             Description: used for x in equations 
             Type:float
     Name: Y
             Description: used for y in equations 
             Type:float
     Name: Z
             Description: used for z in equations 
             Type:float
     Name: DotProduct(Vector3 lhs, Vector3 rhs)
             Description:  finds the dot product
             Type:static float
     Name: Magnitude
             Description: gets the formula for magnitude  
             Type:float
     Name: Normalized
             Description: normalizes a value  
             Type:Vector3
     Name: Normalize(Vector3 vector)
             Description: Normalizes a vector
             Type:static Vector3
     Name: CrossProduct(Vector3 lhs, Vector3 rhs)
             Description: gets the cross product of a equation  
             Type:static Vector3
             
             Adding:
             public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
             lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z
             Subtraction:
             public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
             lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z
             Multiplying:
             public static Vector3 operator *(Vector3 lhs, float scalar)
             lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar
             Dividing:
             public static Vector3 operator /(Vector3 lhs, float scalar)
             lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar
             
###Vector4 Class

     Name: X
             Description: used for x in equations 
             Type:float
     Name: Y
             Description: used for y in equations 
             Type:float
     Name: Z
             Description: used for z in equations 
             Type:float
     Name: W
             Description: used for w in equations 
             Type:float
     Name: DotProduct(Vector4 lhs, Vector4 rhs)
             Description:  finds the dot product
             Type:static float
     Name: Magnitude
             Description: gets the formula for magnitude  
             Type:float
     Name: Normalized
             Description: normalizes a value  
             Type:Vector4
     Name: Normalize(Vector4 vector)
             Description: Normalizes a vector
             Type:static Vector4
     Name: CrossProduct(Vector4 lhs, Vector4 rhs)
             Description: gets the cross product of a equation  
             Type:static Vector4
             
             Adding:
             public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
             lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W
             Subtraction:
             public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
             lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W
             Multiplying:
             public static Vector4 operator *(Vector4 lhs, float scalar)
             lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.W * scalar
             Dividing:
             public static Vector4 operator /(Vector4 lhs, float scalar)
             lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar, lhs.W / scalar

###Matrix3 Class

            m11 = 1, m12 = 0, m13 = 0
            m21 = 0, m22 = 1, m23 = 0
            m31 = 0, m32 = 0, m33 = 1
            
     Name: CreateRotation(float radians)
             Description: creates a rotation for an object
             Type:static Matrix3
     Name: CreateTranslation(Vector2 position)
             Description: creates an updated translation
             Type:static Matrix3
     Name: CreateScale(Vector2 scale)
             Description: creates an updated scale
             Type:static Matrix3
             
             Adding:
             public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
             lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13,
             lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23,
             lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33
             Subtraction:
             public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
             lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13,
             lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23,
             lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33
             Multiplying:
             public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
             ROW 1, COLUMN 1
             lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
             ROW 1, COLUMN 2
             lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
              ROW 1, COLUMN 3
              lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,

              ROW 2, COLUMN 1
              lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
              ROW 2, COLUMN 2
              lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
              ROW 2, COLUMN 3
              lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,

              ROW 3, COLUMN 1
              lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
              ROW 3, COLUMN 2
              lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
              ROW 3, COLUMN 3
              lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33
             
###Matrix4 Class

            m11 = 1, m12 = 0, m13 = 0, m14 = 0
            m21 = 0, m22 = 1, m23 = 0, m24 = 0
            m31 = 0, m32 = 0, m33 = 1, m34 = 0
            m41 = 0, m42 = 0, m43 = 0, m44 = 1
            
     Name: CreateRotation(float radians)
             Description: creates a rotation for an object
             Type:static Matrix4
     Name: CreateTranslation(Vector3 position)
             Description: creates an updated translation
             Type:static Matrix4
     Name: CreateRotationX(float radians)
             Description: sets a rotation on X
             Type:static Matrix4
     Name: CreateRotationY(float radians)
             Description: sets a rotation on Y
             Type:static Matrix4
     Name: CreateRotationZ(float radians)
             Description: sets a rotation on Z
             Type:static Matrix4
             
             Adding:
                   lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13, lhs.m14 + rhs.m14,
                   lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23, lhs.m24 + rhs.m24,
                   lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33, lhs.m34 + rhs.m34,
                   lhs.m41 + rhs.m41, lhs.m42 + rhs.m42, lhs.m43 + rhs.m43, lhs.m44 + rhs.m44
             Subtraction:
                   lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13, lhs.m14 - rhs.m14,
                   lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23, lhs.m24 - rhs.m24,
                   lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33, lhs.m34 - rhs.m34,
                   lhs.m41 - rhs.m41, lhs.m42 - rhs.m42, lhs.m43 - rhs.m43, lhs.m44 - rhs.m44
             Multiplying:
                   ROW 1, COLUMN 1
                   lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31 + lhs.m14 * rhs.m41,
                   ROW 1, COLUMN 2
                   lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32 + lhs.m14 * rhs.m42,
                   ROW 1, COLUMN 3
                   lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33 + lhs.m14 * rhs.m43,
                   ROW 1, COLUMN 4
                   lhs.m11 * rhs.m14 + lhs.m12 * rhs.m24 + lhs.m13 * rhs.m34 + lhs.m14 * rhs.m44,

                   ROW 2, COLUMN 1
                   lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31 + lhs.m24 * rhs.m41,
                   ROW 2, COLUMN 2
                   lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32 + lhs.m24 * rhs.m42,
                   ROW 2, COLUMN 3
                   lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33 + lhs.m24 * rhs.m43,
                   ROW 2, COLUMN 4
                   lhs.m21 * rhs.m14 + lhs.m22 * rhs.m24 + lhs.m23 * rhs.m34 + lhs.m24 * rhs.m44,

                   ROW 3, COLUMN 1
                   lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31 + lhs.m34 * rhs.m41,
                   ROW 3, COLUMN 2
                   lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32 + lhs.m34 * rhs.m42,
                   ROW 3, COLUMN 3
                   lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33 + lhs.m34 * rhs.m43,
                   ROW 3, COLUMN 4
                   lhs.m31 * rhs.m14 + lhs.m32 * rhs.m24 + lhs.m33 * rhs.m34 + lhs.m34 * rhs.m44,

                   ROW 4, COLUMN 1
                   lhs.m41 * rhs.m11 + lhs.m42 * rhs.m21 + lhs.m43 * rhs.m31 + lhs.m44 * rhs.m41,
                   ROW 4, COLUMN 2
                   lhs.m41 * rhs.m12 + lhs.m42 * rhs.m22 + lhs.m43 * rhs.m32 + lhs.m44 * rhs.m42,
                   ROW 4, COLUMN 3
                   lhs.m41 * rhs.m13 + lhs.m42 * rhs.m23 + lhs.m43 * rhs.m33 + lhs.m44 * rhs.m43,
                   ROW 4, COLUMN 4
                   lhs.m41 * rhs.m14 + lhs.m42 * rhs.m24 + lhs.m43 * rhs.m34 + lhs.m44 * rhs.m44
                   

# Unit Test
        Matrix3 Transpose(Matrix3 mat)
        returns a new matrix3
        
        Matrix4 Transpose(Matrix4 mat)
        returns a new matrix4
        
        bool compare(float a, float b, float tolerance = DEFAULT_TOLERANCE)
        compares a and b
        
        bool compare(Vector3 a, Vector3 b, float tolerance = DEFAULT_TOLERANCE)
        compares vector3 a and b
        
        bool compare(Vector4 a, Vector4 b, float tolerance = DEFAULT_TOLERANCE)
        compare Vector4 a and b
        
        bool compare(Matrix3 a, Matrix3 b, float tolerance = DEFAULT_TOLERANCE)
        compares Matrix3 a and b
        
        bool compare(Matrix4 a, Matrix4 b, float tolerance = DEFAULT_TOLERANCE)
        compares Matrix4 a and b
        
        public void Vector3Addition()
        adds Vector3s
         
        public void Vector4Addition()
        adds Vector4s 
        
        public void Vector3Subtraction()
        subtracts Vector3s
        
        public void Vector4Subtraction()
        subtracts Vector4
        
        public void Vector3PostScale()
        gets the scale of a Vector3
        
        public void Vector4PostScale()
        gets the scale of a Vector4
         
        public void Vector3Dot()
        gets the Dot product of a vector3
        
        public void Vector4Dot()
        gets the Dot product of a vector4
        
        public void Vector3Cross()
        gets the cross product of a Vector3
        
        public void Vector4Cross()
        gets the cross product of a Vector4
        
        public void Vector3Magnitude()
        gets the magnitude of a Vector3
        
        public void Vector4Magnitude()
        gets the magnitude of a Vector4
        
        public void Vector3Normalise()
        Normalizes a Vector3
        
        public void Vector4Normalise()
        Normalizes a Vector4
        
        public void Matrix4SetRotateX()
        sets the rotation of X in a Matrix4
        
        public void Matrix4SetRotateY()
        sets the rotation of Y in a Matrix4
        
        public void Matrix3SetRotate()
        sets the rotate of a Matrix3
        
        public void Matrix4SetRotateZ()
        sets the Z axis of a Matrix4
        
        public void Vector3MatrixTransform2()
        sets a Vector3 transform
        
        public void Vector4MatrixTransform()
        sets a Vector4 transform
        
        public void Matrix3Multiply()
        multipies a Matrix3
        
        public void Matrix4Multiply()
        multiplies a Matrix4
        
        public void Vector3MatrixTranslation()
        sets the translation of a Vector3
        
        public void Vector4MatrixTranslation()
        sets the translation of a Vector4
