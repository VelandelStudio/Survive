using UnityEngine;

public class MathHelper {

	public static int GetRandInRangeInt(int min, int max) {
		return(Random.Range(min, max+1));
	}

    public static float GetRandInRangeFloat(float min, float max)
    {
        return (Random.Range(min, max + 1));
    }
}