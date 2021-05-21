using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Xtron
{
    public class TheMaps
    {

        public enum Maps
        {
            [Display(Name = "Greenlands")] Map1,
            [Display(Name = "The Mirror Fields")] Map2,
            [Display(Name = "Pit of Lava")] Map3,
            [Display(Name = "Swamp of the Ravens")] Map4,
            [Display(Name = "Ruins of Xtro")] Map5
        }

        public static Maps mapcoords { get; set; }
        public string[] _MapObjects { get; set; }


        public TheMaps()
        {

        }

        public static string[] LoadMap(Maps mapcoords)
        {
            var ReturnStringArray = new string[10];
            switch (mapcoords)
            {
                case Maps.Map1:
                    ReturnStringArray[0] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    ReturnStringArray[1] = "XXOOOOOOOOOOOOOOOOOOOOOOOXXXOOOOOOOOOOOOOOOOOOOOOOTTTTTTOOOOOOXXOOOOO";
                    ReturnStringArray[2] = "XXXOOOOOTTTTTTOOOTTTTOOOOOXOTTTTTTTTTTTOOOOOOOOOOOTOOOOOOOOOOOOOOOXXX";
                    ReturnStringArray[3] = "XXXXXOOOTOOOOTOOOTOOTTTTTTTTTXOOOOOOOOTTTTTTTTTTTTTOOOOOXXXXOOOOOOOXX";
                    ReturnStringArray[4] = "XXXXXXXOTOXOOTOOOTOOOXOOOXOOXXXOOOOOOOOTOOOOOOOOOOOOOOOXOOOOXOOOOOOOX";
                    ReturnStringArray[5] = "XXXXOOOOTXXXOTTTTTOOXXXOXXXOOXOOOOOOOTTTOOOOOOOOOOOOOOXOOOMOOXOOOOOOX";
                    ReturnStringArray[6] = "XXXXXXXXTOXXXOOXOOXOOOOOOXOOXXOOOOOOOTOOOOOOOOOOOOOOOXOOOOOOOOXOOOOOX";
                    ReturnStringArray[7] = "XXXXXXOOTOOOXXXXXOXXXOOOOOOOXOOOOOOOOTOOOOOOOOOOOOOOOOXOOOOOOXOOOOOXX";
                    ReturnStringArray[8] = "XXXXXXXOOOOOOXXXXXXXXXOOOOOOXXOOOOOOOTOOOOOOOOOOOOOOOOOXOOOOOOOOOOXXX";
                    ReturnStringArray[9] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXTXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    WorldMap.MapName = "Greenlands"; //tempfix
                    break;
                case Maps.Map2:
                    ReturnStringArray[0] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXTXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    ReturnStringArray[1] = "XXMOOOOOOOOOOOOOOOOBBOOOOXXXXXXXXXXTTTXXXXXXXXTTTTTTTTTTTTTTTTTTTTTXX";
                    ReturnStringArray[2] = "XXOOOOOOOOOOOOOOOOOXXOOOOOXXXXXXXXTTXTXXXXXXXTTOOOOOOOOOOOOOOOOOOOTXX";
                    ReturnStringArray[3] = "XXOOOOOOOOOOOOOOOOXXXXOOOOXXXXXXXTTXXTXXXXXXTTXXXXXXXXXXXXXXXXXXXXTXX";
                    ReturnStringArray[4] = "XXXXXXXXXXXXXXXXXXXXXXXOOOOOXXXXTTXXXTXXXXXTTXXXXXXXXXXBTTTTTTTTTTTXX";
                    ReturnStringArray[5] = "XXTTTTTTTTTTTBXXXXXXXXXXXXOOOXXTTXXXXTXXXXTTOXXXXXXXXXXXXXXXXXXXXXXXX";
                    ReturnStringArray[6] = "XXTXXXXXXXXXXXXXXXXXXXXXXXOOOOTTXXXXXTXXXTTOOOOXXXXOOOOOOOOOOOOOOOOXX";
                    ReturnStringArray[7] = "XXTOOOOOOOOOOOOOOOOOOOOOOOOOOTTXXXXXXTXXTTXXOOOOXXOOOOOOOOOOOOOOOOOXX";
                    ReturnStringArray[8] = "XXTTTTTTTTTTTTTTTTTTTTTTTTTTTTXXXXXXXTTTTXXXXOOOBBOOOOOOOOOOOOOOOOMXX";
                    ReturnStringArray[9] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXBXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    WorldMap.MapName = "The Mirror Shrine";
                    break;
                case Maps.Map3:
                    ReturnStringArray[0] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    ReturnStringArray[1] = "ZZZZZZZZZZZZZZZXZZZZZZZZZZZZZZZZZZZXXZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZX";
                    ReturnStringArray[2] = "XXXXXXXXXXXXZZXXXXZZZZZZXXXZZZZZZZXXZZZZZXXXXXXXXXXXXXXXXXXXXXXXXZZZX";
                    ReturnStringArray[3] = "XZZZZZZZZZZZZZZXXXXXZZZZZXZZXZZZZXXZZZZZXXZZZZZZZZZZZZZZZZZZZZZZZZZZX";
                    ReturnStringArray[4] = "XZZZZZZZZZZZXXZZXXXZZZZZZZZXXXZZXXZZZZZXXZZZZXXXXXXXXXXXXXXXXXXXZZZZX";
                    ReturnStringArray[5] = "XZZZZZZZZZXXXZZZXXZZZZXXXZZZZZZXXZZZZZXXZZZZZXXZZZZZZZXXZZZZZZXXZZZZX";
                    ReturnStringArray[6] = "XZZZZZZZZZZXXXMXXZZZXXXZZZZZZZXXZZZZZXXZZZZZXXZZZXXZZXXZZZMZZZXXZZMZX";
                    ReturnStringArray[7] = "XZZZZZZZZZZZXXXXZZXXXZZZZZZZZXXZZZZZXXZZZZZXXZZZXXZZXXZZZZZZZZXXZZZZX";
                    ReturnStringArray[8] = "XZZZZZZZZZZZZZZZZXXXZZZZZZZZZZZZZZZXXZZZZZZZZZZXXZZZZZZZZZZZZZXXZZZZX";
                    ReturnStringArray[9] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    WorldMap.MapName = "Swamp of the Ravens";
                    break;
                case Maps.Map4:
                    WorldMap.MapName = "Pit of Lava";
                    break;
                case Maps.Map5:
                    WorldMap.MapName = "Ruins of Xtro";
                    break;
            }

            return ReturnStringArray;
        }



    }
}
