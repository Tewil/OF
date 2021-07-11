using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PNGGenerate : MonoBehaviour
{
	public Image myImageComponent;
	public Sprite[] pngs;
	public GameObject[] flowers;
	public static GameObject objectSpawn;


	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
    }

    public void generatePNG()
	{
        if (HeightSlot.seedHeight != 0 && ColorSlot.seedColor != 0 && TextureSlot.seedTexture !=0){
// erste Blume
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[0];
                objectSpawn = flowers[0];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[1];
                objectSpawn = flowers[1];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[2];
                objectSpawn = flowers[2];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[3];
                objectSpawn = flowers[3];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[4];
                objectSpawn = flowers[4];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[5];
                objectSpawn = flowers[5];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[6];
                objectSpawn = flowers[6];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[7];
                objectSpawn = flowers[7];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[8];
                objectSpawn = flowers[8];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[9];
                objectSpawn = flowers[9];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[10];
                objectSpawn = flowers[10];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[11];
                objectSpawn = flowers[11];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[12];
                objectSpawn = flowers[12];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[13];
                objectSpawn = flowers[13];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[14];
                objectSpawn = flowers[14];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 1){
                myImageComponent.overrideSprite = pngs[15];
                objectSpawn = flowers[15];
            }

// zweite Blume
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[16];
                objectSpawn = flowers[16];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[17];
                objectSpawn = flowers[17];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[18];
                objectSpawn = flowers[18];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[19];
                objectSpawn = flowers[19];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[20];
                objectSpawn = flowers[20];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[21];
                objectSpawn = flowers[21];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[22];
                objectSpawn = flowers[22];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[23];
                objectSpawn = flowers[23];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[24];
                objectSpawn = flowers[24];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[25];
                objectSpawn = flowers[25];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[26];
                objectSpawn = flowers[26];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[27];
                objectSpawn = flowers[27];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[28];
                objectSpawn = flowers[28];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[29];
                objectSpawn = flowers[29];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[30];
                objectSpawn = flowers[30];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 2){
                myImageComponent.overrideSprite = pngs[31];
                objectSpawn = flowers[31];
            }

// dritte Blume
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[32];
                objectSpawn = flowers[32];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[33];
                objectSpawn = flowers[33];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[34];
                objectSpawn = flowers[34];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[35];
                objectSpawn = flowers[35];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[36];
                objectSpawn = flowers[36];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[37];
                objectSpawn = flowers[37];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[38];
                objectSpawn = flowers[38];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[39];
                objectSpawn = flowers[39];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[40];
                objectSpawn = flowers[40];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[41];
                objectSpawn = flowers[41];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[42];
                objectSpawn = flowers[42];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[43];
                objectSpawn = flowers[43];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[44];
                objectSpawn = flowers[44];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture== 3){
                myImageComponent.overrideSprite = pngs[45];
                objectSpawn = flowers[45];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[46];
                objectSpawn = flowers[46];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 3){
                myImageComponent.overrideSprite = pngs[47];
                objectSpawn = flowers[47];
            }

// vierte Blume
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[48];
                objectSpawn = flowers[48];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[49];
                objectSpawn = flowers[49];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[50];
                objectSpawn = flowers[50];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 1 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[51];
                objectSpawn = flowers[51];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[52];
                objectSpawn = flowers[52];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[53];
                objectSpawn = flowers[53];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[54];
                objectSpawn = flowers[54];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 2 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[55];
                objectSpawn = flowers[55];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[56];
                objectSpawn = flowers[56];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[57];
                objectSpawn = flowers[57];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[58];
                objectSpawn = flowers[58];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 3 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[59];
                objectSpawn = flowers[59];
            }
            if(HeightSlot.seedHeight == 1 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[60];
                objectSpawn = flowers[60];
            }
            if(HeightSlot.seedHeight == 2 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[61];
                objectSpawn = flowers[61];
            }
            if(HeightSlot.seedHeight == 3 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[62];
                objectSpawn = flowers[62];
            }
            if(HeightSlot.seedHeight == 4 && ColorSlot.seedColor == 4 && TextureSlot.seedTexture == 4){
                myImageComponent.overrideSprite = pngs[63];
                objectSpawn = flowers[63];
            }
        }
        else {
        }

	}
}
