using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ACFramework
{
    class cRoom { 
		public static readonly float TREASURERADIUS = 1.2f;
		public static readonly float WALLTHICKNESS = 0.5f;
		public static readonly float PLAYERRADIUS = 0.2f;
		public static readonly float MAXPLAYERSPEED = 30.0f;
		private bool doorcollision;
		private List<List<bool>> mazePlanx;
		private List<List<bool>> mazePlanz;
		private float width;
		private cGame3D game;
		public cRoom(cGame3D game, int room = 1)
        {
			this.game = game;
			game.Biota.purgeCritters<cCritterWall>();
			game.Biota.purgeCritters<cCritter3Dcharacter>();
			game.Biota.purgeCritters<cCritterShape>();
			doorcollision = false;
			int roomSize = 100;
			
			if(room == 1)
				Room1();
			if(room == 2)
				Room2();
			if(room == 3) 
				Room3();
			game.setBorder(roomSize, 16.0f, roomSize); // size of the world

		
			cRealBox3 skeleton = new cRealBox3();
			skeleton.copy(game.Border);
			game.setSkyBox(skeleton);
			game.SkyBox.setSideSolidColor(cRealBox3.HIZ, Color.Green); //Make the near HIZ transparent 
			game.SkyBox.setSideSolidColor(cRealBox3.LOZ, Color.Green); //Far wall 
			game.SkyBox.setSideSolidColor(cRealBox3.LOX, Color.DarkOrchid); //left wall 
			game.SkyBox.setSideTexture(cRealBox3.HIX, BitmapRes.Wall2, 2); //right wall 
			game.SkyBox.setSideTexture(cRealBox3.LOY, BitmapRes.Graphics3); //floor 
			game.SkyBox.setSideTexture(cRealBox3.HIY, BitmapRes.Sky); //ceiling 
			width = roomSize / mazePlanx.Count;



			for (int i = 0; i < mazePlanx.Count; i++)
			{
				for (int j = 0; j < mazePlanx.Count; j++)
				{
					if (mazePlanx[i][j])
					{
						float height = 0.3f * game.Border.YSize;
						float ycenter = -game.Border.YRadius + height / 2.0f;
						float wallthickness = cGame3D.WALLTHICKNESS;
						cCritterWall pwall = new cCritterWall(
							new cVector3(game.Border.Hix - (width * j), ycenter, game.Border.Hiz - (width * i)),
							new cVector3(game.Border.Hix - (width * (j + 1)), ycenter, game.Border.Hiz - (width * i)),
							height, //thickness param for wall's dy which goes perpendicular to the 
									//baseline established by the frist two args, up the screen 
							wallthickness, //height argument for this wall's dz  goes into the screen 
							game);
						cSpriteTextureBox pspritebox =
							new cSpriteTextureBox(pwall.Skeleton, BitmapRes.Wall3, 16); //Sets all sides 

						pwall.Sprite = pspritebox;
					}
				}

			
			}
			for (int i = 0; i < mazePlanx.Count; i++)
			{
				for (int j = 0; j < mazePlanx.Count; j++)
				{
					if (mazePlanz[i][j])
					{
						float height = 0.3f * game.Border.YSize;
						float ycenter = -game.Border.YRadius + height / 2.0f;
						float wallthickness = cGame3D.WALLTHICKNESS;
						cCritterWall pwall = new cCritterWall(
							new cVector3(game.Border.Hix - (width * i), ycenter, game.Border.Hiz - (width * j)),
							new cVector3(game.Border.Hix - (width * i), ycenter, game.Border.Hiz - (width * (j + 1))),
							wallthickness, //thickness param for wall's dy which goes perpendicular to the 
									//baseline established by the frist two args, up the screen 
							height, //height argument for this wall's dz  goes into the screen 
							game);
						cSpriteTextureBox pspritebox =
							new cSpriteTextureBox(pwall.Skeleton, BitmapRes.Wall3, 16); //Sets all sides 

						pwall.Sprite = pspritebox;
					}
				}

			}
		}

		private void Room1()
		{
			mazePlanx = new List<List<bool>>();
			mazePlanx.Add(new List<bool>() { false, false, false, false, false, false, false, false, false, false });
			mazePlanx.Add(new List<bool>() { true, false, false, false, false, false, true, false, false, false });
			mazePlanx.Add(new List<bool>() { false, true, false, false, true, true, false, false, true, false });
			mazePlanx.Add(new List<bool>() { false, false, true, true, false, false, true, true, true, true });
			mazePlanx.Add(new List<bool>() { false, true, true, true, false, true, true, true, true, false });
			mazePlanx.Add(new List<bool>() { false, false, false, false, false, false, true, true, false, false });
			mazePlanx.Add(new List<bool>() { false, false, false, false, true, true, false, true, false, true });
			mazePlanx.Add(new List<bool>() { false, false, true, true, false, true, true, false, true, false });
			mazePlanx.Add(new List<bool>() { true, false, false, false, true, true, true, true, false, false });
			mazePlanx.Add(new List<bool>() { false, false, true, false, false, true, false, true, true, false });

			mazePlanz = new List<List<bool>>();
			mazePlanz.Add(new List<bool>() { false, false, false, false, false, false, false, false, false, false });
			mazePlanz.Add(new List<bool>() { false, false, true, true, true, true, true, false, true, false });
			mazePlanz.Add(new List<bool>() { false, true, false, false, true, true, false, true, true, true });
			mazePlanz.Add(new List<bool>() { true, true, true, false, false, true, true, true, false, false });
			mazePlanz.Add(new List<bool>() { false, true, false, true, false, true, false, false, true, true });
			mazePlanz.Add(new List<bool>() { true, false, true, true, true, true, false, false, false, false });
			mazePlanz.Add(new List<bool>() { false, false, false, false, false, false, true, false, false, true});
			mazePlanz.Add(new List<bool>() { false, true, true, false, false, false, false, true, true, false });
			mazePlanz.Add(new List<bool>() { true, true, false, false, false, true, true, false, false, false });
			mazePlanz.Add(new List<bool>() { false, true, false, false, true, false, false, true, true, false });

		}

		private void Room2()
		{
			mazePlanx = new List<List<bool>>();
			mazePlanx.Add(new List<bool>() { false, false, false, false, false, false, false, false, false, false });
			mazePlanx.Add(new List<bool>() { true, false, false, false, false, false, false, false, true, true });
			mazePlanx.Add(new List<bool>() { false, true, false, true, true, false, false, true, false, false });
			mazePlanx.Add(new List<bool>() { false, true, false, false, true, true, true, false, false, false });
			mazePlanx.Add(new List<bool>() { true, true, true, false, false, false, true, false, false, true });
			mazePlanx.Add(new List<bool>() { false, true, false, true, false, true, false, true, true, false });
			mazePlanx.Add(new List<bool>() { false, false, true, false, false, false, true, false, false, true });
			mazePlanx.Add(new List<bool>() { true, false, true, true, true, false, false, true, true, false });
			mazePlanx.Add(new List<bool>() { false, false, false, true, false, false, false, true, false, true });
			mazePlanx.Add(new List<bool>() { false, true, true, false, false, true, false, false, true, false });

			mazePlanz = new List<List<bool>>();
			mazePlanz.Add(new List<bool>() { false, false, false, false, false, false, false, false, false, false });
			mazePlanz.Add(new List<bool>() { false, false, false, false, false, true, true, false, true, false });
			mazePlanz.Add(new List<bool>() { true, true, true, false, false, true, false, true, false, false });
			mazePlanz.Add(new List<bool>() { false, true, true, true, false, false, false, false, true, false });
			mazePlanz.Add(new List<bool>() { true, false, false, false, true, true, true, false, true, true });
			mazePlanz.Add(new List<bool>() { false, true, false, true, true, true, true, true, false, true });
			mazePlanz.Add(new List<bool>() { true, true, true, false, false, false, true, true, true, false });
			mazePlanz.Add(new List<bool>() { false, true, false, true, false, true, false, true, true, true });
			mazePlanz.Add(new List<bool>() { false, false, true, true, true, false, true, false, false, false });
			mazePlanz.Add(new List<bool>() { false, false, true, true, false, false, false, false, true, false });

		}


		private void Room3()
		{
			mazePlanx = new List<List<bool>>();
			mazePlanx.Add(new List<bool>() { false, false, false, false, false, false, false, false, false, false });
			mazePlanx.Add(new List<bool>() { false, false, true, false, false, true, true, true, true, false });
			mazePlanx.Add(new List<bool>() { false, true, false, false, false, true, true, true, false, true });
			mazePlanx.Add(new List<bool>() { false, false, true, true, true, false, true, true, false, false });
			mazePlanx.Add(new List<bool>() { false, true, true, false, true, false, true, true, false, false });
			mazePlanx.Add(new List<bool>() { true, false, false, false, false, true, false, true, true, true });
			mazePlanx.Add(new List<bool>() { false, true, true, true, false, false, true, false, true, false });
			mazePlanx.Add(new List<bool>() { true, false, true, true, true, true, true, true, false, true });
			mazePlanx.Add(new List<bool>() { false, true, false, false, false, false, false, true, true, false });
			mazePlanx.Add(new List<bool>() { false, false, true, true, false, false, false, true, false, false });

			mazePlanz = new List<List<bool>>();
			mazePlanz.Add(new List<bool>() { false, false, false, false, false, false, false, false, false, false });
			mazePlanz.Add(new List<bool>() { false, true, true, true, true, false, false, false, false, true });
			mazePlanz.Add(new List<bool>() { true, false, false, false, false, true, true, true, false, false });
			mazePlanz.Add(new List<bool>() { false, false, true, true, true, false, false, false, true, false });
			mazePlanz.Add(new List<bool>() { true, true, false, false, true, true, false, true, true, false });
			mazePlanz.Add(new List<bool>() { false, false, true, false, false, true, true, false, true, true });
			mazePlanz.Add(new List<bool>() { false, false, false, false, true, false, false, true, true, true });
			mazePlanz.Add(new List<bool>() { false, false, false, false, false, true, false, false, false, false });
			mazePlanz.Add(new List<bool>() { false, false, true, false, false, false, true, true, false, true });
			mazePlanz.Add(new List<bool>() { false, true, false, true, true, false, false, false, true, false });

		}

		public void Place(cCritter object1, int xcord,int ycord)
		{
			object1.moveTo(new cVector3(game.Border.Hix-((xcord * width) + width / 2), 0, game.Border.Hiz - ((ycord * width) + width / 2)));
		}
	}
}
