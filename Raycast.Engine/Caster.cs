﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Raycast.Engine.Extensions;
using Raycast.Engine.Models;
namespace Raycast.Engine
{
	public class Caster
	{
		protected char[][] Map { get; set; }

		public Caster (char[][] map)
		{
			Map = map;
		}

		public CastedRay CastRayForPixel(int pixelNumber, Vector2 startPoint, 
			Vector2 directionVector, Vector2 translateVector, float angle)
		{
			var currentLocation = Vector2.Add(startPoint, translateVector);
			int x = (int)Math.Round(currentLocation.X);
			int y = (int)Math.Round(currentLocation.Y);
			var distance = Vector2.Subtract(currentLocation, startPoint);

			if (Map[y][x] == ' ') 
			{
				var newTranslate = Vector2.Add(translateVector, directionVector);
				return CastRayForPixel(pixelNumber, startPoint, directionVector, newTranslate, angle);
			}
			else
			{
				var ray = new CastedRay();
				ray.PixelOnScreen = pixelNumber;
				ray.HitLocation = currentLocation;
				ray.CalculateTextureOffset(x, y);
				ray.StartPoint = startPoint;
				ray.TranslateVector = translateVector;
				return ray;
			}
		}
	}
}
