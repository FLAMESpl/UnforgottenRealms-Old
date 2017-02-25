﻿using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Geometry;
using UnforgottenRealms.Common.Geometry.Coordinates;
using UnforgottenRealms.Common.Resources;
using System;
using UnforgottenRealms.Editor.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class Map : Drawable
    {
        private List<List<Field>> fields;

        public HexModel Model { get; }
        public ResourceManager Resources { get; }

        public Vector2i Size { get; private set; }

        public Field this[OffsetCoordinates index]
        {
            get { return fields[index.Column][index.Row]; }
        }

        public Map(HexModel model, ResourceManager resources)
        {
            Model = model;
            Resources = resources;
        }

        public bool Contains(OffsetCoordinates position) => position.Column < Size.X && position.Row < Size.Y;

        public void Create(Vector2i size)
        {
            Size = size;
            fields = new List<List<Field>>();
            for (int i = 0; i < size.X; i++)
            {
                fields.Add(new List<Field>());
                for (int j = 0; j < size.Y; j++)
                {
                    fields[i].Add(CreateField(i, j));
                }
            }
        }

        public void SetSize(Vector2i size)
        {
            var difference = size - Size;

            if (difference.X < 0)
            {
                fields.RemoveRange(size.X - 1, -difference.X);
            }
            else if (difference.X > 0)
            {
                for (int i = Size.X; i < size.X; i++)
                {
                    fields.Add(new List<Field>());
                    for (int j = 0; j < size.Y; j++)
                        fields[i].Add(CreateField(i, j));
                }
            }

            if (difference.Y < 0)
            {
                for (int i = 0; i < size.X; i++)
                    fields[i].RemoveRange(size.Y - 1, -difference.Y);
            }
            else if (difference.Y > 0)
            {
                for (int i = 0; i < Size.X; i++)
                {
                    for (int j = Size.Y; j < size.Y; j++)
                        fields[i].Add(CreateField(i, j));
                }
            }
        }

        private Field CreateField(int i, int j)
        {
            var field = new Field(new OffsetCoordinates(i, j), this);
            //field.Terrain = new Terrain(field, Resources.Get<EditorTilesets>().Terrain.Grass);
            return field;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var row in fields)
                foreach (var field in row)
                    target.Draw(field, states);
        }
    }
}