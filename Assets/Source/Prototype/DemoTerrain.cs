// DemoTerrain.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 13, 2023 - Friday the 13th, very spooky.

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zop.Demo
{
	/// <summary>
	/// Spawn seeded terrain tiles below the camera.
	/// </summary>
	public class DemoTerrain : MonoBehaviour
	{
		private const float NOISE_SCALE_X = 0.05f;
		private const float NOISE_SCALE_Y = 1.25f;

		public Tilemap Terrain;
		public TileBase[] Tiles; // TODO: Support an inspector-assigned rectangle.

		private Camera _camera;
		private int _cameraX = int.MinValue;
		private int _cameraY = int.MinValue;
		private int _tilesSqr;

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Awake()
		{
			_camera = Camera.main;
			_tilesSqr = Mathf.CeilToInt(Mathf.Sqrt(Tiles.Length));
		}

		/// <summary>
		/// Draw the first frame.
		/// </summary>
		public void Start()
		{
			if (_camera == null)
			{
				return;
			}

			int cX = Mathf.RoundToInt(_camera.transform.position.x);
			int cY = Mathf.RoundToInt(_camera.transform.position.y);
			_cameraX = cX;
			_cameraY = cY;
			RectInt newRect = GetDrawArea(cX, cY);
			Draw(newRect.min.x, newRect.min.y, newRect.size.x, newRect.size.y);
		}

		/// <summary>
		/// Display local tiles.
		/// </summary>
		public void LateUpdate()
		{
			if (_camera == null)
			{
				return;
			}

			// TODO: Detect resize.
			// Ignore if the camera has not moved.
			int cX = Mathf.RoundToInt(_camera.transform.position.x);
			int cY = Mathf.RoundToInt(_camera.transform.position.y);
			if (_cameraX == cX && _cameraY == cY)
			{
				return;
			}

			// Compare camera viewports.
			RectInt oldRect = GetDrawArea(_cameraX, _cameraY);
			RectInt newRect = GetDrawArea(cX, cY);
			_cameraX = cX;
			_cameraY = cY;

			// Erase
			if (oldRect.min.x < newRect.min.x)
			{
				Erase(oldRect.min.x, oldRect.min.y, newRect.min.x - oldRect.min.x, oldRect.size.y);
			}
			if (oldRect.max.x > newRect.max.x)
			{
				Erase(newRect.max.x, oldRect.min.y, oldRect.max.x - newRect.max.x, oldRect.size.y);
			}

			if (oldRect.min.y < newRect.min.y)
			{
				Erase(oldRect.min.x, oldRect.min.y, oldRect.size.x, newRect.min.y - oldRect.min.y);
			}
			if (oldRect.max.y > newRect.max.y)
			{
				Erase(oldRect.min.x, newRect.max.y, oldRect.size.x, oldRect.max.y - newRect.max.y);
			}

			// Draw
			if (newRect.min.x < oldRect.min.x)
			{
				Draw(newRect.min.x, newRect.min.y, oldRect.min.x - newRect.min.x, newRect.size.y);
			}
			if (newRect.max.x > oldRect.max.x)
			{
				Draw(oldRect.max.x, newRect.min.y, newRect.max.x - oldRect.max.x, newRect.size.y);
			}

			if (newRect.min.y < oldRect.min.y)
			{
				Draw(newRect.min.x, newRect.min.y, newRect.size.x, oldRect.min.y - newRect.min.y);
			}
			if (newRect.max.y > oldRect.max.y)
			{
				Draw(newRect.min.x, oldRect.max.y, newRect.size.x, newRect.max.y - oldRect.max.y);
			}
		}

		/// <summary>
		/// Returns a draw area sized by the camera viewport.
		/// </summary>
		public RectInt GetDrawArea(int x, int y)
		{
			if (_camera == null)
			{
				return new RectInt();
			}
			else
			{
				int size = Mathf.CeilToInt(_camera.orthographicSize);
				int extentsY = size + 1;
				int extentsX = (int)(size * ((float)Screen.width / Screen.height)) + 1;
				return new RectInt(x - extentsX, y - extentsY, extentsX * 2, extentsY * 2);
			}
		}

		/// <summary>
		/// Erase tiles.
		/// </summary>
		public void Erase(int x, int y, int w, int h)
		{
			int iEnd = x + w;
			int jEnd = y + h;
			for (int i = x; i < iEnd; i++)
			{
				for (int j = y; j < jEnd; j++)
				{
					Terrain.SetTile(new Vector3Int(i, j), null);
				}
			}
		}

		/// <summary>
		/// Draw tiles.
		/// </summary>
		public void Draw(int x, int y, int w, int h)
		{
			int iEnd = x + w;
			int jEnd = y + h;
			for (int i = x; i < iEnd; i++)
			{
				for (int j = y; j < jEnd; j++)
				{
					float nX = (noise.snoise(new float2(i * NOISE_SCALE_X, j * NOISE_SCALE_X)) + 1) * 0.5f;
					float nY = (noise.snoise(new float2(j * NOISE_SCALE_Y, i * NOISE_SCALE_Y)) + 1) * 0.5f;
					int tilesX = _tilesSqr; // TODO: Support an inspector-assigned rectangle.
					int tilesY = _tilesSqr; // TODO: Support an inspector-assigned rectangle.
					int indexX = Mathf.Min(tilesX - 1, (int)((tilesX + 1) * nX));
					int indexY = Mathf.Min(tilesY - 1, (int)((tilesY + 1) * nY));
					Terrain.SetTile(new Vector3Int(i, j), Tiles[Mathf.Min(Tiles.Length - 1, (indexY * tilesY) + indexX)]);
				}
			}
		}
	}
}