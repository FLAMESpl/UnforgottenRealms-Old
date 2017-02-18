using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using System.Linq;
using UnforgottenRealms.Game.Events;

namespace UnforgottenRealms.Game.Objects.Units
{
    public delegate Unit UnitFactory(Field location, Player owner);

    public abstract class Unit : GameObject
    {
        private Vector2f unitSize;

        private Sprite unitSprite;
        private Sprite emblemSprite;

        public abstract int Movement { get; }
        public abstract float Strength { get; }
        public abstract float Health { get; }

        public int MovementLeft { get; protected set; }
        public float HealthLeft { get; protected set; }

        public Unit(Field location, TextureDescriptor textureDescriptor, Player owner) : 
            base(
                  location: location,
                  owner: owner
            )
        {
            MovementLeft = MovementLeft;
            HealthLeft = Health;

            var position = Location.Position;
            var hexModel = Location.World.Model;
            var resources = Location.World.Resources;
            var emblemTexure = resources.Get<GameTilesets>().Miscellaneous.Emblem;

            unitSize = hexModel.Size / 2;

            emblemSprite = new Sprite
            {
                Color = owner.Colour.ToRGB(),
                Position = hexModel.GetTopLeftCorner(position),
                Scale = Scale(emblemTexure.TileSize, hexModel.Size),
                Texture = emblemTexure.Texture,
                TextureRect = emblemTexure.Bounds
            };

            unitSprite = new Sprite
            {
                Position = hexModel.GetShiftedTopLeftCenter(position, unitSize),
                Scale = Scale(textureDescriptor.TileSize, unitSize),
                Texture = textureDescriptor.Texture,
                TextureRect = textureDescriptor.Bounds
            };

            Location.World.TurnCycle.RoundChanged += Refresh;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(emblemSprite, states);
            target.Draw(unitSprite, states);
        }

        public override void Select(bool isSelected)
        {
            byte newAlpha;

            if (isSelected)
                newAlpha = 155;
            else
                newAlpha = 255;

            emblemSprite.Color = emblemSprite.Color.SetAlpha(newAlpha);
            unitSprite.Color = unitSprite.Color.SetAlpha(newAlpha);
        }

        public override void PerformPrimaryAction(AxialCoordinates targetPosition) => Move(targetPosition);

        protected virtual void Move(AxialCoordinates targetPosition)
        {
            var hexModel = Location.World.Model;
            var targetedField = Location.World[targetPosition];
            if (!targetedField.Units.Any())
            {
                targetedField.Move(this);
                Location = targetedField;
                emblemSprite.Position = hexModel.GetTopLeftCorner(targetPosition);
                unitSprite.Position = hexModel.GetShiftedTopLeftCenter(targetPosition, unitSize);
            }
        }

        protected Vector2f Scale(Vector2i original, Vector2f template)
        {
            return new Vector2f(template.X / original.X, template.Y / original.Y);
        }

        private void Refresh(object sender, RoundChangedEventArgs e)
        {
            MovementLeft = Movement;
        }
    }
}
