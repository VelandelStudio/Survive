using UnityEngine;

public class TimeHelper {
	
	public static string ConvertFloatToTimer(float val) {
		int sec = (int) (val+0.5);
		int mins = sec / 60;
		Debug.Log(mins);
		sec -= mins * 60;
		return string.Format("{0}:{1}",mins.ToString().PadLeft(2,'0'),sec.ToString().PadLeft(2,'0'));
	}
}