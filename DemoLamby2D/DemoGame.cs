using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Input;
using Lamby2D.Physics;

namespace DemoLamby2D
{
    class DemoGame : Game
    {
        // Variables
        Texture2D texture;
        ImageGameObject imagegameobject;
        Cursor cursor;
        bool debugcolliders = false;
        bool movecamera = false;
        DragImageGameObject dragobject;

        // Handlers
        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyCode.Escape) {
                Quit();
            } else if (e.Key == KeyCode.B) {
                debugcolliders = !debugcolliders;
            } else if (e.Key == KeyCode.C) {
                movecamera = !movecamera;
                imagegameobject.MoveWithInput = !movecamera;
            }
        }

        // Public
        public override void Update(float DeltaTime)
        {
            // called before anything else updates
            if (movecamera == true) {
                float speed = 500.0f;

                if (Game.Current.Input.IsKeyDown(KeyCode.A) == true) {
                    this.Graphics.Camera.Position -= new Vector2(speed * DeltaTime * 0.5f, 0);
                }
                if (Game.Current.Input.IsKeyDown(KeyCode.D) == true) {
                    this.Graphics.Camera.Position += new Vector2(speed * DeltaTime * 0.5f, 0);
                }
                if (Game.Current.Input.IsKeyDown(KeyCode.W) == true) {
                    this.Graphics.Camera.Position -= new Vector2(0, speed * DeltaTime * 0.5f);
                }
                if (Game.Current.Input.IsKeyDown(KeyCode.S) == true) {
                    this.Graphics.Camera.Position += new Vector2(0, speed * DeltaTime * 0.5f);
                }
            }
        }
        Font font = new Font("fonts/FiraMonoOT-Regular.otf");
        public override void PostUpdate(float DeltaTime)
        {
            // called after everything has updated
            this.Graphics.GraphicsContext.Title = (GamePhysics.Intersects(cursor, imagegameobject) ? "Intersects" : "FPS: " + this.FramesPerSecond);

            this.Graphics.DrawColor = Colors.Black;
            this.Graphics.Print("", font);
            this.Graphics.DrawColor = Colors.White;
        }
        public override void PostDraw()
        {
            // stuff drawn here is on top of everything else
            this.Graphics.Draw(cursor);

            if (debugcolliders == true) {
                this.Graphics.PolygonMode = PolygonMode.Line;
                this.Graphics.DrawCircle(cursor.Position, ((CollisionCircle) cursor.Collider).Radius);
                this.Graphics.DrawCircle(imagegameobject.Position, ((CollisionCircle) imagegameobject.Collider).Radius);
                this.Graphics.PolygonMode = PolygonMode.Fill;
            }
        }
        public override void Dispose()
        {
            // we must dispose of textures (for now)
            texture.Dispose();
            cursor.Texture.Dispose();

            // last thing on this function
            base.Dispose();
        }

        // Constructors
        public DemoGame()
        {
            this.Graphics.BackgroundColor = Colors.DimGray;
            this.Graphics.GraphicsContext.Resize(640, 360);
            this.Graphics.GraphicsContext.Title = "Demo Game";
            this.Graphics.GraphicsContext.ShowCursor = false;
            this.Input.KeyDown += Input_KeyDown;

            cursor = new Cursor();

            texture = this.Graphics.CreateTexture("charanim.png");
            imagegameobject = new ImageGameObject() {
                Center = Vector2.Half,
                DrawableKind = DrawableKind.Sprite,
                Sprite = new Sprite(texture, 128, 128),
                Scale = new Vector2(-0.5f, 0.5f),
            };
            imagegameobject.Sprite.AddAnimation("Run", new SpriteAnimation(new int[] { 5, 6, 7, 6, 5, 8, 9, 10, 11, 10, 9, 8, }, 15));
            imagegameobject.Sprite.PlayAnimation("Run");
            imagegameobject.Sprite.AddAnimation("Ass", new SpriteAnimation(new int[] { 12,13,14,15,14,13,12 }, 7));
            //imagegameobject.Sprite.PlayAnimation("Ass");
            imagegameobject.MouseDown += delegate {
                imagegameobject.Position = new Vector2();
            };
            imagegameobject.MouseDown += delegate {
                imagegameobject.Position = Vector2.Zero;
            };

            dragobject = new DragImageGameObject() {
                Center = Vector2.Half,
                DrawableKind = DrawableKind.Sprite,
                Sprite = new Sprite(texture, 128, 128),
                Scale = Vector2.Half,
            };
        }
    }
}
