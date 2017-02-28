using System;

public class MathHelper {

	public static int getRandInRangeInt(int min, int max) {
		return(new Random().Next(min, max+1));
	}
}